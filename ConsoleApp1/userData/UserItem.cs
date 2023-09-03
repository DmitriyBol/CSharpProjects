namespace ConsoleApp1.userData;

public class UserItem
{
    public UserItem(string login, object data)
    {
        Login = login;
        Data = data;
    }

    public string Login { get; set; }
    public object Data { get; set; }
}