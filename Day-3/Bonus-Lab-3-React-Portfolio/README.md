# Developer Portfolio - React + Vite

A modern developer portfolio web application built with React and Vite, deployed automatically to GitLab Pages using CI/CD pipelines.

## Features

- **React 18** - Modern UI library
- **Vite** - Next-generation frontend build tool
- **Responsive Design** - Works on desktop, tablet, and mobile
- **Tab-based Navigation** - About, Projects, and Skills sections
- **Automated CI/CD** - Build and deploy with every commit to main
- **GitLab Pages** - Free hosting with automatic HTTPS

## Getting Started

### Local Development

```bash
# Install dependencies
npm install

# Start development server
npm run dev

# Open browser to http://localhost:5173
```

### Build

```bash
# Build for production
npm run build

# Output generated in dist/ directory
```

### Preview Production Build

```bash
npm run preview
```

## Project Structure

```
src/
├── main.jsx       # React entry point
├── App.jsx        # Main App component
├── App.css        # App styling
├── index.css      # Global styling
package.json       # Dependencies and scripts
vite.config.js     # Vite configuration
index.html         # HTML template
.gitlab-ci.yml     # CI/CD pipeline
```

## Deployment

This project is automatically deployed to GitLab Pages when pushed to the `main` branch.

**Live URL:** `https://your-username.gitlab.io/training-guide-tfs-to-gitlab/`

The CI/CD pipeline:
1. Installs dependencies
2. Validates code
3. Builds the React app with Vite
4. Deploys to GitLab Pages

## Technologies

- **Frontend**: React 18, JSX
- **Build Tool**: Vite 5
- **Styling**: CSS3 with CSS Variables
- **Hosting**: GitLab Pages
- **CI/CD**: GitLab CI/CD

## Customization

Edit `vite.config.js` to change the base URL if deploying under a different path:

```javascript
export default defineConfig({
  base: '/your-project-name/',
})
```

## License

This is a training project for the Git Enablement Program for .NET Developers Transitioning from TFS to GitLab.
