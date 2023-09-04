using System.Text.Json;
using ConsoleApp1.DataBase;

namespace ConsoleApp1.userData;

public class UserCollection
{
    public UserCollection(UserItem[] data)
    {
        Data = data;
    }

    public UserItem[] Data { get; set; }
    
    // GET LIST OF USERS
    public static UserItem[] GetUsersFromBase()
    {
        // pick a data
        var rawData = File.ReadAllText(DataBaseCollection.DataBasePath);
        
        UserCollection usersObject = JsonSerializer.Deserialize<UserCollection>(rawData)! ?? throw new Exception();
        
        return usersObject.Data;
    }
    
    // GET ONE USER
    public static UserItem PickUserFromBase(string loginName)
    {
        UserItem[] usersObject = GetUsersFromBase();

        foreach (var item in usersObject)
        {
            if (item.Login == loginName) return item;
        }
        
        throw new Exception("Error! User not found!");
    }
    
    // POST USER to USERS
    public static void WriteUserToBase(UserItem userItem)
    {
        UserItem[] userListArray = GetUsersFromBase();
        UserItem[] newList = userListArray.Append(userItem).ToArray();

        UserCollection rawData = new UserCollection(newList);
        string jsonData = JsonSerializer.Serialize(rawData);

        File.WriteAllText(DataBaseCollection.DataBasePath, jsonData);
    }
    
    // DELETE USER from USERS
    public static void DeleteUserFromBase(string userLogin)
    {
        var usersObject = GetUsersFromBase();
        var userIndex = Array.FindIndex(usersObject, user => user.Login == userLogin);

        if (userIndex == -1)
        {
            Console.WriteLine("Error in delete user from data base, user with this login not found!");
        }
        else
        {
            UserItem[] newUsersList = usersObject.Where(elem => elem.Login != userLogin).ToArray();
            UserCollection rawData = new UserCollection(newUsersList);
            string jsonData = JsonSerializer.Serialize(rawData);
            
            File.WriteAllText(DataBaseCollection.DataBasePath, jsonData);
        }
    }
    
    // GET ONE USER POST to USERS (Update)
    public static void UpdateUserToBase(string userLogin)
    {
        UserItem currentUser = PickUserFromBase(userLogin);
        DeleteUserFromBase(userLogin);
        var timeStamp = DateTime.UtcNow;
        
        if (currentUser.Data?.dateUpdated != null) currentUser.Data.dateUpdated = timeStamp;
        
        WriteUserToBase(currentUser);
    }
}
