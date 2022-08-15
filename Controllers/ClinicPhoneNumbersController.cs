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
    public class ClinicPhoneNumbersController : Controller
    {
        private readonly ModelContext _context;
        private decimal clinicId;

        public ClinicPhoneNumbersController(ModelContext context)
        {
            _context = context;
        }

        // GET: ClinicPhoneNumbers
        public async Task<IActionResult> Index(decimal clinicId, string clinicName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.ClinicName = clinicName;
            ViewBag.ClinicId = clinicId;
            #endregion ViewBagElements
            this.clinicId = clinicId;

            var modelContext = _context.ClinicPhoneNumbers.Where(x => x.ClinicId.Equals(clinicId));
            return View(await modelContext.ToListAsync());
        }

        // GET: ClinicPhoneNumbers/Details/5
        public async Task<IActionResult> Details(decimal? id, string clinicName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.ClinicName = clinicName;
            ViewBag.ClinicId = id;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var clinicPhoneNumber = await _context.ClinicPhoneNumbers
                .Include(c => c.Clinic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicPhoneNumber == null)
            {
                return NotFound();
            }

            return View(clinicPhoneNumber);
        }

        // GET: ClinicPhoneNumbers/Create
        public IActionResult Create(decimal clinicId, string clinicName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.ClinicId = clinicId;
            ViewBag.ClinicName = clinicName;
            #endregion ViewBagElements

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClinicId,PhoneNumber")] ClinicPhoneNumber clinicPhoneNumber, decimal clinicId, string clinicName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            #endregion ViewBagElements

            clinicPhoneNumber.ClinicId = clinicId;
            if (ModelState.IsValid)
            {
                _context.Add(clinicPhoneNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { clinicId, clinicName });
            }
            ViewData["ClinicId"] = new SelectList(_context.Clinics, "Id", "ClinicName", clinicPhoneNumber.ClinicId);
            return View(clinicPhoneNumber);
        }

        // GET: ClinicPhoneNumbers/Edit/5
        public async Task<IActionResult> Edit(decimal? id, string clinicName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.ClinicName = clinicName;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var clinicPhoneNumber = await _context.ClinicPhoneNumbers.FindAsync(id);
            if (clinicPhoneNumber == null)
            {
                return NotFound();
            }
            ViewData["ClinicId"] = new SelectList(_context.Clinics, "Id", "ClinicName", clinicPhoneNumber.ClinicId);
            return View(clinicPhoneNumber);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,ClinicId,PhoneNumber")] ClinicPhoneNumber clinicPhoneNumber, decimal clinicId, string clinicName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.ClinicName = clinicName;
            #endregion ViewBagElements

            if (id != clinicPhoneNumber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinicPhoneNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicPhoneNumberExists(clinicPhoneNumber.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { clinicId, clinicName });
            }
            ViewData["ClinicId"] = new SelectList(_context.Clinics, "Id", "ClinicName", clinicPhoneNumber.ClinicId);
            return View(clinicPhoneNumber);
        }

        // GET: ClinicPhoneNumbers/Delete/5
        public async Task<IActionResult> Delete(decimal? id, string clinicName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.ClinicName = clinicName;
            ViewBag.ClinicId = id;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var clinicPhoneNumber = await _context.ClinicPhoneNumbers
                .Include(c => c.Clinic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicPhoneNumber == null)
            {
                return NotFound();
            }

            return View(clinicPhoneNumber);
        }

        // POST: ClinicPhoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id, decimal clinicId, string clinicName)
        {
            var clinicPhoneNumber = await _context.ClinicPhoneNumbers.FindAsync(id);
            _context.ClinicPhoneNumbers.Remove(clinicPhoneNumber);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { clinicId, clinicName });
        }

        private bool ClinicPhoneNumberExists(decimal id)
        {
            return _context.ClinicPhoneNumbers.Any(e => e.Id == id);
        }
    }
}
