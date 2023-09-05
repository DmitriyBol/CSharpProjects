namespace ConsoleApp1.userData;

public class UserData
{
    public bool newUser { get; set; }
    public string name { get; set; }
    public string lastName { get; set; }
    public int age { get; set; }
    public int score { get; set; }
    public DateTime dateCreated { get; set; }
    public DateTime dateUpdated { get; set; }
    public DateTime dateUpdatedOnStart { get; set; }
    
    public UserData(bool newUser, string name, string lastName, int age, int score, DateTime dateCreated, DateTime dateUpdated, DateTime dateUpdatedOnStart)
    {
        this.newUser = newUser;
        this.name = name;
        this.lastName = lastName;
        this.age = age;
        this.score = score;
        this.dateCreated = dateCreated;
        this.dateUpdated = dateUpdated;
        this.dateUpdatedOnStart = dateUpdatedOnStart;
    }

    private static void ThrowUserError(string field)
    {
        throw new Exception($"Error in user field! - {field}");
    }
    
    public static UserItem CreateNewUser(bool isUserExits)
    {
        Console.WriteLine("Please enter name");
        var name = Console.ReadLine();
        if (name is null) ThrowUserError("userName");
        
        Console.WriteLine("Please enter lastName");
        var lastName = Console.ReadLine();
        if (lastName is null) ThrowUserError("userLastName");

        Console.WriteLine("Please enter date of birth (YYYY,MM,DD)");
        string userDateOfBirth = Console.ReadLine();
        if (userDateOfBirth is null) ThrowUserError("userDateOfBirth");

        if (name != null && lastName != null && userDateOfBirth != null)
        {
            DateTime timeStamp = DateTime.UtcNow;

            var rawDate = userDateOfBirth?.Split(',');
            var firstDay = new DateTime(1, 1, 1);
            DateTime birthDate = new DateTime(
                int.Parse(rawDate?[0] ?? throw new InvalidOperationException("Error in Year field")), 
                int.Parse(rawDate[1] ?? throw new InvalidOperationException("Error in Month field")), 
                int.Parse(rawDate[2] ?? throw new InvalidOperationException("Error in Day field"))
            );
            TimeSpan difference = timeStamp.Subtract(birthDate);
            var dayOfBirthCalc = (firstDay + difference).Year - 1;
            
            var newUserData = new UserData(
                newUser: false, 
                name, 
                lastName, 
                age: dayOfBirthCalc,
                0,
                timeStamp, 
                timeStamp, 
                timeStamp);
            string generateLogin = newUserData.name + newUserData.lastName + newUserData.age;

            UserItem newUserItem = new UserItem(generateLogin, newUserData);
            return newUserItem;
        }

        throw new InvalidOperationException();
    }
}