
using Rxlightning.Models;

namespace Rxlightning.Interface
{ 
    public interface IUserAuth
    {
        Task<LoginResponse> AuthenticateAsync(LoginRequest model);

    }
}
