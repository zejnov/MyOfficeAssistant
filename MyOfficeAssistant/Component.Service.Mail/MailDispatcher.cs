using Component.Service.Mail.Domain;

namespace Component.Service.Mail
{
    public class MailDispatcher
    {
        private readonly MailClient _mailClient;

        public MailDispatcher()
        {
            _mailClient = new MailClient("zejnov.net@gmail.com", "miszczu89");
        }

        public void Send(Email mail)
        {
            _mailClient.SendAsnyc(
                new Email
                {
                    To = mail.To,
                    Subject = mail.Subject,
                    Body = mail.Body
                });
        }

        public void SendToMany(Email mail)
        {
            string[] adresses = mail.To.Split(',');
            
            foreach (var adress in adresses)
            {
                _mailClient.SendAsnyc(
                    new Email { To = adress,
                                Subject = mail.Subject,
                                Body = mail.Body 
                    });
            }
        }
    }
}
