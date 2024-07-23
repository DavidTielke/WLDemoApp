using DavidTielke.DemoApp.CrossCutting.DataClasses;

namespace DavidTielke.DemoApp.Logic.Domain.ContactManagement;

public interface IContactManager
{
    bool IsExisting(string email);
    IQueryable<Contact> GetByIds(params int[] ids);
    Contact GetByEmail(string email);
    void Add(Contact contact);
}