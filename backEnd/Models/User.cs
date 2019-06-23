using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace backEnd.Models
{
    public class User
    {
        public Guid UserId { get ;set; }
        public string userName { get ;set; }
        public string password { get ;set; }
        public string firstName { get ;set; }
        public string lastName { get ;set; }
        public string email { get ;set; }
        public string level { get ;set; }
        [NotMapped] public string confirmPassword { get ;set; } 
    }
}