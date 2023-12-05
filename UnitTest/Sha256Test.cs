using Newtonsoft.Json;
using SQ.TermProject.myWeather.Services;
using System.Diagnostics;

namespace UnitTest
{
    [TestClass]
    public class Sha256Test
    {
        private List<WordHashPair> data;

        [TestInitialize]
        public void Initialize()
        {
            string json = File.ReadAllText(@"C:\Users\alexs\source\repos\SQ.TermProject.myWeather\UnitTest\TestFiles\sha256-test.json");

            var jsn = JsonConvert.DeserializeObject<Dictionary<string, List<WordHashPair>>>(json);
            data = jsn["wordHashPairs"];
        }

        [TestMethod]
        public void ValidSha256_ListOfStrings_ValidSha256Hashes()
        {
            foreach (var pair in data)
            {
                string word = pair.word;
                string expectedHash = pair.hash;

                // Implement your hash generation logic here for each word
                string generatedHash = PasswordService.GetSha256Hash(word);

                Assert.AreEqual(expectedHash, generatedHash);
            }
        }
    }


    public class WordHashPair
    {
        public string word { get; set; }
        public string hash { get; set; }
    }

}