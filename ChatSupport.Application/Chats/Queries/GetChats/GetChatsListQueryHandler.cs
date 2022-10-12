namespace ChatSupport.Application.Chats.Queries.GetChats;
public class GetChatsListQueryHandler : IRequestHandler<GetChatsListQuery, ChatsListVm>
{
    private readonly IChatSupportDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetChatsListQueryHandler(IChatSupportDbContext dbContext, 
        IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ChatsListVm> Handle(GetChatsListQuery request, CancellationToken cancellationToken)
    {
        var chats = request.UserId.HasValue ? _dbContext.Chats.Where(c => c.User.Id == request.UserId.Value) : _dbContext.Chats;
        var chatsVm = await chats.ProjectTo<ChatDto>(_mapper.ConfigurationProvider).ToArrayAsync(cancellationToken);
        return new ChatsListVm { Chats = chatsVm };
    }
}
