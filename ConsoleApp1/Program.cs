// See https://aka.ms/new-console-template for more information

// console app
// 1. first line - menu with options READY
// 2. can create (write to file) or load a exist user (from user file)
// 3. with logged user we can change current user data in file (read and write)

// greetings

using ConsoleApp1.userData;

Console.WriteLine("Hello in count console app!");

// Menu options and index
string[] menuOptions = {"New User", "Load User", "Search", "Exit"};
// default index is 0
var menuIndex = 0;

Console.WriteLine("Please use arrow up or arrow down in menu:");
for (var i = 0; i < menuOptions.Length; i++) {
    if (i == menuIndex) Console.WriteLine(menuOptions[i] + " <");
    if (i != menuIndex) Console.WriteLine(menuOptions[i]);
}

// DownArrow and UpArrow controls
// rerender menu then key press, but renders only menus
ConsoleKeyInfo keyinfo;
do
{
    keyinfo = Console.ReadKey();
    Console.Clear();
    switch (keyinfo.Key.ToString())
    {
        case "DownArrow":
            menuIndex++;
            
            // range check
            if (menuIndex > menuOptions.Length - 1) menuIndex = menuOptions.Length - 1;
            break;
        
        case "UpArrow":
            menuIndex--;
            
            // range check
            if (menuIndex < 0) menuIndex = 0;
            break;
    }
    
    // rerender menu
    Console.WriteLine("Please use arrow up or arrow down in menu:");
    for (var i = 0; i < menuOptions.Length; i++) {
        if (i == menuIndex) Console.WriteLine(menuOptions[i] + " <");
        if (i != menuIndex) Console.WriteLine(menuOptions[i]);
    }
}
while (keyinfo.Key != ConsoleKey.Enter);

// then user press enter we check option select and decide what do next
if (keyinfo.Key == ConsoleKey.Enter)
{
    Console.WriteLine("selected option is " + menuOptions[menuIndex]);

    // New User scenario
    if (menuOptions[menuIndex] == "New User")
    {
        Console.WriteLine("Enter new login");
        var loginName = Console.ReadLine();

        // user checks
        if (loginName != null)
        {
            // existing checks if user didnt exit - allow to create a new one
            bool isExist = CheckUser.IsUserExist(loginName);
            if (isExist)
            {
                Console.WriteLine("User with this user name is already exist!");
            }
            else
            {
                UserItem newUser = UserData.CreateNewUser(isExist);
                UserCollection.WriteUserToBase(newUser);
            }
        }
        else
        {
            Console.WriteLine("Login can't be null");
            return;
        }
       
    }
    
    // Load User scenario
    if (menuOptions[menuIndex] == "Load User")
    {

    }
    
    // Search scenario
    if (menuOptions[menuIndex] == "Search")
    {
        
    }
    
    // Exit scenario
    if (menuOptions[menuIndex] == "Exit")
    {
        
    }
}