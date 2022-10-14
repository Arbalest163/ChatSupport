namespace ChatSupport.Domain;
public class Message : Entity
{
    public virtual Chat Chat { get; set; }
    public string Text { get; set; }
    public virtual User User { get; set; }
    public DateTime DateSendMessage { get; set; }
}
