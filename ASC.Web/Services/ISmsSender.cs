using Microsoft.AspNetCore.Mvc;

namespace ASC.Solution.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}

