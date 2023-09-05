using ConsoleApp1.userData;

namespace ConsoleApp1.MainMenu.MenuActions;

public class NewUser
{
    public static bool NewUserOption()
    {
        Console.WriteLine("Enter new login");
        var loginName = Console.ReadLine();
        bool isExist = false;
        
        if (loginName is not null)
        {
            isExist = CheckUser.IsUserExist(loginName);
        }
        else
        {
            Console.WriteLine("Login cant be null");
        }

        if (isExist)
        {
            Console.Clear();
            Console.WriteLine("User with this user name is already exist!");
            NewUserOption();
        }
        else
        {
            UserItem newUser = UserData.CreateNewUser(isExist);
            UserCollection.WriteUserToBase(newUser);
            return true;
        }

        return false;
    }
}