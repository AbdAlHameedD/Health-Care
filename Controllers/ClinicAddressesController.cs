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
    public class ClinicAddressesController : Controller
    {
        private readonly ModelContext _context;
        private decimal clinicId;

        public ClinicAddressesController(ModelContext context)
        {
            _context = context;
        }

        // GET: ClinicAddresses
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

            var modelContext = _context.ClinicAddresses.Where(x => x.ClinicId.Equals(clinicId));
            return View(await modelContext.ToListAsync());
        }

        // GET: ClinicAddresses/Details/5
        public async Task<IActionResult> Details(decimal? id, string clinicName)
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

            var clinicAddress = await _context.ClinicAddresses
                .Include(c => c.Clinic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicAddress == null)
            {
                return NotFound();
            }

            return View(clinicAddress);
        }

        // GET: ClinicAddresses/Create
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
        public async Task<IActionResult> Create([Bind("Id,ClinicId,Country,City,Street,BuildingNumber")] ClinicAddress clinicAddress, decimal clinicId, string clinicName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            #endregion ViewBagElements

            clinicAddress.ClinicId = clinicId;
            if (ModelState.IsValid)
            {
                _context.Add(clinicAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { clinicId, clinicName });
            }
            ViewData["ClinicId"] = new SelectList(_context.Clinics, "Id", "ClinicName", clinicAddress.ClinicId);
            return View(clinicAddress);
        }

        // GET: ClinicAddresses/Edit/5
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

            var clinicAddress = await _context.ClinicAddresses.FindAsync(id);
            if (clinicAddress == null)
            {
                return NotFound();
            }
            ViewData["ClinicId"] = new SelectList(_context.Clinics, "Id", "ClinicName", clinicAddress.ClinicId);
            return View(clinicAddress);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,ClinicId,Country,City,Street,BuildingNumber")] ClinicAddress clinicAddress, decimal clinicId, string clinicName)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.ClinicName = clinicName;
            #endregion ViewBagElements

            if (id != clinicAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinicAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicAddressExists(clinicAddress.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new {clinicId, clinicName});
            }
            ViewData["ClinicId"] = new SelectList(_context.Clinics, "Id", "ClinicName", clinicAddress.ClinicId);
            return View(clinicAddress);
        }

        // GET: ClinicAddresses/Delete/5
        public async Task<IActionResult> Delete(decimal? id, string clinicName)
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

            var clinicAddress = await _context.ClinicAddresses
                .Include(c => c.Clinic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicAddress == null)
            {
                return NotFound();
            }

            return View(clinicAddress);
        }

        // POST: ClinicAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id, decimal clinicId, string clinicName)
        {
            var clinicAddress = await _context.ClinicAddresses.FindAsync(id);
            _context.ClinicAddresses.Remove(clinicAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { clinicId, clinicName });
        }

        private bool ClinicAddressExists(decimal id)
        {
            return _context.ClinicAddresses.Any(e => e.Id == id);
        }
    }
}
