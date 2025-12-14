# Rollback Script (PowerShell)
# This script rolls back to the previous deployment

param(
    [string]$StagingPath = "./staging",
    [string]$BackupPath = "./staging-backup"
)

Write-Host "=========================================" -ForegroundColor Red
Write-Host " Rolling Back Staging Deployment" -ForegroundColor Red
Write-Host "=========================================" -ForegroundColor Red
Write-Host ""

# Check if backup exists
if (!(Test-Path $BackupPath)) {
    Write-Host "✗ No backup found to rollback to!" -ForegroundColor Red
    Write-Host "Backup path: $BackupPath" -ForegroundColor Yellow
    exit 1
}

Write-Host "Found backup deployment" -ForegroundColor Green

# Display current version
if (Test-Path "$StagingPath\staging-version.txt") {
    Write-Host ""
    Write-Host "Current Version:" -ForegroundColor Yellow
    Get-Content "$StagingPath\staging-version.txt"
}

# Display backup version
if (Test-Path "$BackupPath\staging-version.txt") {
    Write-Host ""
    Write-Host "Rolling back to:" -ForegroundColor Yellow
    Get-Content "$BackupPath\staging-version.txt"
}

Write-Host ""
Write-Host "Performing rollback..." -ForegroundColor Yellow

# Stop any running processes (simulated)
Write-Host "1. Stopping application..." -ForegroundColor Cyan

# Remove current deployment
if (Test-Path $StagingPath) {
    Remove-Item -Recurse -Force $StagingPath
    Write-Host "   ✓ Current deployment removed" -ForegroundColor Green
}

# Restore from backup
Write-Host "2. Restoring from backup..." -ForegroundColor Cyan
Copy-Item -Recurse $BackupPath $StagingPath
Write-Host "   ✓ Backup restored" -ForegroundColor Green

# Update version file
Write-Host "3. Updating version info..." -ForegroundColor Cyan
$rollbackTime = Get-Date -Format "yyyy-MM-dd HH:mm:ss UTC"
$rollbackInfo = @"

ROLLBACK PERFORMED
Rollback Time: $rollbackTime
Machine: $env:COMPUTERNAME
"@

Add-Content -Path "$StagingPath\staging-version.txt" -Value $rollbackInfo
Write-Host "   ✓ Version info updated" -ForegroundColor Green

# Restart application (simulated)
Write-Host "4. Restarting application..." -ForegroundColor Cyan
Write-Host "   ✓ Application restarted (simulated)" -ForegroundColor Green

Write-Host ""
Write-Host "=========================================" -ForegroundColor Green
Write-Host " Rollback Complete!" -ForegroundColor Green
Write-Host "=========================================" -ForegroundColor Green
Write-Host ""
Write-Host "Current Version:" -ForegroundColor Yellow
Get-Content "$StagingPath\staging-version.txt"
Write-Host ""
