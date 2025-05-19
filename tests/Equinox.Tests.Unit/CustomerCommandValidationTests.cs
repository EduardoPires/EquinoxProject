using Bogus;
using Equinox.Domain.Commands;
using Xunit;

namespace Equinox.Tests.Unit;

public class CustomerCommandValidationTests
{
    private readonly Faker _faker = new();

    [Fact(DisplayName = "Register command with valid data should be valid")]
    public void RegisterNewCustomerCommand_WithValidData_ShouldBeValid()
    {
        // Arrange
        var command = new RegisterNewCustomerCommand(
            _faker.Person.FullName,
            _faker.Internet.Email(),
            _faker.Person.DateOfBirth.AddYears(-18));

        // Act
        var result = command.IsValid();

        // Assert
        Assert.True(result);
    }

    [Fact(DisplayName = "Register command with under age customer should be invalid")]
    public void RegisterNewCustomerCommand_UnderAge_ShouldBeInvalid()
    {
        // Arrange
        var command = new RegisterNewCustomerCommand(
            _faker.Person.FullName,
            _faker.Internet.Email(),
            DateTime.Now.AddYears(-17));

        // Act
        var result = command.IsValid();

        // Assert
        Assert.False(result);
    }

    [Fact(DisplayName = "Update command with empty name should be invalid")]
    public void UpdateCustomerCommand_EmptyName_ShouldBeInvalid()
    {
        // Arrange
        var command = new UpdateCustomerCommand(
            Guid.NewGuid(),
            string.Empty,
            _faker.Internet.Email(),
            _faker.Person.DateOfBirth.AddYears(-20));

        // Act
        var result = command.IsValid();

        // Assert
        Assert.False(result);
    }

    [Fact(DisplayName = "Remove command with empty id should be invalid")]
    public void RemoveCustomerCommand_EmptyId_ShouldBeInvalid()
    {
        // Arrange
        var command = new RemoveCustomerCommand(Guid.Empty);

        // Act
        var result = command.IsValid();

        // Assert
        Assert.False(result);
    }
}
