using System;
using System.Collections.Generic;

namespace HexadLMServices.Repositories.Models
{
    public partial class User
    {
        public User()
        {
            UserBook = new HashSet<UserBook>();
            UserRole = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LasName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<UserBook> UserBook { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
