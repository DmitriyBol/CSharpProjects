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
            NewUser.NewUserOption();
        }
            
        // Load User scenario
        if (optionSelected == "Load User")
        {
            LoadUser.LoadUserOption();
        }
            
        // Search scenario
        if (optionSelected == "Search")
        {
                
        }
            
        // Exit scenario
        if (optionSelected == "Exit")
        {
                
        }
    }
}