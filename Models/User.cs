using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirper.Models
{
    public class User
    {
        public int Id { get; set; } //Primary Key
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Chirp> Chirps { get; set; }

        public User() { }
        public User(int Id, string Username, string Email, string PasswordHash)
        {
            this.Id = Id;
            this.Username = Username;
            this.Email = Email;
            this.PasswordHash = PasswordHash;
        }
    }
}