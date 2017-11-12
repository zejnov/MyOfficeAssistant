using Component.Service.Mail.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Component.Service.Mail
{
    /// <summary>
    /// Send emails using httpmail service.
    /// </summary>
    public class MailClient
    {
        private readonly HttpClient client;
        private readonly string account;
        private readonly string password;
        private const string ServiceUrl = "https://httpmail.azurewebsites.net";

        /// <summary>
        /// Create a new <see cref="MailClient"/>.
        /// </summary>
        /// <param name="account">The email account to use. 
        /// Must be a gmail account. 
        /// The account must be configured to allow less secure apps.</param>
        /// <param name="password">The gmail account's password</param>
        public MailClient(string account, string password)
        {
            client = new HttpClient { BaseAddress = new Uri(ServiceUrl) };
            this.account = account;
            this.password = password;
        }

        /// <summary>
        /// Send a message using the configured account.
        /// </summary>
        /// <param name="to">The email to send the message to.</param>
        /// <param name="subject">The subject of the messsage</param>
        /// <param name="body">The body of the message</param>
        private void Send(Email mail)
        {
            var fields = CreateMailPack(mail);
            var content = new FormUrlEncodedContent(fields);
            client.PostAsync("/api/Message", content).Wait();
        }

        public void SendAsnyc(Email mail)
        {
            //add try catch for no internet connection etc...
            Task.Run(() => Send(mail));
        }

        private IEnumerable<KeyValuePair<string, string>> CreateMailPack(Email mail)
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("to", mail.To),
                new KeyValuePair<string, string>("subject", mail.Subject),
                new KeyValuePair<string, string>("body", mail.Body),
                new KeyValuePair<string, string>("account", account),
                new KeyValuePair<string, string>("password", password)
            };
        }
    }
}