using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidTielke.DemoApp.Logic.Domain.EmailManagement
{
    public class MailSender : IMailSender
    {
        public void Send(string text)
        {
            Console.WriteLine($"Email wird gesendet: {text}");
        }
    }
}
