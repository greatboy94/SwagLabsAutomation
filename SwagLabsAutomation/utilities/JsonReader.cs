using Newtonsoft.Json.Linq;

namespace SwagLabsAutomation;

public class JsonReader
{
    public static IEnumerable<object[]> GetValidLoginTestData()
    {
        JObject testData = ReadTestData("utilities\\testData.json");
        var validLoginData = testData["LoginData"]["ValidCredentials"];

        foreach (var item in validLoginData)
        {
            yield return new object[]
            {
                item["Username"].ToString(), 
                item["Password"].ToString()
            };
        }
    }
    
    public static IEnumerable<object[]> GetInvalidLoginTestData()
    {
        // Read test data from JSON file using provided file path ####-> Make sure testData.json file properties set to "Copy always" <-####
        JObject testData = ReadTestData("utilities\\testData.json");

        // Extract username and password combinations for invalid login
        var invalidLoginData = testData["LoginData"]["InvalidCredentials"];

        foreach (var item in invalidLoginData)
        {
            yield return new object[]
            {
                item["Username"].ToString(), 
                item["Password"].ToString()
            };
        }
    }

    private static JObject ReadTestData(string filePath)
    {
        // Combine base directory with relative path to get full path
        string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

        // Read JSON file
        string jsonContent = File.ReadAllText(fullPath);

        // Parse JSON content
        JObject testData = JObject.Parse(jsonContent);

        return testData;
    }
}