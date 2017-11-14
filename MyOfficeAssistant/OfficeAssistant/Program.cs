using Component.Service.Mail;
using Component.Service.Mail.Domain;
using System;
using OfficeAssistant.Application;

namespace OfficeAssistant
{
    class Program
    {
        static void Main()
        {
            new Assistant().Run();
        }

        public void MailSending()
        {
            var sender = new MailDispatcher();
            var mail = new Email
            {
                To = "zejnov@gmail.com",
                Subject = "Hello again from app",
                Body = $"Hi at {DateTime.UtcNow} from ZjV program :D"
            };

            sender.Send(mail);

            Console.Write("mail sended");
            Console.ReadKey();

        }
    }
}
