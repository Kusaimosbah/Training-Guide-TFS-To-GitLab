# Git Enablement Program for .NET Developers

**Transitioning from TFS to GitLab - Complete Training Materials**

This repository contains comprehensive training materials for .NET developers transitioning from Team Foundation Server (TFS) to GitLab. The program covers Git fundamentals, GitLab features, CI/CD pipelines, and modern DevOps practices.

## 📋 Workshop Overview

This 4-day intensive training program includes 11 hands-on labs designed to build practical skills progressively. Each lab includes:
- Detailed HTML-based lab guides with step-by-step instructions
- Complete .NET 8 project templates
- GitLab CI/CD configuration files with comprehensive comments
- xUnit test projects with test reporting configured

## 🗂️ Repository Structure

```
Labs/
├── Day-1/                          # Git Fundamentals & Migration
│   ├── Lab-0-Git-Fundamentals/     # Basic Git commands and concepts
│   └── Lab-1-TFS-Migration/        # Migrating from TFS to Git using git-tfs
│
├── Day-2/                          # Branching & CI/CD Basics
│   ├── Lab-2-Feature-Branching/    # Feature branch workflow
│   ├── Lab-3-Merge-Requests/       # Creating and managing merge requests
│   └── Lab-4-CI-CD-Testing/        # CI/CD pipelines with automated testing
│
├── Day-3/                          # Advanced CI/CD
│   ├── Lab-5-CI-CD-Pipelines/      # Multi-stage pipelines
│   ├── Lab-6-Deployment/           # Deployment strategies
│   └── Lab-7-Rollback/             # Rollback procedures
│
└── Day-4/                          # Production-Ready Practices
    ├── Lab-8-API-Development/      # Building REST APIs
    ├── Lab-9-Integration-Testing/  # Integration testing strategies
    └── Lab-10-Production-Capstone/ # Complete production workflow
```

## 🚀 Getting Started

### Prerequisites

- **.NET 8 SDK** - [Download](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Git** - [Download](https://git-scm.com/downloads)
- **GitLab Account** - Free account at [GitLab.com](https://gitlab.com)
- **Code Editor** - Visual Studio 2022, VS Code, or Rider
- **git-tfs Tool** (for Lab 1) - [Installation Guide](https://github.com/git-tfs/git-tfs)

### Quick Start

1. **Clone this repository:**
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
- **Lab 11**: SonarCloud code quality & security scanning (SAST)
- **Lab 12**: Security scanning (SAST + DAST) & GitLab Variables mastery

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
