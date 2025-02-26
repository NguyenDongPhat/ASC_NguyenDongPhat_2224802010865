using Microsoft.AspNetCore.Mvc;

namespace ASC.Solution.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

