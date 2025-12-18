using Microsoft.AspNetCore.Mvc;

namespace CapstoneApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    private readonly ILogger<StatusController> _logger;

    public StatusController(ILogger<StatusController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetStatus()
    {
        var status = new
        {
            status = "ok",
            version = "1.0.0",
            timestamp = DateTime.UtcNow,
            environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"
        };

        _logger.LogInformation("Status check - Version: {Version}", status.version);
        return Ok(status);
    }
}
