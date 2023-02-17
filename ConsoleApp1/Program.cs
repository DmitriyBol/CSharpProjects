// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using ConsoleApp1.userData;

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