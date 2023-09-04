using ConsoleApp1.userData;

namespace ConsoleApp1.MainMenu.MenuActions;

public class NewUser
{
    public static void NewUserOption()
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

        if (!isExist)
        {
            UserItem newUser = UserData.CreateNewUser(isExist);
            UserCollection.WriteUserToBase(newUser);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("User with this user name is already exist!");
            NewUserOption();
        }
    }
}