using ContactsApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Infrastructure.Seeders
{
    public class ContactSeeder
    {
        private readonly ContactDbContext _dbContext;

        public ContactSeeder(ContactDbContext dbContext)
        {
               _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.Contacts.Any())
                {
                    var contact1 = new Domain.Models.Contact()
                    {
                        FirstName = "Andrzej",
                        LastName = "Gołota",
                        Email = "andrew.golec@email.pl",
                        Password = "haslo123",
                        ContactDetails = new Domain.Models.ContactDetails()
                        {
                            Category = "szef", //jeśli category == inny, to można wpisać z łapy subcategory
                            Subcategory = "podkategoria",
                            Phone = "123456789",
                            DateOfBirth = DateTime.Now,
                        }
                    };
                    contact1.EncodeName();
                    _dbContext.Contacts.Add(contact1);

                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
