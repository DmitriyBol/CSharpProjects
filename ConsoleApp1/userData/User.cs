using System.Runtime.InteropServices.JavaScript;

namespace ConsoleApp1.userData;

public class User
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }

    public User(string name, string lastName, int age)
    {
        DateTime createStamp = DateTime.Now;

        Name = name;
        LastName = lastName;
        Age = age;
        CreatedDate = createStamp;
    }

    public void updateChangeDate(DateTime date)
    {
        LastUpdatedDate = date;
    }
}