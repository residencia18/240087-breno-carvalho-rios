using Xunit;

namespace Atividade07.Tests;
public class DatabaseTests
{
    private readonly Database _sut;

    public DatabaseTests(){
        _sut = new Database();
    }

    [Fact]
    public void SaveUser_ShouldReturnSuccess(){
        // Arrange
        var user = new User("", "");

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
