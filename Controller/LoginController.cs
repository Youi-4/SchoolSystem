using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Domain;
namespace Controller
{
    /// <summary>
    /// This Class is the business of the application related to the Login confirmation
    /// This class uses the data access layer to check if the login details are in the database,
    /// and is used by the Presentation layer to input the login details
    /// </summary>
    public class LoginController
    {
        public int LoginIntoSystem(string email,string password) {
            var repo = new LoginRepo();
            Login login = new Login(email,password);
            int result = repo.LoginVerify(login);
            return result;
        }
    }
}
