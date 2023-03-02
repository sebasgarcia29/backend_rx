using Rxlightning.Extensions;
using Rxlightning.Interface;
using Rxlightning.Models;

namespace Rxlightning.Repository
{ 
    internal class UserAuth : IUserAuth
    {
        private readonly IUsersData _usersDataProvider;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<UserAuth> _logger;


        public UserAuth(IUsersData usersDataProvider, JwtSettings jwtSettings, ILogger<UserAuth> logger)
        {
            _usersDataProvider = usersDataProvider;
            _jwtSettings = jwtSettings;
            _logger = logger;
        }


        public async Task<LoginResponse> AuthenticateAsync(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = null;

            var users = await _usersDataProvider.GetAllAsync();

            var user = users.FirstOrDefault(u =>
                loginRequest.Email.Equals(u.Email)
                && loginRequest.Password.Equals(u.Password)
            );

            if (user != null)
            {
                try
                {
                    var token = user.GenerateJwt(_jwtSettings);

                    loginResponse = new LoginResponse()
                    {
                        Id = user.Id,


                        Email = user.Email,
                        UserName = user.UserName,
                        Fullname = $"{user.FirstName} {user.LastName}",
                        AccessToken = token
                    };
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception, "Error when trying to generate the JWT");
                }
            }

            return loginResponse;
        }
    }
}
