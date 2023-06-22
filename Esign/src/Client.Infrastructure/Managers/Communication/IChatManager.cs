using Esign.Application.Models.Chat;
using Esign.Application.Responses.Identity;
using Esign.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Esign.Application.Interfaces.Chat;

namespace Esign.Client.Infrastructure.Managers.Communication
{
    public interface IChatManager : IManager
    {
        Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync();

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> chatHistory);

        Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId);
    }
}