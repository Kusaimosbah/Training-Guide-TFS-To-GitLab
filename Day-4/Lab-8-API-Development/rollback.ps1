#!/usr/bin/env pwsh
# Rollback Staging Deployment Script
# Usage: .\rollback.ps1

$ErrorActionPreference = "Stop"

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  CAPSTONE API - STAGING ROLLBACK" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Configuration
$StagingPath = "staging"
$BackupPath = "backups/staging-backup"
$VersionFile = "$StagingPath/staging-version.txt"

try {
    # Step 1: Verify backup exists
    Write-Host "🔍 Checking for backup..." -ForegroundColor Yellow
    if (-Not (Test-Path $BackupPath)) {
        throw "No backup found at: $BackupPath. Cannot rollback."
    }
    Write-Host "✅ Backup found: $BackupPath" -ForegroundColor Green

    # Step 2: Display current version
    Write-Host "📄 Current deployment info:" -ForegroundColor Yellow
    if (Test-Path $VersionFile) {
        Get-Content $VersionFile | Write-Host -ForegroundColor Cyan
    } else {
        Write-Host "⚠️  No version file found" -ForegroundColor DarkYellow
    }

    # Step 3: Confirm rollback
    Write-Host ""
    $confirmation = Read-Host "⚠️  Are you sure you want to rollback? (yes/no)"
    if ($confirmation -ne "yes") {
        Write-Host "Rollback cancelled by user." -ForegroundColor Yellow
        exit 0
    }

    # Step 4: Remove current staging
    Write-Host "🗑️  Removing current staging deployment..." -ForegroundColor Yellow
    if (Test-Path $StagingPath) {
        Remove-Item -Path $StagingPath -Recurse -Force
    }
    Write-Host "✅ Current staging removed" -ForegroundColor Green

    # Step 5: Restore from backup
    Write-Host "⏪ Restoring from backup..." -ForegroundColor Yellow
    Copy-Item -Path $BackupPath -Destination $StagingPath -Recurse -Force
    Write-Host "✅ Backup restored successfully" -ForegroundColor Green

    # Step 6: Update version file
    Write-Host "📝 Updating version information..." -ForegroundColor Yellow
    $rollbackInfo = @{
        Status = "Rolled Back"
        RolledBackAt = (Get-Date -Format "yyyy-MM-dd HH:mm:ss UTC")
        PreviousVersion = "Restored from backup"
    }
    
    if (Test-Path $VersionFile) {
        $currentVersion = Get-Content $VersionFile | ConvertFrom-Json
        $rollbackInfo.OriginalVersion = $currentVersion.Version
        $rollbackInfo.OriginalDeployedAt = $currentVersion.DeployedAt
    }
    
    $rollbackInfo | ConvertTo-Json | Out-File -FilePath $VersionFile -Encoding UTF8 -Append
    Write-Host "✅ Version file updated" -ForegroundColor Green

    # Step 7: Verification
    Write-Host "🔍 Verifying rollback..." -ForegroundColor Yellow
    if (Test-Path "$StagingPath/CapstoneApi.dll") {
        Write-Host "✅ API DLL found in restored staging" -ForegroundColor Green
    } else {
        throw "API DLL not found after rollback!"
    }

    Write-Host ""
    Write-Host "========================================" -ForegroundColor Green
    Write-Host "  ✅ ROLLBACK SUCCESSFUL" -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Green
    Write-Host ""
    Write-Host "Staging has been restored to previous version." -ForegroundColor Cyan
    Write-Host "Location: $StagingPath" -ForegroundColor Cyan
    Write-Host ""

} catch {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Red
    Write-Host "  ❌ ROLLBACK FAILED" -ForegroundColor Red
    Write-Host "========================================" -ForegroundColor Red
    Write-Host ""
    Write-Host "Error: $_" -ForegroundColor Red
    Write-Host ""
    exit 1
}
