using Rxlightning.Models;

namespace Rxlightning.Interface
{
    public interface IUsersData
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}
