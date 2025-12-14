#!/bin/bash
# Rollback Script (Bash)
# This script rolls back to the previous deployment

# Default parameters
STAGING_PATH="${1:-./staging}"
BACKUP_PATH="${2:-./staging-backup}"

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
CYAN='\033[0;36m'
NC='\033[0m' # No Color

echo -e "${RED}=========================================${NC}"
echo -e "${RED} Rolling Back Staging Deployment${NC}"
echo -e "${RED}=========================================${NC}"
echo ""

# Check if backup exists
if [ ! -d "$BACKUP_PATH" ]; then
    echo -e "${RED}✗ No backup found to rollback to!${NC}"
    echo -e "${YELLOW}Backup path: $BACKUP_PATH${NC}"
    exit 1
fi

echo -e "${GREEN}Found backup deployment${NC}"

# Display current version
if [ -f "$STAGING_PATH/staging-version.txt" ]; then
    echo ""
    echo -e "${YELLOW}Current Version:${NC}"
    cat "$STAGING_PATH/staging-version.txt"
fi

# Display backup version
if [ -f "$BACKUP_PATH/staging-version.txt" ]; then
    echo ""
    echo -e "${YELLOW}Rolling back to:${NC}"
    cat "$BACKUP_PATH/staging-version.txt"
fi

echo ""
echo -e "${YELLOW}Performing rollback...${NC}"

# Stop any running processes (simulated)
echo -e "${CYAN}1. Stopping application...${NC}"

# Remove current deployment
if [ -d "$STAGING_PATH" ]; then
    rm -rf "$STAGING_PATH"
    echo -e "   ${GREEN}✓ Current deployment removed${NC}"
fi

# Restore from backup
echo -e "${CYAN}2. Restoring from backup...${NC}"
cp -r "$BACKUP_PATH" "$STAGING_PATH"
echo -e "   ${GREEN}✓ Backup restored${NC}"

# Update version file
echo -e "${CYAN}3. Updating version info...${NC}"
ROLLBACK_TIME=$(date -u +"%Y-%m-%d %H:%M:%S UTC")
MACHINE_NAME=$(hostname)
ROLLBACK_INFO="

ROLLBACK PERFORMED
Rollback Time: $ROLLBACK_TIME
Machine: $MACHINE_NAME"

echo "$ROLLBACK_INFO" >> "$STAGING_PATH/staging-version.txt"
echo -e "   ${GREEN}✓ Version info updated${NC}"

# Restart application (simulated)
echo -e "${CYAN}4. Restarting application...${NC}"
echo -e "   ${GREEN}✓ Application restarted (simulated)${NC}"

echo ""
echo -e "${GREEN}=========================================${NC}"
echo -e "${GREEN} Rollback Complete!${NC}"
echo -e "${GREEN}=========================================${NC}"
echo ""
echo -e "${YELLOW}Current Version:${NC}"
cat "$STAGING_PATH/staging-version.txt"
echo ""
