﻿using System.ComponentModel;
using System.Runtime.InteropServices.JavaScript;

namespace ConsoleApp1.userData;

public class UserData
{
    public bool newUser { get; set; }
    public string name { get; set; }
    public string lastName { get; set; }
    public int age { get; set; }
    public DateTime dateOfBirth { get; set; }
    public DateTime dateCreated { get; set; }
    public DateTime dateUpdated { get; set; }
    public DateTime dateUpdatedOnStart { get; set; }
    
    public UserData(string name, string lastName, string userDateOfBirth)
    {
        DateTime timeStamp = DateTime.UtcNow;

        var rawDate = userDateOfBirth?.Split(',');
        var firstDay = new DateTime(1, 1, 1);
        DateTime birthDate = new DateTime(
            int.Parse(rawDate?[0] ?? throw new InvalidOperationException("Error in Year field")), 
            int.Parse(rawDate[1] ?? throw new InvalidOperationException("Error in Month field")), 
            int.Parse(rawDate[2] ?? throw new InvalidOperationException("Error in Day field"))
        );
        TimeSpan difference = timeStamp.Subtract(birthDate);
        int age = (firstDay + difference).Year - 1;
        
        this.newUser = true;
        this.name = name;
        this.lastName = lastName;
        this.dateOfBirth = birthDate;
        this.age = age;
        this.dateCreated = timeStamp;
        this.dateUpdated = timeStamp;
        this.dateUpdatedOnStart = timeStamp;
    }

    private static void ThrowUserError(string field)
    {
        throw new Exception($"Error in user field! - {field}");
    }
    
    public static void createNewUser(bool isUserExits)
    {
        if (isUserExits)
        {
            Console.WriteLine("User with this user name is already exist!");
            return;
        }
        Console.WriteLine("Please enter name");
        var userName = Console.ReadLine();
        if (userName is null) ThrowUserError("userName");
        
        Console.WriteLine("Please enter lastName");
        var userLastName = Console.ReadLine();
        if (userLastName is null) ThrowUserError("userLastName");

        Console.WriteLine("Please enter date of birth (YYYY,MM,DD)");
        string userDateOfBirth = Console.ReadLine();
        if (userLastName is null) ThrowUserError("userDateOfBirth");

        if (userName != null && userLastName != null && userDateOfBirth != null)
        {
            UserData newUser = new UserData(userName, userLastName, userDateOfBirth);
        }
    }
}