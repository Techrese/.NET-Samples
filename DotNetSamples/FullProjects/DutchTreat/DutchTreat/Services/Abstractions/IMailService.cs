namespace DutchTreat.Services.Abstractions
{
    public interface IMailService
    {
        void Send(string to, string subject, string body);
    }
}
