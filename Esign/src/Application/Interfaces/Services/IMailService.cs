using Esign.Application.Requests.Mail;
using System.Threading.Tasks;

namespace Esign.Application.Interfaces.Services
{
    public interface IMailService
    {
        void SendAsync(MailRequest request);
    }
}