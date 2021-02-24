using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AddressBook.Data;
using AddressBook.Models;
using System;
using System.Security.Policy;
using System.Numerics;

namespace AddressBook.Controllers
{
    public class ABContactsController : Controller
    {
        private readonly ContactsContext _context;

        public ABContactsController(ContactsContext context)
        {
            _context = context;
        }

        // GET: ABContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: ABContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aBContacts = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aBContacts == null)
            {
                return NotFound();
            }

            return View(aBContacts);
        }

        // GET: ABContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ABContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Address1,Address2,City,State,ZipCode,Phone")] ABContacts aBContacts)
        {
            if (ModelState.IsValid)
            {
                aBContacts.DateAdded = DateTime.Now;
                _context.Add(aBContacts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aBContacts);
        }

        // GET: ABContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aBContacts = await _context.Contacts.FindAsync(id);
            if (aBContacts == null)
            {
                return NotFound();
            }
            return View(aBContacts);
        }

        // POST: ABContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Address1,Address2,City,State,ZipCode,Phone,DateAdded")] ABContacts aBContacts)
        {
            if (id != aBContacts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aBContacts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ABContactsExists(aBContacts.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aBContacts);
        }

        // GET: ABContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aBContacts = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aBContacts == null)
            {
                return NotFound();
            }

            return View(aBContacts);
        }

        // POST: ABContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aBContacts = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(aBContacts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ABContactsExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
