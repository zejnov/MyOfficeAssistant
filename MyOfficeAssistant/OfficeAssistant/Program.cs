using Component.Service.Mail;
using Component.Service.Mail.Domain;
using System;

namespace OfficeAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new MailDispatcher();
            var mail = new Email
            {
                To = "zejnov@gmail.com",
                Subject = "Hello from app",
                Body = $"Hi at {DateTime.UtcNow} from Mateuszeks program :D"
            };

            var test = sender.SendToMany(mail);

            Console.Write(test);
            Console.ReadKey();
        }
    }
}
