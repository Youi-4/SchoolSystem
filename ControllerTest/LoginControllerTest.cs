using Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace ControllerTest
{
    [TestClass]
    public class LoginControllerTest
    {
        private LoginController lc = new LoginController();
        private CourseController cc = new CourseController();
        /// <summary>
        /// This methods first resets the database to its original them tests if the login details are correct
        /// </summary>
        [TestMethod]
        public void LoginInTest()
        {
            //Arrange
            cc.ResetDb();
            int expected = 1;
            string email = "JohnSmith@tafensw.au";
            string password = "John";
            //Act
            int actual = lc.LoginIntoSystem(email, password);
            //Assert
            Assert.AreEqual(expected, actual);        
        }
    }
}
