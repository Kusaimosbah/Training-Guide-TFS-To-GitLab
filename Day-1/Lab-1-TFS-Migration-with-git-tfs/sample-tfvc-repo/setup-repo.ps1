# Initialize Sample TFVC Repository with History
# This script creates a Git repository with commits simulating TFS changesets

Write-Host "Initializing sample TFVC repository..." -ForegroundColor Green

# Initialize Git repository
git init
git config user.name "TFS Migration User"
git config user.email "tfsmigration@company.com"

# Commit 1: Initial project setup (only .csproj and .gitignore)
git add .gitignore LegacyApp.csproj
git commit -m "TFS Changeset 1001: Initial project setup" --date="2024-01-15T10:00:00"

# Commit 2: Add Calculator class
git add Calculator.cs
git commit -m "TFS Changeset 1002: Add Calculator class with basic operations" --date="2024-02-10T14:30:00"

# Commit 3: Add main program
git add Program.cs
git commit -m "TFS Changeset 1003: Implement main program using Calculator" --date="2024-03-05T09:15:00"

# Commit 4: Add documentation
git add README.md
git commit -m "TFS Changeset 1004: Add project documentation and usage instructions" --date="2024-04-20T16:45:00"

Write-Host "`n✅ Sample repository initialized with 4 commits!" -ForegroundColor Green
Write-Host "`nView history with:" -ForegroundColor Yellow
Write-Host "  git log --oneline --all" -ForegroundColor Cyan
Write-Host "`nThis simulates a TFVC repository with 4 changesets ready for migration to GitLab.`n" -ForegroundColor White
