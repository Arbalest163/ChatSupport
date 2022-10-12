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
    [HttpGet]
    [Route("chats")]
    public async Task<ActionResult<ChatsListVm>> GetChats()
    {
        var query = new GetChatsListQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
