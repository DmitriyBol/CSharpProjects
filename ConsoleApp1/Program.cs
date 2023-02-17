// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Hello in count console app!");
Console.WriteLine("Are you an new user? (Y - create new, N - load current by id)");
string answer1 = Console.ReadLine();

if (answer1 == null)
{
    Console.WriteLine("answer cant be null!");
    return;
}
if (answer1 == "Y" || answer1 == "y")
{
    Console.WriteLine("Your select Y to create new user");
    Console.WriteLine("please type name, lastname and age");
    Console.Write("Name: ");
    var name = Console.ReadLine();
    Console.Write("Lastname: ");
    var lastName = Console.ReadLine();
    Console.Write("Age: ");
    int age = Convert.ToInt32(Console.ReadLine());

    if (name != null && lastName != null && age != 0)
    {
        WriteData.WriteDataInFile(name, lastName, age);
    }
}
if (answer1 == "N" || answer1 == "n")
{
    Console.WriteLine("answer cant be null!");
}

public class User
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public User(string name, string lastName, int age)
    {
        Name = name;
        LastName = lastName;
        Age = age;
    }
}

public class WriteData
{
    private static readonly JsonSerializerOptions _options = 
        new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    
    public static async Task WriteDataInFile(string name, string lastName, int age)
    {
        if (name != "" && lastName != "" && age != 0)
        {
            User newUser = new User(name, lastName, age);

            var jsonData = JsonSerializer.Serialize(newUser, _options);
            
            Console.WriteLine("User successfully created!");
            Console.WriteLine("Now restart the app to work with it.");
            
            await File.WriteAllLinesAsync("../../testData.txt", new[] {jsonData});
        }
    }
}