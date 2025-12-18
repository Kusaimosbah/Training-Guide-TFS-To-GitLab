using Microsoft.AspNetCore.Mvc;

namespace CapstoneApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InfoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<InfoController> _logger;

    public InfoController(IConfiguration configuration, ILogger<InfoController> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetInfo()
    {
        var info = new
        {
            applicationName = "Capstone API - TFS to GitLab Migration Lab",
            version = "1.0.0",
            description = "Full end-to-end API demonstrating GitLab CI/CD workflow",
            features = new[]
            {
                "Status monitoring",
                "Calculator operations",
                "Automated testing",
                "CI/CD pipeline",
                "Staging deployment",
                "Rollback capability"
            },
            endpoints = new[]
            {
                "/api/status",
                "/api/calc/add",
                "/api/calc/subtract",
                "/api/calc/multiply",
                "/api/calc/divide",
                "/api/info"
            },
            buildInfo = new
            {
                framework = ".NET 8.0",
                server = Environment.MachineName,
                startTime = DateTime.UtcNow
            }
        };

        _logger.LogInformation("Info endpoint accessed");
        return Ok(info);
    }

    [HttpGet("health")]
    public IActionResult HealthCheck()
    {
        return Ok(new 
        { 
            status = "healthy",
            timestamp = DateTime.UtcNow,
            uptime = Environment.TickCount64 / 1000 // seconds
        });
    }
}
