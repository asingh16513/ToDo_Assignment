using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class User : BaseModel
    { 
        /// <summary>
        /// Requires password to be encrypted to Base64 for registering new user
        /// </summary>
        public string Password { get; set; } 
        public UserType UserType { get; set; }
    }
}
