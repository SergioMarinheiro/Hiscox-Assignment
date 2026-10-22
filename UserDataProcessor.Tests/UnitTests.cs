using UserDataProcessor.Models;
using UserDataProcessor.Operations;


namespace UserDataProcessor.Tests;

public class UnitTests
{
    private readonly List<User> _users =
    [
        new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Age = 31 },
        new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Age = 25 },
        new User { Id = 3, Name = "Bob Johnson", Email = "bob.johnson@example.com", Age = 40 }
    ];

    private readonly UserOperations _service;

    public UnitTests()
    {
        _service = new UserOperations(_users);
    }

    [Fact]
    public void FindUserByEmail_WhenListIsEmpty_ReturnsNull()
    {
        var service = new UserOperations(new List<User>());

        var result = service.FindUserByEmail("jane.smith@example.com");

        Assert.Null(result);
    }

    [Fact]
    public void FindUserByEmail_WhenEmailExists_ReturnsUser()
    {
        var result = _service.FindUserByEmail("jane.smith@example.com");

        Assert.NotNull(result);
        Assert.Equal(2, result.Id);
        Assert.Equal("Jane Smith", result.Name);
        Assert.Equal(25, result.Age);
    }

    [Fact]
    public void FindUserByEmail_WhenEmailDoesNotExist_ReturnsNull()
    {
        var result = _service.FindUserByEmail("sergio.marinheiro@hiscox.com");

        Assert.Null(result);
    }

    [Fact]
    public void FindUserByEmail_WhenEmailDiffersInCase_ReturnsUser()
    {
        var result = _service.FindUserByEmail("JANE.SMITH@EXAMPLE.COM");

        Assert.NotNull(result);
        Assert.Equal(2, result.Id);
        Assert.Equal("Jane Smith", result.Name);
        Assert.Equal(25, result.Age);
    }

    [Fact]
    public void FindUsersByAgeOlderThan_ReturnsUsersAboveSpecifiedAge()
    {
        var result = _service.FindUsersByAgeOlderThan(30);

        Assert.Equal(2, result.Count);
        Assert.Equal("John Doe", result[0].Name);
        Assert.Equal("Bob Johnson", result[1].Name);

    }

    [Fact]
    public void FindUsersByAgeOlderThan_WhenNoUsersExceedAge_ReturnsEmptyList()
    {
        var result = _service.FindUsersByAgeOlderThan(40);

        Assert.Empty(result);
    }

    [Fact]
    public void CalculateAverageAge_WhenAverageIsWholeNumber_ReturnsCorrectAverage()
    {
        var result = _service.CalculateAverageAge();

        Assert.Equal(32.0f, result);
    }

    [Fact]
    public void CalculateAverageAge_WhenAverageIsFractional_ReturnsCorrectAverage()
    {
        var users = new List<User>
        {
            new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Age = 31 },
            new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Age = 26 },
        };

        var service = new UserOperations(users);

        var result = service.CalculateAverageAge();

        Assert.Equal(28.5f, result);
    }




}

