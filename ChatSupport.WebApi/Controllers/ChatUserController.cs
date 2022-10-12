using ChatSupport.Application.Chats.Commands.CreateChat;
using ChatSupport.Application.Chats.Commands.SendMessage;
using ChatSupport.Application.Chats.Queries.GetChat;

namespace ChatSupport.WebApi.Controllers;
public class ChatUserController : BaseController
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;
	public ChatUserController(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	/// <summary>
	/// Метод для тестирования доступа к апи
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Route("test")]
	public ActionResult<string> GetTest()
	{
		return Ok("Апи доступна");
	}

	/// <summary>
	/// Создать чат
	/// </summary>
	/// <param name="request"></param>
	/// <returns>Идентификатор созданного чата</returns>
	[HttpPost]
	[Route("create-chat")]
	public async Task<ActionResult<int>> CreateChat([FromBody] CreateChatDto request)
	{
		var command = _mapper.Map<CreateChatCommand>(request);
		var chatId = await _mediator.Send(command);
		return Ok(chatId);
	}

	/// <summary>
	/// Отправить сообщение в чат
	/// </summary>
	/// <param name="chatId">Идентификатор чата</param>
	/// <param name="request">Запрос</param>
	/// <returns></returns>
	[HttpPost]
	[Route("{chatId}/message")]
	public async Task<IActionResult> SendMessage([FromRoute]int chatId, [FromBody]SendMessageDto request)
	{
		var command = _mapper.Map<SendMessageCommand>(request);
		command.ChatId = chatId;
		await _mediator.Send(command);
		return Ok();
	}

	/// <summary>
	/// Получение чата
	/// </summary>
	/// <param name="chatId">Идентификатор чата</param>
	/// <param name="userId">Идентификатор пользователя, автора чата</param>
	/// <returns></returns>
	[HttpGet]
	[Route("{chatId}")]
	public async Task<ActionResult<ChatVm>> GetChat([FromRoute]int chatId, [FromQuery]int userId)
	{
		var request = new GetChatQuery
		{
			ChatId = chatId,
			UserId = userId
		};
		var vm = await _mediator.Send(request);
		return Ok(vm);
    }
}
