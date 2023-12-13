using SQ.TermProject.myWeather.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService UserService { get; set; }

        public UserServiceTests() 
        {
            UserService = new UserService();
        }

        [TestMethod]
        public void CheckUserRole_UserAndRole_CorrectUserRole()
        {
                string userName = "AlexSimko";

                string expectedRole = "Superadmin";

                string receivedRole = UserService.getUserRole(userName);

                Assert.AreEqual(expectedRole, receivedRole);
        }
    }
}
