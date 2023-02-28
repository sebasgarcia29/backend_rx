namespace Rxlightning.WebApi.Models
{
    public class UserInfo
    {
        public int userId { get; set; }
        public string displayName { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime? createdDate { get; set; }
    }
}