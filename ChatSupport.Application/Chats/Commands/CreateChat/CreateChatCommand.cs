namespace ChatSupport.Application.Chats.Commands.CreateChat;
public class CreateChatCommand : IRequest<int>
{
    public string Title { get; set; }
    public int UserId { get; set; }
}
