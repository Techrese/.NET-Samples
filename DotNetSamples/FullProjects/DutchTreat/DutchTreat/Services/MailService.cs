using DutchTreat.Services.Abstractions;

namespace DutchTreat.Services
{
    public class MailService: IMailService
    {
        private readonly ILogger<MailService> _logger;

        public MailService(ILogger<MailService> logger)
        {
            _logger = logger;
        }

        public void Send(string to, string subject, string body)
        {
            _logger.LogInformation($"To: {to}, From: {subject}, body: {body}");
        }
    }
}
