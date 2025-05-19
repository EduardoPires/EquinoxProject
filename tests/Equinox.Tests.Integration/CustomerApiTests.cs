using Bogus;
using Equinox.Application.ViewModels;
using Equinox.Tests.Integration.Support;
using System.Net.Http.Json;
using Xunit;

namespace Equinox.Tests.Integration;

public class CustomerApiTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly Faker _faker = new();

    public CustomerApiTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact(DisplayName = "Posting a new customer should succeed")]
    public async Task PostCustomer_ShouldReturnSuccess()
    {
        // Arrange
        var model = new CustomerViewModel
        {
            Name = _faker.Person.FullName,
            Email = _faker.Internet.Email(),
            BirthDate = _faker.Person.DateOfBirth.AddYears(-20)
        };

        // Act
        var response = await _client.PostAsJsonAsync("customer", model);

        // Assert
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact(DisplayName = "New customer should appear in get list")]
    public async Task CreatedCustomer_ShouldAppear_OnGetAll()
    {
        // Arrange
        var model = new CustomerViewModel
        {
            Name = _faker.Person.FullName,
            Email = _faker.Internet.Email(),
            BirthDate = _faker.Person.DateOfBirth.AddYears(-25)
        };
        await _client.PostAsJsonAsync("customer", model);

        // Act
        var customers = await _client.GetFromJsonAsync<List<CustomerViewModel>>("customer");

        // Assert
        Assert.Contains(customers!, c => c.Email == model.Email);
    }
}
