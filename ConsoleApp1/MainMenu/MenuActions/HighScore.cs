using ConsoleApp1.userData;

namespace ConsoleApp1.MainMenu.MenuActions;

public class HighScore
{
    public static void HighScoreList()
    {
        UserItem[] userList = UserCollection.GetUsersFromBase();
        Dictionary<string, int> HSList = new Dictionary<string, int>();

        foreach (var user in userList)
        {
            HSList.Add(user.Login, user.Data.score);
        }

        if (HSList is not null)
        {
            var sortedDict = from entry in HSList orderby entry.Value ascending select entry;
            int lengthOfList = sortedDict.ToArray().Length;
            for (int i = lengthOfList - 1; i > -1; i--)
            {
                Console.WriteLine(sortedDict.ToArray()[i]);
            }
        }
    }
}