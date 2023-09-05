// See https://aka.ms/new-console-template for more information

// console app
// 1. first line - menu with options READY
// 2. can create (write to file) or load a exist user (from user file) READY
// 3. with logged user we can change current user data in file (read and write) READY
// and update some info - here its a step count
// 4. High score between users READY
// 5. Exit - have a good day and best luck! READY

// greetings

using ConsoleApp1.DataBase;
using ConsoleApp1.MainMenu;
using ConsoleApp1.userData;

// checking if data base exist
bool isNeedWriteInitialData = DataBaseCollection.CheckDataBaseFile();
if (isNeedWriteInitialData)
{
    DataBaseCollection.WriteInitialData();
    UserCollection.DeleteUserFromBase("initial");
}

// run main brunch
Console.WriteLine("Hello in count console app!");
MenuMain.MenuControls(MenuMain.MenuOptions);
