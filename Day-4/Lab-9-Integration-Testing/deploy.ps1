#!/usr/bin/env pwsh
# Deploy to Staging Script
# Usage: .\deploy.ps1

$ErrorActionPreference = "Stop"

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  CAPSTONE API - STAGING DEPLOYMENT" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Configuration
$StagingPath = "staging"
$BackupPath = "backups/staging-backup"
$PublishPath = "publish"
$VersionFile = "$StagingPath/staging-version.txt"

try {
    # Step 1: Create backup of current staging
    Write-Host "📦 Creating backup of current staging..." -ForegroundColor Yellow
    if (Test-Path $StagingPath) {
        if (Test-Path $BackupPath) {
            Remove-Item -Path $BackupPath -Recurse -Force
        }
        New-Item -ItemType Directory -Path (Split-Path $BackupPath) -Force | Out-Null
        Copy-Item -Path $StagingPath -Destination $BackupPath -Recurse -Force
        Write-Host "✅ Backup created: $BackupPath" -ForegroundColor Green
    } else {
        Write-Host "⚠️  No existing staging deployment to backup" -ForegroundColor DarkYellow
    }

    # Step 2: Clean staging directory
    Write-Host "🧹 Cleaning staging directory..." -ForegroundColor Yellow
    if (Test-Path $StagingPath) {
        Remove-Item -Path $StagingPath -Recurse -Force
    }
    New-Item -ItemType Directory -Path $StagingPath -Force | Out-Null

    # Step 3: Copy new artifacts
    Write-Host "📂 Copying artifacts to staging..." -ForegroundColor Yellow
    if (-Not (Test-Path $PublishPath)) {
        throw "Publish folder not found. Please build the project first."
    }
    Copy-Item -Path "$PublishPath\*" -Destination $StagingPath -Recurse -Force
    Write-Host "✅ Artifacts copied successfully" -ForegroundColor Green

    # Step 4: Create version file
    Write-Host "📝 Creating version information..." -ForegroundColor Yellow
    $deploymentInfo = @{
        Version = "1.0.0"
        DeployedAt = (Get-Date -Format "yyyy-MM-dd HH:mm:ss UTC")
        Environment = "Staging"
        Status = "Active"
        BuildNumber = $env:CI_PIPELINE_ID ?? "local"
    }
    $deploymentInfo | ConvertTo-Json | Out-File -FilePath $VersionFile -Encoding UTF8
    Write-Host "✅ Version file created: $VersionFile" -ForegroundColor Green

    # Step 5: Verification
    Write-Host "🔍 Verifying deployment..." -ForegroundColor Yellow
    if (Test-Path "$StagingPath/CapstoneApi.dll") {
        Write-Host "✅ API DLL found" -ForegroundColor Green
    } else {
        throw "API DLL not found in staging directory!"
    }

    Write-Host ""
    Write-Host "========================================" -ForegroundColor Green
    Write-Host "  ✅ DEPLOYMENT SUCCESSFUL" -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Green
    Write-Host ""
    Write-Host "Staging Location: $StagingPath" -ForegroundColor Cyan
    Write-Host "Version File: $VersionFile" -ForegroundColor Cyan
    Write-Host "Backup Location: $BackupPath" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "To rollback, run: .\rollback.ps1" -ForegroundColor Yellow
    Write-Host ""

} catch {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Red
    Write-Host "  ❌ DEPLOYMENT FAILED" -ForegroundColor Red
    Write-Host "========================================" -ForegroundColor Red
    Write-Host ""
    Write-Host "Error: $_" -ForegroundColor Red
    Write-Host ""
    exit 1
}
