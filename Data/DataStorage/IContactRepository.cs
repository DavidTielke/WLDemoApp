using DavidTielke.DemoApp.CrossCutting.DataClasses;

namespace DavidTielke.DemoApp.Data.DataStorage;

public interface IContactRepository
{
    IQueryable<Contact> Query { get; }
    void Insert(Contact contact);
}