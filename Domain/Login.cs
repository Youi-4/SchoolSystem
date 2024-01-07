using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Login
    {
        private string email;
        private string passsword;

        public string Passsword { get => passsword; set => passsword = value; }
        public string Email { get => email; set => email = value; }
        public Login (string email,string password)
        {
            Email = email;
            Passsword = password;
        }
    }
}
