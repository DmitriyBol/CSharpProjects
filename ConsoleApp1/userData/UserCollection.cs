using System.Text.Json;

namespace ConsoleApp1.userData;

public class UserCollection
{
    public UserCollection(UserItem[] data)
    {
        Data = data;
    }

    public UserItem[] Data { get; set; }
    
    public static UserItem[] GetUsersFromBase()
    {
        // pick a data
        var rawData = File.ReadAllText("../../testData.json");
        UserCollection? usersObject = JsonSerializer.Deserialize<UserCollection>(rawData) ?? throw new Exception();
        return usersObject.Data;
    }
    
    public static UserItem PickUserFromBase(string loginName)
    {
        UserItem[] usersObject = GetUsersFromBase();

        foreach (var item in usersObject)
        {
            if (item.Login == loginName) return item;
        }
        
        throw new Exception("Error! User not found!");
    }
    
    public static void WriteUserToBase(UserItem userItem)
    {
        // read current data
        UserItem[] userListArray = GetUsersFromBase();

        UserItem[] newList = userListArray.Append(userItem).ToArray();

        UserCollection rawData = new UserCollection(newList);
        string jsonData = JsonSerializer.Serialize(rawData);

        File.WriteAllText("../../testData.json", jsonData);
    }
}
