#!/bin/bash
# Deploy to Staging Script (Bash)
# This script simulates deployment to a staging environment

# Default parameters
VERSION="${1:-1.0.0}"
SOURCE_PATH="${2:-./publish}"
STAGING_PATH="${3:-./staging}"

# Colors for output
CYAN='\033[0;36m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

echo -e "${CYAN}=========================================${NC}"
echo -e "${CYAN} Deploying to Staging Environment${NC}"
echo -e "${CYAN}=========================================${NC}"
echo ""

# Create staging directory if it doesn't exist
if [ ! -d "$STAGING_PATH" ]; then
    mkdir -p "$STAGING_PATH"
    echo -e "${GREEN}✓ Created staging directory${NC}"
fi

# Backup current deployment if exists
if [ -f "$STAGING_PATH/WebApi.dll" ]; then
    BACKUP_PATH="./staging-backup"
    if [ -d "$BACKUP_PATH" ]; then
        rm -rf "$BACKUP_PATH"
    fi
    cp -r "$STAGING_PATH" "$BACKUP_PATH"
    echo -e "${GREEN}✓ Backed up current deployment${NC}"
fi

# Copy new files to staging
echo -e "${YELLOW}Copying application files...${NC}"
cp -r "$SOURCE_PATH"/* "$STAGING_PATH"/
echo -e "${GREEN}✓ Application files copied${NC}"

# Create version file
DEPLOYMENT_TIME=$(date -u +"%Y-%m-%d %H:%M:%S UTC")
MACHINE_NAME=$(hostname)
VERSION_INFO="Version: $VERSION
Deployed: $DEPLOYMENT_TIME
Environment: Staging
Machine: $MACHINE_NAME"

echo "$VERSION_INFO" > "$STAGING_PATH/staging-version.txt"
echo -e "${GREEN}✓ Version file created${NC}"

echo ""
echo -e "${CYAN}=========================================${NC}"
echo -e "${GREEN} Deployment Complete!${NC}"
echo -e "${CYAN}=========================================${NC}"
echo ""
echo -e "${YELLOW}Deployment Details:${NC}"
cat "$STAGING_PATH/staging-version.txt"
echo ""
echo -e "${CYAN}Staging URL: http://localhost:5000${NC}"
echo -e "${CYAN}Health Check: http://localhost:5000/api/status/health${NC}"
