namespace RepCrimeEmailAPI.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
            => _config = config;

        public void SendEmail(string email)
        {
            var mialToSend = GetMailToSend(email);
            using var mailClient = GetMailClient();
            mailClient.Send(mialToSend);
        }

        private SmtpClient GetMailClient()
        => new()
        {
            Credentials = new NetworkCredential(_config["MailSettings:Login"], _config["MailSettings:Password"]),
            Port = int.Parse(_config["MailSettings:Port"]),
            Host = _config["MailSettings:Host"],
            EnableSsl = true
        };

        private MailMessage GetMailToSend(string email)
        {
            var mailMessage = new MailMessage()
            {
                From = new MailAddress(_config["MailSettings:Login"]),
                SubjectEncoding = Encoding.UTF8,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true,
                Priority = MailPriority.High,

                Subject = "Report Crime",
                Body = "Thank you for your submition, an enforcer was assigned"
            };

            mailMessage.To.Add(email);
            mailMessage.ReplyToList.Add(_config["MailSettings:Login"]);
            return mailMessage;
        }
    }
}
    