using Microsoft.AspNetCore.Mvc;

namespace StatusApi.Controllers;

/// <summary>
/// Status API Controller - provides health and version information
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    private readonly ILogger<StatusController> _logger;
    private readonly IConfiguration _configuration;

    public StatusController(ILogger<StatusController> logger, IConfiguration _configuration)
    {
        _logger = logger;
        this._configuration = _configuration;
    }

    /// <summary>
    /// GET: api/status
    /// Returns application status and version
    /// </summary>
    [HttpGet]
    public IActionResult GetStatus()
    {
        var status = new
        {
            status = "ok",
            version = "1.0.0",
            timestamp = DateTime.UtcNow,
            environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production",
            machineName = Environment.MachineName
        };

        _logger.LogInformation("Status check requested - Version: {Version}", status.version);
        
        return Ok(status);
    }

    /// <summary>
    /// GET: api/status/health
    /// Simple health check endpoint
    /// </summary>
    [HttpGet("health")]
    public IActionResult HealthCheck()
    {
        return Ok(new { status = "healthy", timestamp = DateTime.UtcNow });
    }

    /// <summary>
    /// GET: api/status/version
    /// Returns only version information
    /// </summary>
    [HttpGet("version")]
    public IActionResult GetVersion()
    {
        return Ok(new { version = "1.0.0", buildDate = "2025-12-07" });
    }
}
