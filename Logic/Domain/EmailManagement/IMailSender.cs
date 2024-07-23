namespace DavidTielke.DemoApp.Logic.Domain.EmailManagement;

public interface IMailSender
{
    void Send(string text);
}