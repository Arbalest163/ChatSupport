using ChatSupport.Application.Users.Queries.GetUsersList;

namespace ChatSupport.WebApi.Controllers;
public class UserController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public UserController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    /// <summary>
    /// Метод получения всех пользователей
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("users")]
    public async Task<ActionResult<UsersListVm>> GetUsers()
    {
        var query = new GetUsersQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}