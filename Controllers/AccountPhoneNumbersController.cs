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
    public class AccountPhoneNumbersController : Controller
    {
        private readonly ModelContext _context;
        private decimal accountId;
        private string accountName;

        public AccountPhoneNumbersController(ModelContext context)
        {
            _context = context;
        }

        // GET: AccountPhoneNumbers
        public async Task<IActionResult> Index(decimal accountId, string accountName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Permission = HttpContext.Session.GetString("Permission");
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            ViewBag.AccountId1 = accountId;
            #endregion ViewBagElements
            this.accountId = accountId;
            this.accountName = accountName;

            var modelContext = _context.AccountPhoneNumbers.Where(x => x.AccountId.Equals(accountId));
            return View(await modelContext.ToListAsync());
        }

        // GET: AccountPhoneNumbers/Details/5
        public async Task<IActionResult> Details(decimal? id, string accountName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Permission = HttpContext.Session.GetString("Permission");
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            ViewBag.AccountId1 = id;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var accountPhoneNumber = await _context.AccountPhoneNumbers
                .Include(a => a.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountPhoneNumber == null)
            {
                return NotFound();
            }

            return View(accountPhoneNumber);
        }

        // GET: AccountPhoneNumbers/Create
        public IActionResult Create(decimal accountId, string accountName, string phoneNumberErrorMsg=null)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.Permission = HttpContext.Session.GetString("Permission");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            ViewBag.AccountId1 = accountId;
            ViewBag.PhoneNumberErrorMsg = phoneNumberErrorMsg;
            #endregion ViewBagElements

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountId,PhoneNumber")] AccountPhoneNumber accountPhoneNumber, decimal accountId, string accountName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.Permission = HttpContext.Session.GetString("Permission");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            #endregion ViewBagElements

            #region CheckUniquenessPhoneNumber
            string phoneNumberErrorMsg = null;
            if (PhoneNumberExists(accountPhoneNumber.PhoneNumber))
            {
                phoneNumberErrorMsg = "Phone number already exists";
                return RedirectToAction("Create", new { accountId, accountName, phoneNumberErrorMsg });
            }
            #endregion CheckUniquenessPhoneNumber

            accountPhoneNumber.AccountId = accountId;
            if (ModelState.IsValid)
            {
                _context.Add(accountPhoneNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { accountId, accountName });
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Email", accountPhoneNumber.AccountId);
            return View(accountPhoneNumber);
        }

        // GET: AccountPhoneNumbers/Edit/5
        public async Task<IActionResult> Edit(decimal? id, string accountName, string phoneNumberErrorMsg=null)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.Permission = HttpContext.Session.GetString("Permission");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            ViewBag.AccountId1 = id;
            ViewBag.PhoneNumberErrorMsg = phoneNumberErrorMsg;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var accountPhoneNumber = await _context.AccountPhoneNumbers.FindAsync(id);
            if (accountPhoneNumber == null)
            {
                return NotFound();
            }
            return View(accountPhoneNumber);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,AccountId,PhoneNumber")] AccountPhoneNumber accountPhoneNumber, decimal accountId, string accountName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.Permission = HttpContext.Session.GetString("Permission");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            #endregion ViewBagElements

            if (id != accountPhoneNumber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountPhoneNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountPhoneNumberExists(accountPhoneNumber.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException)
                {
                    string phoneNumberErrorMsg = null;

                    if (PhoneNumberExists(accountPhoneNumber.PhoneNumber))
                    {
                        phoneNumberErrorMsg = "Phone number already exists";
                    }
                    return RedirectToAction("Edit", new { accountId, accountName, phoneNumberErrorMsg });
                }
                return RedirectToAction("Index", new { accountId, accountName });
            }
            return View(accountPhoneNumber);
        }

        // GET: AccountPhoneNumbers/Delete/5
        public async Task<IActionResult> Delete(decimal? id, string accountName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.Permission = HttpContext.Session.GetString("Permission");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountName = accountName;
            ViewBag.AccountId1 = id;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var accountPhoneNumber = await _context.AccountPhoneNumbers
                .Include(a => a.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountPhoneNumber == null)
            {
                return NotFound();
            }

            return View(accountPhoneNumber);
        }

        // POST: AccountPhoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id, decimal accountId, string accountName)
        {
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");

            var accountPhoneNumber = await _context.AccountPhoneNumbers.FindAsync(id);
            _context.AccountPhoneNumbers.Remove(accountPhoneNumber);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { accountId, accountName });
        }

        private bool AccountPhoneNumberExists(decimal id)
        {
            return _context.AccountPhoneNumbers.Any(e => e.Id == id);
        }

        private bool PhoneNumberExists(decimal phoneNumber)
        {
            var query = (from ph in _context.AccountPhoneNumbers 
                         select ph);

            return query.Any(x => x.PhoneNumber == phoneNumber);
        }
    }
}
