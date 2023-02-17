using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp1.userData;

public class CreateUser
{
    private static readonly JsonSerializerOptions Options = 
        new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    
    public static void CreateAndWriteDataInFile(string name, string lastName, int age)
    {
        if (name != "" && lastName != "" && age != 0)
        {
            User newUser = new User(name, lastName, age);
            DateTime timeStamp = DateTime.Now;
            newUser.updateChangeDate(timeStamp);

            var jsonData = JsonSerializer.Serialize(newUser, Options);
            
            Console.WriteLine("User successfully created!");
            Console.WriteLine("Now restart the app to work with it.");
            
            File.WriteAllLinesAsync("../../testData.json", new[] {jsonData});
        }
    }
}