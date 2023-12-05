using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using SQ.TermProject.myWeather.Services;

namespace UnitTest
{
    [TestClass]
    public class LoginApiTest
    {
        [TestMethod]
        public void CanLogin_ValidTestAccounts_LogUserIn()
        {
            // arrange
            UserService userService = new UserService();
            string username = "AleSimko", password = "simko123";

            // act
            bool actual = userService.IsValidUser(username, password);
            bool expected = true;

            //assert
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void LoginRejection_InValidTestAccounts_RejectUserLogIn()
        {
            // arrange
            UserService userService = new UserService();
            string username = "Invalid", password = "Details";

            // act
            bool actual = userService.IsValidUser(username, password);
            bool expected = false;

            //assert
            Assert.AreEqual(expected, actual);


        }

    }

}
