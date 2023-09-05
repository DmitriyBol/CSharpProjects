using ConsoleApp1.MainMenu.MenuActions;
using ConsoleApp1.userData;
using LoadUser = ConsoleApp1.MainMenu.MenuActions.LoadUser;

namespace ConsoleApp1.MainMenu;

public static class MenuSelect
{
    public static void MenuSelected(string optionSelected)
    {
        // New User scenario
        if (optionSelected == "New User")
        {
            bool isCreated = NewUser.NewUserOption();
            if (isCreated)
            {
                Console.Clear();
                MenuMain.MenuControls(MenuMain.MenuOptions);
            }
        }
            
        // Load User scenario
        if (optionSelected == "Load User")
        {
            LoadUser.LoadUserOption();
        }
            
        // Search scenario
        if (optionSelected == "HighScore")
        {
            HighScore.HighScoreList();
        }
         
        // Delete user scenario
        if (optionSelected == "Delete User")
        {
            Console.Clear();
            Console.WriteLine("Please type user login to delete");
            
            var loginName = Console.ReadLine();
            if (loginName is not null)
            {
                Console.WriteLine("Are you sure? (y/n) (It will be delete user from base)");
                var answer = Console.ReadLine();

                if (answer == "y")
                {
                    Console.WriteLine($"User with login {loginName} has been deleted!");
                    UserCollection.DeleteUserFromBase(loginName);
                }

                if (answer == "n")
                {
                    Console.Clear();
                    MenuMain.MenuControls(MenuMain.MenuOptions);
                }
            }
        }
        
        // Exit scenario
        if (optionSelected == "Exit")
        {
            Console.Clear();
            Console.WriteLine("Have a nice day!");
        }
    }
}