using Microsoft.AspNetCore.Mvc;
using CapstoneApi.Services;

namespace CapstoneApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalcController : ControllerBase
{
    private readonly CalculatorService _calculator;
    private readonly ILogger<CalcController> _logger;

    public CalcController(CalculatorService calculator, ILogger<CalcController> logger)
    {
        _calculator = calculator;
        _logger = logger;
    }

    /// <summary>
    /// GET: api/calc/add?a=5&b=3
    /// </summary>
    [HttpGet("add")]
    public IActionResult Add([FromQuery] int a, [FromQuery] int b)
    {
        try
        {
            var result = _calculator.Add(a, b);
            _logger.LogInformation("Add operation: {A} + {B} = {Result}", a, b, result);
            return Ok(new { operation = "add", a, b, result });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Add operation");
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// GET: api/calc/subtract?a=10&b=3
    /// </summary>
    [HttpGet("subtract")]
    public IActionResult Subtract([FromQuery] int a, [FromQuery] int b)
    {
        try
        {
            var result = _calculator.Subtract(a, b);
            _logger.LogInformation("Subtract operation: {A} - {B} = {Result}", a, b, result);
            return Ok(new { operation = "subtract", a, b, result });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Subtract operation");
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// GET: api/calc/multiply?a=4&b=5
    /// </summary>
    [HttpGet("multiply")]
    public IActionResult Multiply([FromQuery] int a, [FromQuery] int b)
    {
        try
        {
            var result = _calculator.Multiply(a, b);
            _logger.LogInformation("Multiply operation: {A} * {B} = {Result}", a, b, result);
            return Ok(new { operation = "multiply", a, b, result });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Multiply operation");
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// GET: api/calc/divide?a=10&b=2
    /// </summary>
    [HttpGet("divide")]
    public IActionResult Divide([FromQuery] int a, [FromQuery] int b)
    {
        try
        {
            var result = _calculator.Divide(a, b);
            _logger.LogInformation("Divide operation: {A} / {B} = {Result}", a, b, result);
            return Ok(new { operation = "divide", a, b, result });
        }
        catch (DivideByZeroException ex)
        {
            _logger.LogWarning("Division by zero attempted");
            return BadRequest(new { error = "Cannot divide by zero" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Divide operation");
            return BadRequest(new { error = ex.Message });
        }
    }
}
