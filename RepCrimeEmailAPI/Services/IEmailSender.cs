namespace RepCrimeEmailAPI.Services
{
    public interface IEmailSender
    {
        void SendEmail(string email);
    }
}