using System;
using System.Collections.Generic;

#nullable disable

namespace Empite_Dot_Net.Data.Database
{
    public partial class User
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] EncryptedFirstName { get; set; }
        public byte[] EncryptedLastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
    }
}
