namespace SGConsole.Models;

public class UserModel : IMapFrom<User>
{
    public void Mapping()
    {
        Console.WriteLine("User Model Mapping");
    }
}

public class User { }
