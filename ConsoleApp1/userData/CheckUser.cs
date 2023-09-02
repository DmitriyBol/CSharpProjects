using System.Text.Json;

namespace ConsoleApp1.userData;

public class CheckUser
{
    public static bool IsUserExist(string loginName)
    {
        // get data
        UserRawData json = UserRawData.GetUsersRawData();

        // find a user return true if user already exist
        return json.data.Any(user => user.login == loginName);
    }
}