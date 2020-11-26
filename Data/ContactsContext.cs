using AddressBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Data
{
    public class ContactsContext : DbContext 
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {

        }
        public DbSet<ABContacts> Contacts { get; set; }

    }
}
