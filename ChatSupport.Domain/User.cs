namespace ChatSupport.Domain;
public class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime Birthday { get; set; }
    public string Nickname { get; set; }
    public Role Role { get; set; }
    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
}
