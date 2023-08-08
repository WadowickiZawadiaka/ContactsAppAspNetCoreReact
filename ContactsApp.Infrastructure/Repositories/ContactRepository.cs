using ContactsApp.Domain.Interfaces;
using ContactsApp.Domain.Models;
using ContactsApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _dbContext;

        public ContactRepository(ContactDbContext dbContext)
        {
            _dbContext = dbContext;   
        }

        public Task Commit()
            => _dbContext.SaveChangesAsync();

        public async Task Create(Contact contact)
        {
            _dbContext.Add(contact);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contact>> GetAll()
            => await _dbContext.Contacts.ToListAsync();

        public Task<Contact> GetByEncodedName(string encodedName)
            => _dbContext.Contacts.FirstAsync(c => c.EncodedName == encodedName);

        public Task<Contact?> GetByName(string name)
            => _dbContext.Contacts.FirstOrDefaultAsync(c => c.Email.ToLower() == name.ToLower());
    }
}
