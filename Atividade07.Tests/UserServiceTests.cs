using NSubstitute;

namespace Atividade07.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void SaveUser_WithValidUser_CallsSaveUser()
        {
            var mockDb = Substitute.For<IDatabase>();
            var service = new UserService(mockDb);

            var user = new User("name", "email");
            service.SaveUser(user);

            mockDb.Received(1).SaveUser(user);
        }

        [Fact]
        public void SaveUser_WithMissingName_ThrowsArgumentException()
        {
            var mockDb = Substitute.For<IDatabase>();
            var service = new UserService(mockDb);

            var user = new User("", "email");
            Assert.Throws<ArgumentException>(() => service.SaveUser(user));
        }

        [Fact]
        public void SaveUser_WithMissingEmail_ThrowsArgumentException()
        {
            var mockDb = Substitute.For<IDatabase>();
            var service = new UserService(mockDb);

            var user = new User("name", "");
            Assert.Throws<ArgumentException>(() => service.SaveUser(user));
        }
    }
}