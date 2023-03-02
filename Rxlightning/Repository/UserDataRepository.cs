using Rxlightning.Interface;
using Rxlightning.Models;

namespace Rxlightning.Repository
{
    internal class UserData : IUsersData
    {
        private IEnumerable<User> users = new List<User>()
        {
            new User()
            {
                Id = Guid.NewGuid(),
                Password = "Test1234",
                Email = "sebas@test.com",
                UserName = "sebasgarcia29",
                FirstName = "Sebas",
                LastName = "Garcia",
                Roles = new HashSet<Role>()
                {
                    new Role() { Name = "ADMIN" }
                }
            },
        };

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            await Task.Yield();

            return users;
        }
    }
}
