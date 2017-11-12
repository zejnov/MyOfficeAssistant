using Component.Service.Mail.Domain;

namespace Component.Service.Mail
{
    public class MailDispatcher
    {
        public string SendToMany(Email mail)
        {
            var mailClient = new MailClient("zejnov.net@gmail.com", "miszczu89");

            string[] adresses = mail.To.Split(',');

            for(int i=0; i<10; i++)
            {
                foreach (var adress in adresses)
                {
                    //sendAsync
                    mailClient.Send(
                        new Email { To = adress, Subject = mail.Subject, Body = mail.Body });
                }
            }
            

            return $"Email '{mail.Subject}' sended to {mail.To}";
        }
    }
}
