using Esign.Application.Responses.Identity;
using Esign.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Esign.Application.Interfaces.Chat;
using Esign.Application.Models.Chat;

namespace Esign.Application.Interfaces.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId);

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> message);

        Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId);
    }
}