using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidTielke.DemoApp.CrossCutting.DataClasses;
using DavidTielke.DemoApp.Data.DataStorage;

namespace DavidTielke.DemoApp.Logic.Domain.ContactManagement
{
    public class ContactManager : IContactManager
    {
        private readonly IContactRepository _repository;

        public ContactManager(IContactRepository repository)
        {
            _repository = repository;
        }

        public bool IsExisting(string email)
        {
            var exist = _repository
                .Query
                .Any(c => c.Email == email);
            return exist;
        }

        public IQueryable<Contact> GetByIds(params int[] ids)
        {
            var contacts = _repository
                .Query
                .Where(c => ids.Contains(c.Id));
            return contacts;
        }

        public Contact GetByEmail(string email)
        {
            var contact = _repository
                .Query
                .SingleOrDefault(u => u.Email == email);

            if (contact == null)
            {
                throw new ArgumentException($"User with email {email} not found", nameof(email));
            }

            return contact;
        }

        public void Add(Contact contact)
        {
            _repository.Insert(contact);
        }
    }
}
