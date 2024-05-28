using NSubstitute;
using Xunit;

namespace Atividade07.Tests;

public class UserServiceTests
{
    private readonly IDatabase _db = Substitute.For<IDatabase>();
    private readonly UserService _sut;

    public UserServiceTests(){
        _sut = new UserService(_db);
    }

    [Fact]
    public void SaveUser_NullName_ShouldReturnError()
    {
        // Arrange
        var user = new User(null!, "email@example.com");

        // Act
        var result = Assert.Throws<ArgumentException>(() => _sut.SaveUser(user));
        Assert.Contains("User must have a name and email", result.Message);
    }

    [Fact]
    public void SaveUser_EmptyName_ShouldReturnError()
    {
        // Arrange
        var user = new User("", "email@example.com");

        // Act
        var result = Assert.Throws<ArgumentException>(() => _sut.SaveUser(user));
        Assert.Contains("User must have a name and email", result.Message);
    }

    [Fact]
    public void SaveUser_NullEmail_ShouldReturnError()
    {
        // Arrange
        var user = new User("Name 1", null!);

        // Act
        var result = Assert.Throws<ArgumentException>(() => _sut.SaveUser(user));
        Assert.Contains("User must have a name and email", result.Message);
    }

    [Fact]
    public void SaveUser_EmptyEmail_ShouldReturnError()
    {
        // Arrange
        var user = new User("Name 1", "");

        // Act
        var result = Assert.Throws<ArgumentException>(() => _sut.SaveUser(user));
        Assert.Contains("User must have a name and email", result.Message);
    }

    [Fact]
    public void SaveUser_ShouldReturnSuccess()
    {
        // Arrange
        var user = new User("Nome 1", "email@example.com");

        // Act // Assert
        try
        {
            _sut.SaveUser(user);
        }
        catch (Exception ex)
        {
            Assert.Fail("Expected no exception, but got: " + ex.Message);
        }
    }
}