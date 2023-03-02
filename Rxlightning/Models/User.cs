﻿using System.Data;
using Rxlightning.Models;

namespace Rxlightning.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Role> Roles { get; set; } = new HashSet<Role>();
    }
}
