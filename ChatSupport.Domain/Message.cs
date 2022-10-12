namespace ChatSupport.Domain;
public class Message : Entity
{
    public virtual Chat Chat { get; set; }
    public string Text { get; set; }
    public User User { get; set; }
    public DateTimeOffset DateSendMessage { get; set; }
}
