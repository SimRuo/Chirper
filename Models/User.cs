using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Chirper.Models
{
    public class User : IdentityUser
    {
        public ICollection<Chirp> Chirps { get; set; }

        public User() { }
        public User(string username, string email)
        {
            UserName = username;
            Email = email;
        }
    }
}