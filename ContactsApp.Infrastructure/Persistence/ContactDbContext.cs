using ContactsApp.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Infrastructure.Persistence
{
    public class ContactDbContext : IdentityDbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) :base(options)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>()
                .OwnsOne(c => c.ContactDetails);
        }

        public override int SaveChanges()
        {
            var newContacts = ChangeTracker.Entries<Contact>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity)
                .ToList();

            int result = base.SaveChanges();

            foreach (var contact in newContacts)
            {
                contact.EncodeName();
            }

            base.SaveChanges();
            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var newContacts = ChangeTracker.Entries<Contact>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity)
                .ToList();

            int result = await base.SaveChangesAsync(cancellationToken);

            foreach (var contact in newContacts)
            {
                contact.EncodeName();
            }

            await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
