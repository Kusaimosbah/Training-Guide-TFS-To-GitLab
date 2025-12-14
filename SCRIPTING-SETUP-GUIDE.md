# Scripting Environment Setup Guide

## Overview
This workshop provides automation scripts in **both PowerShell (.ps1) and Bash (.sh)** to support Windows, Linux, and macOS environments.

---

## 🖥️ Choose Your Scripting Environment

### Option 1: PowerShell Core (Recommended for .NET Developers) ✅

**PowerShell Core 7+** is cross-platform and works on Windows, Linux, and macOS. It's the modern standard for .NET automation.

#### Windows Installation
PowerShell 7+ is included with Windows 10/11 or can be installed via:
```powershell
winget install Microsoft.PowerShell
```

#### Linux Installation (Ubuntu/Debian)
```bash
# Update package list
sudo apt-get update

# Install prerequisites
sudo apt-get install -y wget apt-transport-https software-properties-common

# Download Microsoft repository GPG keys
wget -q "https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb"

# Register the Microsoft repository
sudo dpkg -i packages-microsoft-prod.deb

# Install PowerShell
sudo apt-get update
sudo apt-get install -y powershell

# Verify installation
pwsh --version
```

#### macOS Installation
```bash
# Using Homebrew
brew install --cask powershell

# Verify installation
pwsh --version
```

#### Running PowerShell Scripts
```bash
# Make script executable (Linux/Mac)
chmod +x deploy.ps1

# Run with pwsh command
pwsh ./deploy.ps1 -Version "1.0.0"

# Or start PowerShell session first
pwsh
PS> ./deploy.ps1 -Version "1.0.0"
```

---

### Option 2: Bash (Native on Linux/macOS)

Bash is pre-installed on most Linux distributions and macOS. Windows users can use WSL (Windows Subsystem for Linux) or Git Bash.

#### Windows - WSL Installation
```powershell
# Install WSL 2
wsl --install

# Or install specific distribution
wsl --install -d Ubuntu

# Restart computer, then verify
wsl --version
```

#### Windows - Git Bash (Alternative)
Git Bash comes with Git for Windows: https://git-scm.com/downloads

#### Running Bash Scripts
```bash
# Make script executable
chmod +x deploy.sh

# Run the script
./deploy.sh "1.0.0" "./publish" "./staging"

# Or explicitly with bash
bash ./deploy.sh
```

---

## 📋 Script Comparison

### PowerShell Scripts (.ps1)
- **Syntax**: PowerShell cmdlet-based (`Write-Host`, `Test-Path`, `Copy-Item`)
- **Parameters**: Named parameters with defaults
  ```powershell
  pwsh deploy.ps1 -Version "1.0.0" -SourcePath "./publish"
  ```
- **Cross-platform**: Works on Windows, Linux, macOS with PowerShell Core
- **Best for**: .NET developers, Windows environments, rich object manipulation

### Bash Scripts (.sh)
- **Syntax**: Standard Unix commands (`echo`, `[ -d ]`, `cp`)
- **Parameters**: Positional arguments
  ```bash
  ./deploy.sh "1.0.0" "./publish" "./staging"
  ```
- **Native on**: Linux, macOS, WSL
- **Best for**: Linux/Unix environments, CI/CD pipelines, lightweight automation

---

## 🔧 Script Files in This Workshop

| Lab | PowerShell (.ps1) | Bash (.sh) | Purpose |
|-----|-------------------|------------|---------|
| **Lab 1** | `migrate-all.ps1` | `migrate-all.sh` | Batch TFS migration |
| **Lab 5** | `deploy.ps1`, `rollback.ps1` | `deploy.sh`, `rollback.sh` | Deployment automation |
| **Lab 6** | `deploy.ps1`, `rollback.ps1` | `deploy.sh`, `rollback.sh` | Deployment automation |
| **Lab 7** | `deploy.ps1`, `rollback.ps1` | `deploy.sh`, `rollback.sh` | Rollback procedures |
| **Lab 8** | `deploy.ps1`, `rollback.ps1` | `deploy.sh`, `rollback.sh` | API deployment |
| **Lab 9** | `deploy.ps1`, `rollback.ps1` | `deploy.sh`, `rollback.sh` | API deployment |
| **Lab 10** | `deploy.ps1`, `rollback.ps1` | `deploy.sh`, `rollback.sh` | Production deployment |

**Both script versions provide identical functionality** - choose based on your preference and environment.

---

## 🎯 Quick Start Examples

### Deploy Application (PowerShell)
```powershell
# Build application
dotnet publish src/WebApi/WebApi.csproj -c Release -o ./publish

# Deploy to staging
pwsh ./deploy.ps1 -Version "1.0.0" -SourcePath "./publish" -StagingPath "./staging"

# Rollback if needed
pwsh ./rollback.ps1 -StagingPath "./staging" -BackupPath "./staging-backup"
```

### Deploy Application (Bash)
```bash
# Build application
dotnet publish src/WebApi/WebApi.csproj -c Release -o ./publish

# Deploy to staging
./deploy.sh "1.0.0" "./publish" "./staging"

# Rollback if needed
./rollback.sh "./staging" "./staging-backup"
```

---

## ✅ Verification

### Test PowerShell Installation
```powershell
# Check version (should be 7.0+)
pwsh --version

# Test script execution
pwsh -Command "Write-Host 'PowerShell is working!' -ForegroundColor Green"
```

### Test Bash Installation
```bash
# Check version
bash --version

# Test script execution
bash -c "echo -e '\033[0;32mBash is working!\033[0m'"
```

---

## 🚨 Common Issues

### PowerShell: Execution Policy Error (Windows)
```powershell
# If you see "cannot be loaded because running scripts is disabled"
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
```

### Bash: Permission Denied
```bash
# Make script executable
chmod +x deploy.sh rollback.sh migrate-all.sh

# Verify permissions
ls -l *.sh
```

### WSL: Line Ending Issues
```bash
# Convert Windows line endings (CRLF) to Unix (LF)
dos2unix deploy.sh rollback.sh

# Or use sed
sed -i 's/\r$//' deploy.sh
```

---

## 📝 Recommendation for This Workshop

**For .NET developers transitioning from TFS:**

1. **Primary recommendation**: Use **PowerShell Core** (pwsh)
   - Familiar to Windows/.NET developers
   - Works everywhere (Windows, Linux, macOS)
   - Rich .NET integration
   - Industry standard for .NET automation

2. **Alternative**: Use **Bash** if you prefer
   - Native on Linux/macOS
   - Lighter weight
   - Standard in CI/CD pipelines
   - Good for Unix-style environments

**Both options are fully supported in all labs!** Choose what works best for your environment.

---

## 🔗 Additional Resources

- **PowerShell Documentation**: https://learn.microsoft.com/powershell/
- **PowerShell Core GitHub**: https://github.com/PowerShell/PowerShell
- **Bash Guide**: https://www.gnu.org/software/bash/manual/
- **WSL Documentation**: https://learn.microsoft.com/windows/wsl/
- **Git Bash**: https://git-scm.com/downloads
