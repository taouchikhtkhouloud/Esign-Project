using AutoMapper;
using Esign.Application.Interfaces.Chat;
using Esign.Application.Models.Chat;
using Esign.Infrastructure.Models.Identity;

namespace Esign.Infrastructure.Mappings
{
    public class ChatHistoryProfile : Profile
    {
        public ChatHistoryProfile()
        {
            CreateMap<ChatHistory<IChatUser>, ChatHistory<BlazorHeroUser>>().ReverseMap();
        }
    }
}