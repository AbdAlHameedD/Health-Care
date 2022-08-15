using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Health_Care_V1._2.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Health_Care_V1._2.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public AccountsController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            #endregion ViewBagElements

            return View(await _context.Accounts.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountId1 = id;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create(string usernameErrorMsg = null, string emailErrorMsg = null, string usernameRegex = null)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.UsernameErrorMsg = usernameErrorMsg;
            ViewBag.EmailErrorMsg = emailErrorMsg;
            ViewBag.UsernameRegex = usernameRegex;
            #endregion ViewBagElements

            ViewData["ClinicsId1"] =
                new SelectList((from cli in _context.Clinics
                                select new
                                {
                                    ID = cli.Id,
                                    ClinicName = cli.ClinicName
                                }),
                "ID",
                "ClinicName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,Email,Fname,Mname,Lname,Gender,Bod,Status,Permission,CreationDate,ProfilePicture,ImageFile")] Account account,
            decimal? salary=null, decimal? clinicId=null)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            #endregion ViewBagElements

            //try
            //{
                if (ModelState.IsValid)
                {
                    #region UsernameRegex
                    string usernameRegex = null;
                    if (!IsUsername(account.Username))
                    {
                        usernameRegex = "Invaild format, Can contain numbers and letters only, First character must be letter, Min Length is 8, Max Length is 20.";

                        return RedirectToAction("Create", new { usernameRegex = usernameRegex });
                    }
                    #endregion UsernameRegex

                    
                    if (account.ImageFile is null)
                    {
                        if (account.Gender == "M")
                        {
                            account.ProfilePicture = "male-default-profile-picture.png";
                        }
                        else
                        {
                            account.ProfilePicture = "female-default-profile-picture.png";
                        }
                    }
                    else
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + account.ImageFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/images/profile-pictures/", fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await account.ImageFile.CopyToAsync(fileStream);
                        }
                        account.ProfilePicture = fileName;
                    }

                    _context.Add(account);
                    await _context.SaveChangesAsync();
                    
                    if (account.Permission == "DOCTOR")
                    {
                        Employee employee = new Employee();
                        employee.AccountId = account.Id;
                        employee.Salary = (decimal)salary;
                        employee.ClinicId = clinicId;

                        _context.Add(employee);
                        await _context.SaveChangesAsync();

                        DoctorRate doctorRate = new DoctorRate();
                        doctorRate.DoctorId = employee.Id;
                        doctorRate.CreationDate = DateTime.Now;
                        doctorRate.Rate = 5;

                        _context.Add(doctorRate);
                        await _context.SaveChangesAsync();
                }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Create", "Accounts");
                }
            //}

            #region CatchUniqueConstraintViolated
            //catch (DbUpdateException)
            //{
            //    string usernameErrorMsg = null;
            //    string emailErrorMsg = null;

            //    if (UsernameExists(account.Username))
            //    {
            //        usernameErrorMsg = "Username already exists";
            //    }
            //    if (EmailExists(account.Email))
            //    {
            //        emailErrorMsg = "Email already exists";
            //    }
            //    return RedirectToAction("Create", new { usernameErrorMsg, emailErrorMsg });
            //}
            #endregion CatchUniqueConstraintViolated
        }

        // GET: Accounts/Edit/
        public async Task<IActionResult> Edit(decimal? id, string usernameErrorMsg=null, string emailErrorMsg=null, string usernameRegex=null)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.UsernameErrorMsg = usernameErrorMsg;
            ViewBag.EmailErrorMsg = emailErrorMsg;
            ViewBag.UsernameRegex = usernameRegex;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Username,Password,Email,Fname,Mname,Lname,Gender,Bod,Status,Permission,CreationDate,ProfilePicture,ImageFile")] Account account)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";
            #endregion ViewBagElements

            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    #region UsernameRegex
                    string usernameRegex = null;
                    if (!IsUsername(account.Username))
                    {
                        usernameRegex = "Invaild format, Can contain numbers and letters only, First character must be letter, Min Length is 8, Max Length is 20.";

                        return RedirectToAction("Edit", new { id, usernameRegex=usernameRegex });
                    }
                    #endregion UsernameRegex

                    if (!(account.ImageFile is null))
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + account.ImageFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/images/profile-pictures/", fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await account.ImageFile.CopyToAsync(fileStream);
                        }
                        account.ProfilePicture = fileName;
                    }
                    else
                    {
                        account.ProfilePicture = _context.Accounts.Where(x => x.Id.Equals(account.Id)).Select(x => x.ProfilePicture).FirstOrDefault();
                    }

                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists((int)account.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                #region CatchUniqueConstraintViolated
                catch (DbUpdateException)
                {
                    string usernameErrorMsg = null;
                    string emailErrorMsg = null;

                    if (UsernameExists(account.Username, id))
                    {
                        usernameErrorMsg = "Username already exists";
                    }
                    if (EmailExists(account.Email, id))
                    {
                        emailErrorMsg = "Email already exists";
                    }
                    return RedirectToAction("Edit", new {id, usernameErrorMsg, emailErrorMsg });
                }
                #endregion CatchUniqueConstraintViolated

                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountLinkStatus = "nav-item active";
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AccountLinkStatus = "nav-item active";

            var account = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(decimal id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
        private bool EmailExists(string email, decimal id)
        {
            var query = (from account in _context.Accounts
                         where !account.Id.Equals(id)
                         select account);

            return query.Any(e => e.Email.ToLower() == email.ToLower());
        }
        private bool UsernameExists(string username, decimal id)
        {
            var query = (from account in _context.Accounts
                         where !account.Id.Equals(id)
                         select account);

            return query.Any(e => e.Username.ToLower() == username.ToLower());
        }
        private bool EmailExists(string email)
        {
            var query = (from account in _context.Accounts
                         select account);

            return query.Any(e => e.Email.ToLower() == email.ToLower());
        }
        private bool UsernameExists(string username)
        {
            var query = (from account in _context.Accounts
                         select account);

            return query.Any(e => e.Username.ToLower() == username.ToLower());
        }
        private static bool IsUsername(string username)
        {
            string pattern = @"^(?=.{8,15}$)([A-Za-z0-9]?)*$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(username);
        }
    }
}
