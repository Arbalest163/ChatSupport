namespace ChatSupport.Application.Chats.Commands.SendMessage;
public class SendMessageCommand : IRequest
{
    public int ChatId { get; set; }
    public int UserId { get; set; }
    public string Message { get; set; }
}
