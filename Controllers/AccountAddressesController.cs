using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Health_Care_V1._2.Models;
using Microsoft.AspNetCore.Http;

namespace Health_Care_V1._2.Controllers
{
    public class AccountAddressesController : Controller
    {
        private readonly ModelContext _context;
        private decimal accountId;
        private string accountName;

        public AccountAddressesController(ModelContext context)
        {
            _context = context;
        }

        // GET: AccountAddresses
        public async Task<IActionResult> Index(decimal accountId, string accountName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            ViewBag.AccountId1 = accountId;
            #endregion ViewBagElements
            this.accountId = accountId;
            this.accountName = accountName;

            var modelContext = _context.AccountAddresses.Where(x => x.AccountId.Equals(accountId));
            return View(await modelContext.ToListAsync());
        }

        // GET: AccountAddresses/Details/5
        public async Task<IActionResult> Details(decimal? id, string accountName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var accountAddress = await _context.AccountAddresses
                .Include(a => a.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountAddress == null)
            {
                return NotFound();
            }

            return View(accountAddress);
        }

        // GET: AccountAddresses/Create
        public IActionResult Create(decimal accountId, string accountName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            ViewBag.AccountId1 = accountId;
            #endregion ViewBagElements

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountId,Country,City")] AccountAddress accountAddress, decimal accountId, string accountName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            #endregion ViewBagElements

            accountAddress.AccountId = accountId;
            if (ModelState.IsValid)
            {
                _context.Add(accountAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { accountId, accountName });
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Email", accountAddress.AccountId);
            return View(accountAddress);
        }

        // GET: AccountAddresses/Edit/5
        public async Task<IActionResult> Edit(decimal? id, string accountName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var accountAddress = await _context.AccountAddresses.FindAsync(id);
            if (accountAddress == null)
            {
                return NotFound();
            }
            ViewData["AccountId1"] = new SelectList(_context.Accounts, "Id", "Email", accountAddress.AccountId);
            return View(accountAddress);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,AccountId,Country,City")] AccountAddress accountAddress, decimal accountId, string accountName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            #endregion ViewBagElements

            if (id != accountAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountAddressExists(accountAddress.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { accountId, accountName });
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Email", accountAddress.AccountId);
            return View(accountAddress);
        }

        // GET: AccountAddresses/Delete/5
        public async Task<IActionResult> Delete(decimal? id, string accountName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var accountAddress = await _context.AccountAddresses
                .Include(a => a.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountAddress == null)
            {
                return NotFound();
            }

            return View(accountAddress);
        }

        // POST: AccountAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id, decimal accountId, string accountName)
        {
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");

            var accountAddress = await _context.AccountAddresses.FindAsync(id);
            _context.AccountAddresses.Remove(accountAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { accountId, accountName });
        }

        private bool AccountAddressExists(decimal id)
        {
            return _context.AccountAddresses.Any(e => e.Id == id);
        }
    }
}
