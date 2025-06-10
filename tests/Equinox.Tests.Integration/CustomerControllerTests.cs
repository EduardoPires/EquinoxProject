using System.Net;
using System.Net.Http.Json;
using Equinox.Application.ViewModels;
using Equinox.Tests.Integration.Support;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Equinox.Tests.Integration;

public class CustomerControllerTests : IClassFixture<EquinoxApiFactory>
{
    private readonly HttpClient _client;

    public CustomerControllerTests(EquinoxApiFactory factory)
    {
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact(DisplayName = "POST /customer registra cliente" )]
    public async Task Post_RegisterCustomer_ReturnsSuccess()
    {
        // Arrange
        var customer = new CustomerViewModel
        {
            Name = "John Doe",
            Email = "john@test.com",
            BirthDate = DateTime.UtcNow.AddYears(-30)
        };

        // Act
        var response = await _client.PostAsJsonAsync("/customer", customer);

        // Assert
        response.EnsureSuccessStatusCode();
        var list = await _client.GetFromJsonAsync<List<CustomerViewModel>>("/customer");
        Assert.Contains(list!, c => c.Email == "john@test.com");
    }

    [Fact(DisplayName = "PUT /customer atualiza cliente" )]
    public async Task Put_UpdateCustomer_ReturnsSuccess()
    {
        // Arrange
        var customer = new CustomerViewModel
        {
            Name = "Jane Doe",
            Email = "jane@test.com",
            BirthDate = DateTime.UtcNow.AddYears(-25)
        };
        var createResponse = await _client.PostAsJsonAsync("/customer", customer);
        createResponse.EnsureSuccessStatusCode();
        var created = (await _client.GetFromJsonAsync<List<CustomerViewModel>>("/customer"))!
                        .First(c => c.Email == "jane@test.com");
        var update = new CustomerViewModel
        {
            Id = created!.Id,
            Name = "Jane Updated",
            Email = created.Email,
            BirthDate = created.BirthDate
        };

        // Act
        var updateResponse = await _client.PutAsJsonAsync("/customer", update);

        // Assert
        updateResponse.EnsureSuccessStatusCode();
        var get = await _client.GetFromJsonAsync<CustomerViewModel>($"/customer/{created.Id}");
        Assert.Equal("Jane Updated", get!.Name);
    }

    [Fact(DisplayName = "DELETE /customer remove cliente" )]
    public async Task Delete_RemoveCustomer_ReturnsSuccess()
    {
        // Arrange
        var customer = new CustomerViewModel
        {
            Name = "Remove Doe",
            Email = "remove@test.com",
            BirthDate = DateTime.UtcNow.AddYears(-20)
        };
        var create = await _client.PostAsJsonAsync("/customer", customer);
        create.EnsureSuccessStatusCode();
        var created = (await _client.GetFromJsonAsync<List<CustomerViewModel>>("/customer"))!
                        .First(c => c.Email == "remove@test.com");

        // Act
        var deleteResponse = await _client.DeleteAsync($"/customer?id={created.Id}");

        // Assert
        deleteResponse.EnsureSuccessStatusCode();
        var getResponse = await _client.GetAsync($"/customer/{created.Id}");
        Assert.Equal(HttpStatusCode.NoContent, getResponse.StatusCode);
    }
}
