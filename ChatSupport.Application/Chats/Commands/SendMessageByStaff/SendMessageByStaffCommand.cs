namespace ChatSupport.Application.Chats.Commands.SendMessageByStaff;
public class SendMessageByStaffCommand : IRequest
{
    public int ChatId { get; set; }
    public int UserId { get; set; }
    public string Message { get; set; }
}
