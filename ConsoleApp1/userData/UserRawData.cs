using System.Text.Json;

namespace ConsoleApp1.userData;

public class UserRawData
{
    public UserItem[] data { get; set; }
    
    public static UserRawData GetUsersRawData()
    {
        // pick a data
        var rawData = File.ReadAllText("../../testData.json");
        UserRawData? json = JsonSerializer.Deserialize<UserRawData>(rawData) ?? throw new Exception();

        return json;
    }
    
    public static UserItem PickUserData(string loginName)
    {
        UserRawData json = GetUsersRawData();

        foreach (var item in json.data)
        {
            if (item.login == loginName) return item;
        }
        throw new Exception("Error! User not found!");
    }
    
    public static void WriteUserRawData(UserRawData json)
    {
        // pick a data
        var jsonData = JsonSerializer.Serialize(json);
        File.WriteAllLinesAsync("../../testData.json", new[] {jsonData});
    }
}
