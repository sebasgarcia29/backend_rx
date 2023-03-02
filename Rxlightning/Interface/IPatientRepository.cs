using Rxlightning.WebApi.Models;

namespace Rxlightning.Interface
{
    public interface IpatientRepository
    {
        Task<Patient> GetByIdAsync(string id);
        Task<IEnumerable<Patient>> GetAllAsync();
    }
}
