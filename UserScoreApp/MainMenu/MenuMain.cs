namespace ConsoleApp1.MainMenu;

public static class MenuMain
{
    public static string[] MenuOptions => new[] {"New User", "Load User", "HighScore", "Delete User", "Exit"};
    private static int _menuIndex = 0;

    public static void MenuControls(string[] options)
    {
        Console.WriteLine("Please use arrow up or arrow down in menu:");
        for (byte i = 0; i < options.Length; i++) {
            if (i == _menuIndex) Console.WriteLine(options[i] + " <");
            if (i != _menuIndex) Console.WriteLine(options[i]);
        }
        
        ConsoleKeyInfo keyinfo;
        do
        {
            keyinfo = Console.ReadKey();
            Console.Clear();
            switch (keyinfo.Key.ToString())
            {
                case "DownArrow":
                    _menuIndex++;
            
                    // range check
                    if (_menuIndex > options.Length - 1) _menuIndex = options.Length - 1;
                    break;
        
                case "UpArrow":
                    _menuIndex--;
            
                    // range check
                    if (_menuIndex < 0) _menuIndex = 0;
                    break;
            }
    
            // rerender menu
            Console.WriteLine("Please use arrow up or arrow down in menu:");
            for (byte i = 0; i < options.Length; i++) {
                if (i == _menuIndex) Console.WriteLine(options[i] + " <");
                if (i != _menuIndex) Console.WriteLine(options[i]);
            }
        }
        while (keyinfo.Key != ConsoleKey.Enter);
        
        if (keyinfo.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            Console.WriteLine($"Selected option {options[_menuIndex]}");
            MenuSelect.MenuSelected(options[_menuIndex]);
        }
    }
}