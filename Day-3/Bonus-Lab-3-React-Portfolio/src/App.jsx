import { useState } from 'react'
import './App.css'

function App() {
  const [activeTab, setActiveTab] = useState('about')

  const projects = [
    {
      id: 1,
      title: 'TFS to GitLab Migration Tool',
      description: 'Built a comprehensive migration tool for transitioning from Team Foundation Server to GitLab.',
      tech: ['Git', 'Python', 'GitLab API'],
      link: '#'
    },
    {
      id: 2,
      title: 'CI/CD Pipeline Framework',
      description: 'Created an automated CI/CD framework with validation, testing, and deployment stages.',
      tech: ['GitLab CI', 'Docker', 'Shell Scripting'],
      link: '#'
    },
    {
      id: 3,
      title: 'Interactive Tetris Game',
      description: 'Developed a web-based Tetris game with responsive design and deployed via GitLab Pages.',
      tech: ['JavaScript', 'HTML5', 'CSS3'],
      link: '#'
    }
  ]

  const skills = [
    { category: 'Version Control', items: ['Git', 'GitLab', 'Team Foundation Server', 'Merge Requests'] },
    { category: 'CI/CD', items: ['GitLab CI/CD', 'Pipeline Design', 'Docker', 'Automated Testing'] },
    { category: 'Frontend', items: ['React', 'JavaScript', 'HTML5', 'CSS3'] },
    { category: 'Backend', items: ['.NET', 'C#', 'Python', 'API Design'] }
  ]

  return (
    <div className="portfolio">
      <header className="header">
        <div className="header-content">
          <h1>Developer Portfolio</h1>
          <p className="subtitle">Git Migration & CI/CD Specialist</p>
        </div>
      </header>

      <nav className="tabs">
        <button 
          className={`tab ${activeTab === 'about' ? 'active' : ''}`}
          onClick={() => setActiveTab('about')}
        >
          About
        </button>
        <button 
          className={`tab ${activeTab === 'projects' ? 'active' : ''}`}
          onClick={() => setActiveTab('projects')}
        >
          Projects
        </button>
        <button 
          className={`tab ${activeTab === 'skills' ? 'active' : ''}`}
          onClick={() => setActiveTab('skills')}
        >
          Skills
        </button>
      </nav>

      <main className="content">
        {activeTab === 'about' && (
          <section className="tab-content">
            <h2>About Me</h2>
            <p>
              I'm a software developer specializing in Git migration and CI/CD pipeline development. 
              With experience transitioning teams from legacy version control systems to modern platforms like GitLab, 
              I help organizations streamline their development workflows.
            </p>
            <p>
              This portfolio was built with React and Vite, then deployed to GitLab Pages using automated CI/CD pipelines. 
              It demonstrates modern web development practices and deployment automation.
            </p>
          </section>
        )}

        {activeTab === 'projects' && (
          <section className="tab-content">
            <h2>Projects</h2>
            <div className="projects-grid">
              {projects.map(project => (
                <div key={project.id} className="project-card">
                  <h3>{project.title}</h3>
                  <p>{project.description}</p>
                  <div className="tech-tags">
                    {project.tech.map(t => (
                      <span key={t} className="tech-tag">{t}</span>
                    ))}
                  </div>
                </div>
              ))}
            </div>
          </section>
        )}

        {activeTab === 'skills' && (
          <section className="tab-content">
            <h2>Skills</h2>
            <div className="skills-grid">
              {skills.map(skill => (
                <div key={skill.category} className="skill-group">
                  <h3>{skill.category}</h3>
                  <ul>
                    {skill.items.map(item => (
                      <li key={item}>{item}</li>
                    ))}
                  </ul>
                </div>
              ))}
            </div>
          </section>
        )}
      </main>

      <footer className="footer">
        <p>Built with React & Vite | Deployed on GitLab Pages | v1.0.0</p>
      </footer>
    </div>
  )
}

export default App
