using ConsoleApp1.userData;

namespace ConsoleApp1.MainMenu.MenuActions;

public class LoadUser
{
    public static void LoadUserOption()
    {
        Console.WriteLine("Enter login for load");
        var loginName = Console.ReadLine();
        DateTime timeStamp = DateTime.UtcNow;
        bool isCanLoad = false;
        
        UserItem user = new UserItem("", new UserData(false, "", "", 0,0, timeStamp,timeStamp,timeStamp));

        if (loginName is not null)
        {
            user = UserCollection.PickUserFromBase(loginName);
            if (user.Login == loginName) isCanLoad = true;
        }

        if (loginName is not null && isCanLoad)
        {
            Console.Clear();
            Console.WriteLine($"current user is {user.Login}! Got any changes?");

            Console.WriteLine("please type points (they will be added to you main score)");
            var points = Console.ReadLine();
            
            UserCollection.UpdateUserScoreToBase(loginName, int.Parse(points));
        }
    }
}