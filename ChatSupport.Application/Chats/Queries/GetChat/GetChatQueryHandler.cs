using System.Data;

namespace ChatSupport.Application.Chats.Queries.GetChat;
public class GetChatQueryHandler : IRequestHandler<GetChatQuery, ChatVm>
{
    private readonly IChatSupportDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetChatQueryHandler(IChatSupportDbContext dbContext,
        IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ChatVm> Handle(GetChatQuery request, CancellationToken cancellationToken)
    {
        var chat = await _dbContext.Chats.Include(x => x.Messages).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == request.ChatId && x.User.Id == request.UserId);

        if(chat == null)
        {
            throw new Exception("Попытка доступа к чужому или несуществующему чату!");
        }
        return _mapper.Map<ChatVm>(chat);
    }
}
