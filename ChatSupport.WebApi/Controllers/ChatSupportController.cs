using ChatSupport.Application.Chats.Commands.SendMessage;
using ChatSupport.Application.Chats.Commands.SendMessageByStaff;
using ChatSupport.Application.Chats.Queries.GetChats;

namespace ChatSupport.WebApi.Controllers;
public class ChatSupportController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public ChatSupportController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    /// <summary>
    /// Метод получения всех чатов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("chats")]
    public async Task<ActionResult<ChatsListVm>> GetChats()
    {
        var query = new GetChatsListQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
	/// Отправить сообщение в чат
	/// </summary>
	/// <param name="chatId">Идентификатор чата</param>
	/// <param name="request">Запрос</param>
	/// <returns></returns>
	[HttpPost]
    [Route("staff/{chatId}/message")]
    public async Task<IActionResult> SendMessage([FromRoute] int chatId, [FromBody] SendMessageDto request)
    {
        var command = _mapper.Map<SendMessageByStaffCommand>(request);
        command.ChatId = chatId;
        await _mediator.Send(command);
        return Ok();
    }
}
