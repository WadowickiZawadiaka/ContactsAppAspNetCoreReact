using ContactsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task Create(Contact contact);
        Task<Contact?> GetByName(string name);
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetByEncodedName(string encodedName);
        Task Commit();
    }
}
