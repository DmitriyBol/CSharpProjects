using System.Text.Json;

namespace ConsoleApp1.userData;

public class CheckUser
{
    public static bool IsUserExist(string loginName)
    {
        // get data
        UserItem[] data = UserCollection.GetUsersFromBase();

        // find a user return true if user already exist
        return data.Any(user => user.Login == loginName);
    }
}