# Git Enablement Program for .NET Developers

**Transitioning from TFS to GitLab - Complete 4-Day Training (12 Labs)**

This repository contains **production-ready training materials** for .NET developers transitioning from Team Foundation Server (TFS) to GitLab. The program covers Git fundamentals, GitLab features, CI/CD pipelines, code quality scanning, and security best practices.

## 📋 Training Program Overview

**4-Day Intensive Bootcamp | 12 Core Labs + 3 Bonus Labs | Enterprise-Grade Practices**

Each lab includes:
- ✅ Detailed HTML lab guides with step-by-step instructions
- ✅ Complete .NET 8 project templates (self-contained)
- ✅ Production-ready GitLab CI/CD pipelines (YAML)
- ✅ xUnit test projects with JUnit reporting
- ✅ Deployment scripts for Ubuntu servers
- ✅ Security scanning (SonarCloud, GitLeak)

---

## 🗂️ Complete Repository Structure

```
Labs/
├── Day-1/                                    # Git Fundamentals & Migration
│   ├── Lab-0-Git-Fundamentals/              # ✅ Basic Git commands
│   └── Lab-1-TFS-Migration-with-git-tfs/    # ✅ Migrate from TFS to Git
│
├── Day-2/                                    # Branching & Collaboration
│   ├── Lab-2-Feature-Branching/             # ✅ Feature branch workflow
│   ├── Lab-3-Merge-Requests/                # ✅ Code review process
│   └── Lab-4-CI-CD-Testing/                 # ✅ Automated testing in CI/CD
│
├── Day-3/                                    # Pipelines & Deployment
│   ├── Lab-5-CI-CD-Pipelines/               # ✅ Multi-stage pipelines
│   ├── Bonus-Lab-1-Variables/               # ✅ Advanced CI/CD variables
│   ├── Bonus-Lab-2-Game/                    # ✅ Game project (CI/CD demo)
│   └── Bonus-Lab-3-React-Portfolio/         # ✅ React portfolio (frontend)
│
└── Day-4/                                    # Production & Security
    ├── Lab-8-API-Development/               # ✅ Multi-tenant REST APIs
    ├── Lab-9-Integration-Testing/           # ✅ Integration test strategies
    ├── Lab-10-Production-Capstone/          # ✅ Staging → Production gates
    ├── Lab-11-SonarCloud-Code-Quality/      # ✅ Code quality scanning (SAST)
    └── Lab-12-GitLeak-Security-Scanning/    # ✅ Secret detection (GitLeak)
```

---

## 📊 Training Statistics

| Metric | Count |
|--------|-------|
| **Total Days** | 4 |
| **Core Labs** | 12 |
| **Bonus Labs** | 3 |
| **Total Hours** | 32 (estimated) |
| **CI/CD Pipelines** | 12+ production-ready |
| **Technologies** | .NET 8, GitLab, Docker, SonarCloud, GitLeak |
| **Test Coverage** | 100+ automated tests |
| **Documentation** | 15+ interactive HTML guides |

---

## 🚀 Day-by-Day Breakdown

### **Day 1: Git Fundamentals & TFS Migration** 
*Learn Git basics and migrate from TFS*
- Lab-0: Git commands, workflows, conflict resolution
- Lab-1: TFS to Git migration using git-tfs tool
- **Skills**: Clone, branch, commit, merge, history

### **Day 2: Branching & CI/CD Basics**
*Master collaborative workflows*
- Lab-2: Feature branching with protection rules
- Lab-3: Merge requests, code review, approvals
- Lab-4: CI/CD basics - build, test, artifact management
- **Skills**: Feature branches, MR workflows, automated testing

### **Day 3: Advanced Pipelines & Deployment**
*Build production-ready pipelines*
- Lab-5: Multi-stage pipelines with caching
- Bonus-1: CI/CD variables, secrets management
- Bonus-2: Game project CI/CD demo
- Bonus-3: React portfolio with Node.js pipeline
- **Skills**: Pipelines, environment variables, artifact management

