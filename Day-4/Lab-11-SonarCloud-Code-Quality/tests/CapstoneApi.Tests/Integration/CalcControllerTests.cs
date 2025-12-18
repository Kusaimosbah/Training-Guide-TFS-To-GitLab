using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;
using Xunit;

namespace CapstoneApi.Tests.Integration;

public class CalcControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public CalcControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Add_ValidNumbers_ReturnsCorrectResult()
    {
        // Act
        var response = await _client.GetAsync("/api/calc/add?a=5&b=3");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(content);
        var result = doc.RootElement.GetProperty("result").GetInt32();
        
        Assert.Equal(8, result);
    }

    [Fact]
    public async Task Subtract_ValidNumbers_ReturnsCorrectResult()
    {
        // Act
        var response = await _client.GetAsync("/api/calc/subtract?a=10&b=3");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(content);
        var result = doc.RootElement.GetProperty("result").GetInt32();
        
        Assert.Equal(7, result);
    }

    [Fact]
    public async Task Multiply_ValidNumbers_ReturnsCorrectResult()
    {
        // Act
        var response = await _client.GetAsync("/api/calc/multiply?a=4&b=5");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(content);
        var result = doc.RootElement.GetProperty("result").GetInt32();
        
        Assert.Equal(20, result);
    }

    [Fact]
    public async Task Divide_ValidNumbers_ReturnsCorrectResult()
    {
        // Act
        var response = await _client.GetAsync("/api/calc/divide?a=10&b=2");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(content);
        var result = doc.RootElement.GetProperty("result").GetDouble();
        
        Assert.Equal(5.0, result);
    }

    [Fact]
    public async Task Divide_ByZero_ReturnsBadRequest()
    {
        // Act
        var response = await _client.GetAsync("/api/calc/divide?a=10&b=0");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("error", content);
    }
}
