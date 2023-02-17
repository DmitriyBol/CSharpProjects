using System.Text.Json;

namespace ConsoleApp1.userData;

public class UserDataCollection
{
    public static void getUsersData()
    {
        try
        {
            string rawData = File.ReadAllText("../../testData.json");
            var userData = JsonSerializer.Deserialize<List<User>>(rawData);

            Console.WriteLine("Текущие пользователи: ");
            foreach (var user in userData)
            {
                Console.Write($"{user.Name}, ");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new FileNotFoundException();
        }
    }
}