### **Day 4: Production-Grade Security**
*Enterprise-level practices*
- Lab-8: Multi-tenant API development
- Lab-9: Integration testing strategies
- Lab-10: Staging → Production deployment with approval gates
- Lab-11: Code quality with SonarCloud (SAST)
- Lab-12: Secret detection with GitLeak
- **Skills**: Production deployments, security scanning, quality gates

---

## 🛠️ Key Technologies & Tools

| Technology | Purpose | Version |
|-----------|---------|---------|
| **.NET** | Backend framework | 8.0 SDK |
| **GitLab** | Version control & CI/CD | Cloud/Self-hosted |
| **Docker** | Container runtime | Latest |
| **Ubuntu** | Deployment server | 20.04+ |
| **SonarCloud** | Code quality scanning | Cloud |
| **GitLeak** | Secret detection | v8.18.2 |
| **xUnit** | Unit testing framework | Latest |
| **React** | Frontend framework | Latest (Bonus) |

---

## 📥 Getting Started

### Prerequisites

✅ **Required:**
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Git](https://git-scm.com/downloads)
- [GitLab Account](https://gitlab.com) (free)
- Code Editor (VS Code, Visual Studio 2022, or JetBrains Rider)

✅ **Optional (for TFS migration):**
- [git-tfs Tool](https://github.com/git-tfs/git-tfs)

✅ **Optional (for Lab 12+ deployment):**
- Ubuntu server (or any Linux)
- SSH access configured

### Quick Start

```bash
# 1. Clone this repository
git clone https://github.com/Kusaimosbah/Training-Guide-TFS-To-GitLab.git
cd Labs

# 2. Start with Day 1
cd Day-1/Lab-0-Git-Fundamentals
open lab-guide.html  # Read the lab guide

# 3. Follow step-by-step instructions in each lab
# Each lab includes sample code and CI/CD configurations
```

---

## 📖 How to Use This Training

### For Each Lab:

1. **Read the Lab Guide** (`lab-guide.html`)
   - Overview and learning objectives
   - Step-by-step instructions
   - Example outputs and troubleshooting

2. **Examine the Code** (`src/` and `tests/`)
   - .NET 8 project files
   - Test projects with xUnit
   - Configuration files

3. **Study the CI/CD Configuration** (`.gitlab-ci.yml`)
   - Production-ready pipeline
   - Multi-stage deployments
   - Security scanning integration

4. **Execute on Your GitLab Instance**
   - Create a new project in GitLab
   - Push the lab code
   - Watch the pipeline run automatically

---

## 🔑 Key Learning Outcomes

After completing this training, you will be able to:

✅ **Version Control**
- Migrate from TFS to Git using multiple strategies
- Master branching, merging, and conflict resolution
- Use advanced Git workflows (feature branches, rebasing)

✅ **GitLab Features**
- Set up project pipelines and runners
- Configure merge request workflows and approvals
- Manage CI/CD variables and secrets securely

✅ **CI/CD Pipelines**
- Design multi-stage pipelines for different environments
- Implement automated testing and artifact management
- Deploy to production with approval gates

✅ **Security & Quality**
- Integrate code quality scanning (SonarCloud)
- Detect secrets and vulnerabilities (GitLeak)
- Enforce security gates in pipelines

✅ **Deployment & DevOps**
- Deploy .NET applications to Linux servers
- Implement rollback strategies
- Manage multi-environment deployments (staging, production)

---

## 🐛 Troubleshooting

### Common Issues

**GitLab Runner not picking up jobs?**
- Verify runner tag matches in `.gitlab-ci.yml`
- Check runner logs: `gitlab-runner --debug run`

**Tests failing in CI but passing locally?**
- Ensure test data/mocks are environment-agnostic
- Check path separators (use `/` not `\` in scripts)

**Deployment failing?**
- Verify SSH credentials configured in GitLab CI/CD Variables
- Check server firewall rules and open ports
- Ensure artifact paths are correct

**SonarCloud not uploading results?**
- Verify `SONAR_TOKEN` is set and not expired
- Check branch name is `main` or configured in `sonar.branch.name`

For detailed troubleshooting, see individual lab guides.

---

## 📚 Resources

- [GitLab Documentation](https://docs.gitlab.com)
- [.NET 8 Documentation](https://learn.microsoft.com/dotnet/core/)
- [Git Book](https://git-scm.com/book/en/v2)
- [SonarCloud Documentation](https://sonarcloud.io/documentation/)
- [GitLeak GitHub](https://github.com/gitleaks/gitleaks)

---

## 📝 Lab-Specific Notes

### Lab-8 through Lab-12 (Day 4)

These labs require a **GitLab Runner** configured:
```bash
# On your Ubuntu server
curl -L https://packages.gitlab.com/install/repositories/runner/gitlab-runner/script.deb.sh | bash
sudo apt-get install gitlab-runner
sudo gitlab-runner register  # Follow prompts
```

Once registered, pipelines will execute automatically on code push.

---

## ✨ Highlights

🌟 **Production-Ready**: All pipelines follow enterprise best practices
🌟 **Progressive Learning**: Difficulty increases gradually across 4 days
🌟 **Hands-On**: Every lab has working code to execute immediately
🌟 **Self-Contained**: All builds are Linux x64 self-contained binaries
🌟 **Secure**: Includes security scanning and secret detection
🌟 **Well-Documented**: Each lab has comprehensive HTML guides

---

## 📄 License

This training material is provided as-is for educational purposes.

---

## 🤝 Support

For questions or issues:
1. Check the troubleshooting section in lab guides
2. Review individual lab README files (if present)
3. Check GitLab CI/CD job logs for specific errors
4. Consult referenced documentation links above

---

**Last Updated**: December 2025
**Status**: ✅ Production Ready - All 12 Labs Tested & Working
**Repository**: [Training-Guide-TFS-To-GitLab](https://github.com/Kusaimosbah/Training-Guide-TFS-To-GitLab)1. **Clone this repository:**
   ```bash
   git clone https://github.com/Kusaimosbah/Training-Guide-TFS-To-GitLab.git
   cd Training-Guide-TFS-To-GitLab/Labs
   ```

2. **Navigate to Day-1 and open the first lab guide:**
   ```bash
   cd Day-1/Lab-0-Git-Fundamentals
   # Open lab-guide.html in your browser
   ```

3. **Follow the lab guides in sequential order** - Each lab builds upon concepts from previous labs.

## 📚 Lab Descriptions

### Day 1: Git Fundamentals & Migration
- **Lab 0**: Git basics - cloning, branching, committing, merging
- **Lab 1**: Migrating a TFS repository to Git using git-tfs tool

### Day 2: Feature Branching & CI/CD Basics
- **Lab 2**: Implementing feature branch workflow with a Calculator app
- **Lab 3**: Creating merge requests and code review processes
- **Lab 4**: Setting up CI/CD pipelines with automated xUnit testing

### Day 3: Advanced CI/CD & Deployment
- **Lab 5**: Multi-stage CI/CD pipelines (build, test, deploy)
- **Lab 6**: Deployment strategies for .NET Web APIs
- **Lab 7**: Implementing rollback procedures for failed deployments

### Day 4: Production-Ready Development
- **Lab 8**: Building REST APIs with ASP.NET Core
- **Lab 9**: Integration testing with WebApplicationFactory
- **Lab 10**: **Production Capstone** - Complete workflow from TFS migration to production deployment
- **Lab 11**: **SonarCloud Code Quality & Security** - Static Application Security Testing (SAST) with professional code quality analysis
- **Lab 12**: **Security Scanning & Variables Mastery** - SAST vs DAST comparison, GitLab Variables (global, masked, protected), dependency scanning with dotnet-audit, and secret detection

## 🧪 Test Reporting

All labs include GitLab CI/CD test reporting configuration. When you push your code to GitLab, the pipelines will:
- Run automated tests
- Generate JUnit XML test reports
- Display test results in the GitLab UI
- Show test counts and individual test status in merge requests

**Configuration includes:**
- `JunitXml.TestLogger` package for test report generation
- Artifact collection with 7-day retention
- Test reports visible in pipeline results and merge requests

## 📖 Additional Resources

- **Workshop Overview** - `workshop-overview.html` - Complete program agenda
- **Setup Guide** - `SCRIPTING-SETUP-GUIDE.md` - Detailed setup instructions
- **PowerPoint Presentation** - `Git-Gitlab-TFS.pptx` - Training slides
- **Documentation** - Each lab's `.gitlab-ci.yml` file contains detailed inline comments

## 🎯 Learning Objectives

By completing this training program, you will:

1. **Master Git fundamentals** - branching, merging, rebasing, conflict resolution
2. **Understand GitLab features** - merge requests, issues, CI/CD pipelines
3. **Build CI/CD pipelines** - automated build, test, and deployment workflows
4. **Implement testing strategies** - unit tests, integration tests, test reporting
5. **Deploy .NET applications** - deployment strategies, environment management
6. **Handle production scenarios** - rollbacks, monitoring, troubleshooting
7. **Migrate from TFS** - practical migration strategies and tools

## 💡 Tips for Success

1. **Complete labs in order** - Each lab builds on previous concepts
2. **Read all comments** - CI/CD files contain valuable explanations
3. **Experiment freely** - All labs are self-contained and can be reset
4. **Use GitLab features** - Create real merge requests, review pipelines
5. **Test locally first** - Run `dotnet test` before pushing to verify tests pass
6. **Ask questions** - Use GitLab issues to track questions and problems

## 🔧 Troubleshooting

### Common Issues

**Tests not showing in GitLab:**
- Verify `JunitXml.TestLogger` package is installed in the CI pipeline
- Check that `--logger "junit;LogFileName=test-results.xml"` is specified
- Ensure `reports: junit:` section exists in `.gitlab-ci.yml`

**Pipeline failing:**
- Verify .NET 8 SDK is specified: `mcr.microsoft.com/dotnet/sdk:8.0`
- Check that `.gitlab-ci.yml` is in the repository root
- Ensure all file paths are correct in the CI configuration

**Build errors:**
- Run `dotnet restore` before building
- Verify all project references are correct
- Check that NuGet packages are accessible

## 📝 Lab Completion Checklist

- [ ] Day 1: Labs 0-1 (Git Fundamentals & Migration)
- [ ] Day 2: Labs 2-4 (Branching, MRs, CI/CD Testing)
- [ ] Day 3: Labs 5-7 (Pipelines, Deployment, Rollback)
- [ ] Day 4: Labs 8-10 (API Dev, Integration Testing, Capstone)
- [ ] Day 4: Labs 11-12 (SonarCloud SAST, Security Scanning & Variables)

## 🤝 Contributing

If you find issues or have suggestions for improvements:
1. Create a GitLab/GitHub issue describing the problem
2. Include the lab number and specific step
3. Provide error messages or screenshots if applicable

## 📄 License

These training materials are provided for educational purposes.

## 👥 Target Audience

This training is designed for:
- .NET developers currently using TFS/TFVC
- Development teams migrating to GitLab
- Engineers learning Git and modern DevOps practices
- Teams adopting CI/CD pipelines

## 🎓 Next Steps

After completing this training:
1. **Practice regularly** - Use Git and GitLab for all projects
2. **Explore advanced features** - GitLab runners, environments, security scanning
3. **Implement in your team** - Share knowledge and establish workflows
4. **Continuous learning** - GitLab releases new features monthly

---

**Happy Learning! 🚀**

For questions or support, please create an issue in this repository.
