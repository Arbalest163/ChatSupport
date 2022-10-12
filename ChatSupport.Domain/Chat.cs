namespace ChatSupport.Domain;
public class Chat : Entity
{
    public string Title { get; set; }
    /// <summary>
    /// Пользователь, создавший чат
    /// </summary>
    public virtual User User { get; set; }
    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    public DateTimeOffset DateCreateChat { get; set; }
    public bool IsActive { get; set; }
}
