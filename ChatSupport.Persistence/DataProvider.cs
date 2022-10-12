using ChatSupport.Domain;
namespace ChatSupport.Persistence;
public class DataProvider
{
    public static IEnumerable<User> GetUsers()
    {
        yield return new User { FirstName = "Name_1", LastName = "LastName_1", MiddleName = "MiddleName_1", Nickname = "Nickname_1", Birthday = DateTime.Parse("10.04.1980"), Role = Role.User };
        yield return new User { FirstName = "Name_2", LastName = "LastName_2", MiddleName = "MiddleName_2", Nickname = "Nickname_2", Birthday = DateTime.Parse("15.05.1985"), Role = Role.User };
        yield return new User { FirstName = "Name_3", LastName = "LastName_3", MiddleName = "MiddleName_3", Nickname = "Nickname_3", Birthday = DateTime.Parse("24.07.1983"), Role = Role.User };
        yield return new User { FirstName = "Name_4", LastName = "LastName_4", MiddleName = "MiddleName_4", Nickname = "Nickname_4", Birthday = DateTime.Parse("11.01.1991"), Role = Role.User };
        yield return new User { FirstName = "Name_5", LastName = "LastName_5", MiddleName = "MiddleName_5", Nickname = "Nickname_5", Birthday = DateTime.Parse("11.06.1996"), Role = Role.User };
    }
}
