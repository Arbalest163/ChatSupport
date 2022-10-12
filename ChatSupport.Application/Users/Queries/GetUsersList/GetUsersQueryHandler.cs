namespace ChatSupport.Application.Users.Queries.GetUsersList;
public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UsersListVm>
{
    private readonly IChatSupportDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IChatSupportDbContext dbContext,
        IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<UsersListVm> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = _dbContext.Users.Include(x => x.Chats);
        var usersDto = await users.ProjectTo<UserDto>(_mapper.ConfigurationProvider).ToArrayAsync(cancellationToken);
        return new UsersListVm { Users = usersDto };
    }
}
