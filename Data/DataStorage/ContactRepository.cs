using DavidTielke.DemoApp.CrossCutting.DataClasses;

namespace DavidTielke.DemoApp.Data.DataStorage
{
    public class ContactRepository : IContactRepository
    {
        public IQueryable<Contact> Query
        {
            get
            {
                var contacts = File
                    .ReadAllLines("contacts.csv")
                    .Select(l => l.Split(","))
                    .Select(p => new Contact
                    {
                        Id = int.Parse(p[0]),
                        Name = p[1],
                        Email = p[2]
                    }).AsQueryable();
                return contacts;
            }
        }

        public void Insert(Contact contact)
        {
            var csvDataLine = $"{contact.Id},{contact.Name},{contact.Email}";
            File.AppendAllLines("contacts.csv", new[] { csvDataLine });
        }
    }
}
