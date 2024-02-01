using Newtonsoft.Json;
using SQ.TermProject.myWeather.Services;
using System.Diagnostics;
using System.Security.Cryptography;

namespace UnitTest
{

    namespace UnitTest
    {
        [TestClass]
        public class SaltTest
        {
            private int[] testLengs;
            private int kAmntOfTests = 25;

            [TestInitialize]
            public void Initialize()
            {
                testLengs = new int[kAmntOfTests];

                for (int i =0; i< kAmntOfTests;i++)
                {
                    testLengs[i] = RandomNumberGenerator.GetInt32(1000);
                }
            }

            [TestMethod]
            public void ValidSalt_RandomLengths_SaltCorrectLength()
            {
                for (int i = 0; i < kAmntOfTests; i++)
                {
                    int input = testLengs[i];
                    string saltResult = PasswordService.GenerateSalt(input);

                    Assert.AreEqual(input, saltResult.Length/2);
                }
            }
        }

    }
}
