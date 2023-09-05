using System.Text.Json;
using ConsoleApp1.userData;

namespace ConsoleApp1.DataBase;

public class DataBaseCollection
{
    public static string DataBasePath => "../../../DataBase/testData.json";

    public static bool CheckDataBaseFile()
    {
        try
        {
            File.ReadAllText(DataBasePath);
        }
        catch (Exception error)
        {
            File.Create(DataBasePath).Close();
            Console.WriteLine("Initial file was not been found - created new one!");

            return true;
        }

        return false;
    }

    public static void WriteInitialData()
    {
        UserData initialUserData = new UserData(
            true, "initial", 
            "initial", 
            0, 
            0, 
            DateTime.UtcNow, 
            DateTime.UtcNow, 
            DateTime.UtcNow
        );
        UserItem[] initialUserItem = new[] {new UserItem("initial", initialUserData)};
        UserCollection initialData = new UserCollection(initialUserItem);
        string jsonData = JsonSerializer.Serialize(initialData);
        
        File.WriteAllText(DataBasePath, jsonData);
    }
}