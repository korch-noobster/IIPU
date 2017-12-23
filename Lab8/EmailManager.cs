using System.Net.Mail;

namespace Laba_8
{
    class EmailManager
    {
        private readonly SmtpClient _smtpClient;
       
        private const string sender = "korchhh@mail.ru";
        private const string password = "qazwsx12";

        private const string host = "smtp.mail.ru";
        private const int port = 587;

        public EmailManager()
        {
            _smtpClient = new SmtpClient(host, port)
            {
                Credentials = new System.Net.NetworkCredential(sender, password),
                EnableSsl = true
            };
        }

        public void SendEmail(string receiver, string topic, string filePath)
        {
            var mail = new MailMessage(sender, receiver, topic, string.Empty);
            using (var  attachment = new Attachment(filePath))
            {
                mail.Attachments.Add(attachment);
                _smtpClient.Send(mail);
            }
        }
    }
}
