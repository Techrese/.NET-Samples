using Moq;
using Repository.Models;

namespace RepositoryShould
{
    public class RepositoryShould
    {
        [Fact]
        public void ReturnOKWhenGetAllUsers()
        {
            Mock<IUserRepository> moq = new Mock<IUserRepository>();

            User user = new()
            {
                Id = Guid.NewGuid(),
                Name = "jhon doe",
                Email = "jhon.doe@doeinc.us"
            };

            moq.Setup(x => x.AddUser(user)).ReturnsAsync(true);

            moq.Verify(x => x.AddUser(It.IsAny<User>()), Times.Once);
        }
    }
}