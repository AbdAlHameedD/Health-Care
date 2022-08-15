using Health_Care_V1._2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Health_Care_V1._2.Controllers
{
    public class LoginAndRegisterController : Controller
    {
        private readonly ModelContext _context;

        public LoginAndRegisterController(ModelContext context)
        {
            _context = context;
        }

        private async void InsertLog(decimal accountId)
        {
            /*
             * Full and insert record in Log table in database
             */

            #region InsertLogImplementation
            Log log = new Log();
            log.AccountId = accountId;
            log.LoginDate = DateTime.Now;
            _context.Add(log);
            await _context.SaveChangesAsync();
            #endregion InsertLogImplementation
        }

        private bool IsAccountInformationValid(string username, string password)
        {
            /*
             * Return boolean type
             * that represent status of login
             * and availability of username and password
             */

            #region IsAccountInformationValidImplementation
            var accounts = (from account
                            in _context.Accounts
                            where account.Username == username &&
                            account.Password == password
                            select new
                            {
                                ID = account.Id,
                                Username = account.Username,
                                Password = account.Password,
                                Fname = account.Fname,
                                Mname = account.Mname,
                                Lname = account.Lname,
                                ProfilePicture = account.ProfilePicture,
                                Email = account.Email,
                                Permission = account.Permission
                            }).ToList();

            if (accounts.Count == 1)
            {
                InsertLog(accounts[0].ID);

                HttpContext.Session.SetInt32("AccountId", (int)accounts[0].ID);
                HttpContext.Session.SetString("Fname", accounts[0].Fname);
                HttpContext.Session.SetString("Mname", accounts[0].Mname);
                HttpContext.Session.SetString("Lname", accounts[0].Lname);
                HttpContext.Session.SetString("ProfilePicture", accounts[0].ProfilePicture);
                HttpContext.Session.SetString("Email", accounts[0].Email);
                HttpContext.Session.SetString("Permission", accounts[0].Permission);
                H.IsLoggedIn = true;

                if (accounts[0].Permission == "DOCTOR")
                {
                    var doctorId = (from emp in _context.Employees
                                    where emp.AccountId == accounts[0].ID
                                    select emp.Id).FirstOrDefault();

                    HttpContext.Session.SetInt32("DoctorId", (int)doctorId);
                }

                return true;
            }
            return false;
            #endregion IsAccountInformationValidImplementation
        }
        private bool CheckAccountStatus(string username)
        {
            return (from acc in _context.Accounts
                    where acc.Username == username &&
                    acc.Status == "BLOCK"
                    select acc).Any();
        }
        public IActionResult Index()
        {
            return View();
        }

        public bool IsUsernameAvailable(string username)
        {
            var searchData = _context.Accounts.Where(a => a.Username == username).Count();

            if (searchData > 0)
            {
                return false;
            }
            return true;
        }

        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            H.IsLoggedIn = false;

            #region LayoutData
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.headerLinkTable = (from link in _context.HeaderLinks select link).ToList();
            ViewBag.clinicNames = (from clinic in _context.Clinics select clinic.ClinicName).ToList();
            ViewBag.footerLinks = (from link in _context.FooterQuickLinks select link).ToList();
            ViewBag.footerServices = (from service in _context.FooterServices select service).ToList();
            #endregion LayoutData

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            #region LayoutData
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.headerLinkTable = (from link in _context.HeaderLinks select link).ToList();
            ViewBag.clinicNames = (from clinic in _context.Clinics select clinic.ClinicName).ToList();
            ViewBag.footerLinks = (from link in _context.FooterQuickLinks select link).ToList();
            ViewBag.footerServices = (from service in _context.FooterServices select service).ToList();
            #endregion LayoutData

            #region LoginImplementation
            ViewBag.Status = "";
            username = username.ToLower();

            if (CheckAccountStatus(username) == true)
            {
                ViewBag.status = "This account is blocked";
                return View();
            }

            if (IsAccountInformationValid(username, password))
            {
                ViewBag.Permission = HttpContext.Session.GetString("Permission");
                if (HttpContext.Session.GetString("Permission") == "ADMIN")
                {
                    return RedirectToAction("Index", "AdminDashboard");
                }
                else if (HttpContext.Session.GetString("Permission") == "DOCTOR")
                {
                    return RedirectToAction("Index", "DoctorDashboard");
                }
                else
                {
                    return RedirectToAction("Appointments", "PatientDashboard");
                }
                    
            }
            else
            {
                ViewBag.Status = "- Username or Password wrong";
            }
            #endregion LoginImplementation

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            #region LayoutData
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.headerLinkTable = (from link in _context.HeaderLinks select link).ToList();
            ViewBag.clinicNames = (from clinic in _context.Clinics select clinic.ClinicName).ToList();
            ViewBag.footerLinks = (from link in _context.FooterQuickLinks select link).ToList();
            ViewBag.footerServices = (from service in _context.FooterServices select service).ToList();
            #endregion LayoutData

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register
            ([Bind("Id, Username, Password, Email," +
            " Fname, Mname, Lname, Gender, Bod, " +
            "Status", "Permission", "CreationDate", "ProfilePicture")] Account account)
        {
            #region LayoutData
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.headerLinkTable = (from link in _context.HeaderLinks select link).ToList();
            ViewBag.clinicNames = (from clinic in _context.Clinics select clinic.ClinicName).ToList();
            ViewBag.footerLinks = (from link in _context.FooterQuickLinks select link).ToList();
            ViewBag.footerServices = (from service in _context.FooterServices select service).ToList();
            #endregion LayoutData

            ViewBag.UsernameStatus = "";
            ViewBag.EmailStatus = "";

            #region RegisterImplementation
            if (ModelState.IsValid)
            {
                account.Username = account.Username.ToLower();
                account.Email = account.Email.ToLower();

                var checkAccInf = (from username
                                     in _context.Accounts
                                     where username.Username.Equals(account.Username) ||
                                     username.Email.Equals(account.Email)
                                     select username).FirstOrDefault();

                
                if (checkAccInf is null)      // IF username and email doesn't exist THEN
                {
                    if (account.Gender == "M")
                        account.ProfilePicture = "male-default-profile-picture.png";
                    else account.ProfilePicture = "female-default-profile-picture.png";

                    account.Status = "OK";
                    account.Permission = "USER";
                    account.CreationDate = DateTime.Now;

                    _context.Add(account);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Login");

                }

                else
                {
                    if (account.Username.ToLower() == checkAccInf.Username.ToLower())
                    {
                        ViewBag.UsernameStatus = $"Username {account.Username} already exist";
                    }

                    if (account.Email.ToLower() == checkAccInf.Email.ToLower())
                    {
                        ViewBag.EmailStatus = $"Email {account.Email} already exist";
                    }
                }
            }
            #endregion RegisterImplementation

            return View();
        }
    }
}
