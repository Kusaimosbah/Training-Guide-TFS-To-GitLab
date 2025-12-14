# Deploy to Staging Script (PowerShell)
# This script simulates deployment to a staging environment

param(
    [string]$Version = "1.0.0",
    [string]$SourcePath = "./publish",
    [string]$StagingPath = "./staging"
)

Write-Host "=========================================" -ForegroundColor Cyan
Write-Host " Deploying to Staging Environment" -ForegroundColor Cyan
Write-Host "=========================================" -ForegroundColor Cyan
Write-Host ""

# Create staging directory if it doesn't exist
if (!(Test-Path $StagingPath)) {
    New-Item -ItemType Directory -Path $StagingPath -Force | Out-Null
    Write-Host "✓ Created staging directory" -ForegroundColor Green
}

# Backup current deployment if exists
if (Test-Path "$StagingPath\WebApi.dll") {
    $backupPath = "./staging-backup"
    if (Test-Path $backupPath) {
        Remove-Item -Recurse -Force $backupPath
    }
    Copy-Item -Recurse $StagingPath $backupPath
    Write-Host "✓ Backed up current deployment" -ForegroundColor Green
}

# Copy new files to staging
Write-Host "Copying application files..." -ForegroundColor Yellow
Copy-Item -Path "$SourcePath\*" -Destination $StagingPath -Recurse -Force
Write-Host "✓ Application files copied" -ForegroundColor Green

# Create version file
$deploymentTime = Get-Date -Format "yyyy-MM-dd HH:mm:ss UTC"
$versionInfo = @"
Version: $Version
Deployed: $deploymentTime
Environment: Staging
Machine: $env:COMPUTERNAME
"@

$versionInfo | Out-File -FilePath "$StagingPath\staging-version.txt" -Encoding UTF8
Write-Host "✓ Version file created" -ForegroundColor Green

Write-Host ""
Write-Host "=========================================" -ForegroundColor Cyan
Write-Host " Deployment Complete!" -ForegroundColor Green
Write-Host "=========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Deployment Details:" -ForegroundColor Yellow
Get-Content "$StagingPath\staging-version.txt"
Write-Host ""
Write-Host "Staging URL: http://localhost:5000" -ForegroundColor Cyan
Write-Host "Health Check: http://localhost:5000/api/status/health" -ForegroundColor Cyan
