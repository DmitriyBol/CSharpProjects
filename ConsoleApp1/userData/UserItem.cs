namespace ConsoleApp1.userData;

public class UserItem
{
    public UserItem(string login, UserData data)
    {
        Login = login;
        Data = data;
    }

    public string Login { get; set; }
    public UserData Data { get; set; }
}