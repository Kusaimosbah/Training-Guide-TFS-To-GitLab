using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;
using Xunit;

namespace StatusApi.Tests;

public class StatusControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public StatusControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetStatus_ReturnsOkWithStatusObject()
    {
        // Act
        var response = await _client.GetAsync("/api/status");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var content = await response.Content.ReadAsStringAsync();
        var jsonDoc = JsonDocument.Parse(content);
        
        Assert.True(jsonDoc.RootElement.TryGetProperty("status", out var statusProp));
        Assert.Equal("ok", statusProp.GetString());
        
        Assert.True(jsonDoc.RootElement.TryGetProperty("version", out var versionProp));
        Assert.NotNull(versionProp.GetString());
    }

    [Fact]
    public async Task GetStatus_ReturnsVersion()
    {
        // Act
        var response = await _client.GetAsync("/api/status");
        var content = await response.Content.ReadAsStringAsync();
        var jsonDoc = JsonDocument.Parse(content);

        // Assert
        Assert.True(jsonDoc.RootElement.TryGetProperty("version", out var versionProp));
        Assert.Equal("1.0.0", versionProp.GetString());
    }

    [Fact]
    public async Task HealthCheck_ReturnsHealthy()
    {
        // Act
        var response = await _client.GetAsync("/api/status/health");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var content = await response.Content.ReadAsStringAsync();
        var jsonDoc = JsonDocument.Parse(content);
        
        Assert.True(jsonDoc.RootElement.TryGetProperty("status", out var statusProp));
        Assert.Equal("healthy", statusProp.GetString());
    }

    [Fact]
    public async Task GetVersion_ReturnsVersionInfo()
    {
        // Act
        var response = await _client.GetAsync("/api/status/version");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var content = await response.Content.ReadAsStringAsync();
        var jsonDoc = JsonDocument.Parse(content);
        
        Assert.True(jsonDoc.RootElement.TryGetProperty("version", out var versionProp));
        Assert.Equal("1.0.0", versionProp.GetString());
        
        Assert.True(jsonDoc.RootElement.TryGetProperty("buildDate", out var buildDateProp));
        Assert.NotNull(buildDateProp.GetString());
    }

    [Fact]
    public async Task GetStatus_ReturnsTimestamp()
    {
        // Act
        var response = await _client.GetAsync("/api/status");
        var content = await response.Content.ReadAsStringAsync();
        var jsonDoc = JsonDocument.Parse(content);

        // Assert
        Assert.True(jsonDoc.RootElement.TryGetProperty("timestamp", out var timestampProp));
        var timestamp = timestampProp.GetDateTime();
        Assert.True(timestamp <= DateTime.UtcNow);
        Assert.True(timestamp >= DateTime.UtcNow.AddMinutes(-1));
    }
}
