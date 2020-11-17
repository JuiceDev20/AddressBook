using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
