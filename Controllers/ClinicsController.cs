using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Health_Care_V1._2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Health_Care_V1._2.Controllers
{
    public class Clinics
    {
        public Clinic Clinic { get; set; }
        public List<ClinicAddress> ClinicAddresses { get; set; }
        public List<ClinicPhoneNumber> ClinicPhoneNumbers { get; set; }

        public Clinics(Clinic clinic)
        {
            Clinic = clinic;
        }
    }

    public class ClinicsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public ClinicsController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }

        // GET: Clinics
        public IActionResult Index()
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            #endregion ViewBagElements

            List<Clinics> clinics = new List<Clinics>();

            var query = from clinic in _context.Clinics select clinic;
            foreach (var clinic in query)
            {
                Clinics clinc = new Clinics(clinic);

                var addresses = (from cl in _context.ClinicAddresses
                                 where cl.ClinicId == clinc.Clinic.Id
                                 select cl).ToList();
                clinc.ClinicAddresses = addresses;

                var phoneNumbers = (from ph in _context.ClinicPhoneNumbers
                                    where ph.ClinicId == clinc.Clinic.Id
                                    select ph).ToList();
                clinc.ClinicPhoneNumbers = phoneNumbers;

                clinics.Add(clinc);
            }


            return View(clinics);
        }

        // GET: Clinics/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.Addresses = (from address in _context.ClinicAddresses
                                 where address.ClinicId.Equals(id)
                                 select address).ToList();

            ViewBag.PhoneNumbers = (from phoneNumber in _context.ClinicPhoneNumbers
                                    where phoneNumber.ClinicId.Equals(id)
                                    select phoneNumber).ToList();
            ViewBag.ClinicId = id;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var clinic = await _context.Clinics
                .FirstOrDefaultAsync(m => m.Id == id);

            

            if (clinic == null)
            {
                return NotFound();
            }

            return View(clinic);
        }

        // GET: Clinics/Create
        public IActionResult Create(string clinicNameErrorMsg=null)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.ClinicNameErrorMsg = clinicNameErrorMsg;
            #endregion ViewBagElements

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClinicName,AdditionDate,ClinicLogo,ImageFile")] Clinic clinic)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            #endregion ViewBagElements

            #region ClinicNameUniqueness
            string ClinicNameErrorMsg = null;
            if (ClinicNameExists(clinic.ClinicName))
            {
                ClinicNameErrorMsg = "Clinic already exists";
                return RedirectToAction("Create", new { ClinicNameErrorMsg });
            }
            #endregion ClinicNameUniqueness

            if (!(clinic.ImageFile is null))
            {
                string wwwRootPath = _webHostEnviroment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + clinic.ImageFile.FileName;
                string path = Path.Combine(wwwRootPath + "/images/clinics-logo/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await clinic.ImageFile.CopyToAsync(fileStream);
                }
                clinic.ClinicLogo = fileName;
            }
            

            if (ModelState.IsValid)
            {
                _context.Add(clinic);
                await _context.SaveChangesAsync();

                ClinicRate clinicRate = new ClinicRate();
                clinicRate.CreationDate = DateTime.Now;
                clinicRate.Rate = 5;
                clinicRate.ClinicId = clinic.Id;

                _context.Add(clinicRate);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(clinic);
        }

        // GET: Clinics/Edit/5
        public async Task<IActionResult> Edit(decimal? id, string clinicNameErrorMsg = null)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.ClinicNameErrorMsg = clinicNameErrorMsg;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var clinic = await _context.Clinics.FindAsync(id);
            if (clinic == null)
            {
                return NotFound();
            }
            return View(clinic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,ClinicName,AdditionDate,ClinicLogo,ImageFile")] Clinic clinic)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            #endregion ViewBagElements

            if (id != clinic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(!(clinic.ImageFile is null))
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + clinic.ImageFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/images/clinics-logo/", fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await clinic.ImageFile.CopyToAsync(fileStream);
                        }
                        clinic.ClinicLogo = fileName;
                    }
                    else
                    {
                        clinic.ClinicLogo = _context.Clinics.Where(x => x.Id.Equals(clinic.Id)).Select(x => x.ClinicLogo).FirstOrDefault();
                    }

                    _context.Update(clinic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicExists(clinic.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                #region ClinicNameUniqueness
                catch (DbUpdateException)
                {
                    string clinicNameErrorMsg = null;

                    if (ClinicNameExists(clinic.ClinicName))
                    {
                        clinicNameErrorMsg = "Phone number already exists";
                    }
                    return RedirectToAction("Edit", new { id, clinicNameErrorMsg });
                }
                #endregion ClinicNameUniqueness

                return RedirectToAction(nameof(Index));
            }
            return View(clinic);
        }

        // GET: Clinics/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.Addresses = (from address in _context.ClinicAddresses
                                 where address.ClinicId.Equals(id)
                                 select address).ToList();

            ViewBag.PhoneNumbers = (from phoneNumber in _context.ClinicPhoneNumbers
                                    where phoneNumber.ClinicId.Equals(id)
                                    select phoneNumber).ToList();
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var clinic = await _context.Clinics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinic == null)
            {
                return NotFound();
            }

            return View(clinic);
        }

        // POST: Clinics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            #endregion ViewBagElements

            var clinic = await _context.Clinics.FindAsync(id);
            _context.Clinics.Remove(clinic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicExists(decimal id)
        {
            return _context.Clinics.Any(e => e.Id == id);
        }
        private bool ClinicNameExists(string clinicName)
        {
            var query = (from clinic in _context.Clinics
                         select clinic);

            return query.Any(e => e.ClinicName.ToLower() == clinicName.ToLower());
        }
    }
}
