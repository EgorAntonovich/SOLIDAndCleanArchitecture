using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Persistence.Models;

namespace HR.LeaveManagement.Application.Contracts.Persistence.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}