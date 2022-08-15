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
    public static class H
    {
        public static bool IsLoggedIn { get; set; }
        public static string Permission { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModelContext _context;

        public HomeController(ILogger<HomeController> logger, ModelContext context)
        {
            _logger = logger;
            _context = context;
        }

        #region Getters
        private List<decimal> GetHighFourDoctorDoctorsId()
        {
            /* 
             * Return List<decimal> that stores Employee_Id
             * For high 4 Doctors rate
             */
            #region highFourDoctorRatesImplementation
            var highFourDoctorRates = (from record in _context.DoctorRates
                                       group record by record.DoctorId into g
                                       select new
                                       {
                                           DoctorID = g.Key,
                                           Frequent = g.Where(x => x.DoctorId == x.DoctorId).Count(),
                                           Average = g.Sum(x => x.Rate)

                                       }).OrderByDescending(x => x.Average / x.Frequent).Take(4).Select(x => x.DoctorID).ToList();
            #endregion highFourDoctorRates

            return highFourDoctorRates;
        }

        private List<List<decimal?>> GetHighFourDoctorsAccountsIdAndClinicsId()
        {
            /*
             * Return List < List <decimal?> > that stores:
             * At index 0: accounts_id for the higher four rate doctors
             * At index 1: clinics_id that the doctors work for
             */

            #region HighFourDoctorsAccountsIdAndClinicsIdImplementation
            List<decimal?> accounts_id = new List<decimal?>();
            List<decimal?> clinics_id = new List<decimal?>();

            foreach (int id in GetHighFourDoctorDoctorsId())
            {
                var account = (from record in _context.Employees
                               where record.Id.Equals(id)
                               select record).SingleOrDefault();
                accounts_id.Add(account.AccountId);
                clinics_id.Add(account.ClinicId);
            }

            List<List<decimal?>> result = new List<List<decimal?>> { accounts_id, clinics_id };
            #endregion HighFourDoctorsAccountsIdAndClinicsIdImplementation

            return result;
        }

        private List<Account> GetHighFourRecordsAccountsRate()
        {
            /*
             * Return List < Account > that stores full account record
             * that represent the most higher doctors rate
             */

            #region GetHighFourRecordsAccountsRateImplementation
            List<Account> accounts = new List<Account>();
            List<decimal?> accounts_id = GetHighFourDoctorsAccountsIdAndClinicsId()[0];

            foreach (var id in accounts_id)
            {
                var acc = (from account in _context.Accounts
                           where account.Id.Equals(id)
                           select account).SingleOrDefault();

                accounts.Add(acc);
            }
            #endregion GetHighFourRecordsAccountsRateImplementation

            return accounts;
        }

        private List<string> GetClinicsDoctorsWorksFor()
        {
            /*
             * Return List < string> that stores name of clinics
             * that represent the most higher doctors works for
             */

            #region GetClinicsDoctorsWorksForImplementation
            List<string> clinics = new List<string>();
            List<decimal?> clinics_id = GetHighFourDoctorsAccountsIdAndClinicsId()[1];

            foreach (var id in clinics_id)
            {
                string clinic_name = (from clinic in _context.Clinics
                                      where clinic.Id.Equals(id)
                                      select clinic).FirstOrDefault().ClinicName;

                clinics.Add(clinic_name);
            }
            #endregion GetClinicsDoctorsWorksForImplementation

            return clinics;
        }

        private Main GetMainPageInformation()
        {
            /*
             * Return object from type Main
             * that represent first and only
             * record from Main table to dynamic 
             * Home Page and Layout
             */

            return (from record in _context.Mains select record).ToList().FirstOrDefault();
        }

        private List<Clinic> GetClinicTableRecords()
        {
            /*
             * Return List < Clinic >
             * that represent records of clinics in the system
             */

            return (from clinic in _context.Clinics select clinic).ToList();
        }

        private List<HeaderLink> GetHeaderLinkTableRecords()
        {
            /*
             * Return List < HeaderLink >
             * that represent header links of website for dynamically
             */

            return (from link in _context.HeaderLinks select link).ToList();
        }

        private List<string> GetClinicNames()
        {
            /*
             * Return List < string >
             * that represent all Clinic Names
             */

            return (from clinic in _context.Clinics select clinic.ClinicName).ToList();
        }

        private List<FooterQuickLink> GetFooterQuickLinks()
        {
            /* 
             * Return List < FooterQuickLink >
             * that represent all records in footer_quick_link table
             */

            return (from link in _context.FooterQuickLinks select link).ToList();
        }

        private List<FooterService> GetFooterServices()
        {
            /*
             * Return List < FooterService >
             * that represent all records in footer_services table
             */

            return (from service in _context.FooterServices select service).ToList();
        }

        private List<Service> GetServices()
        {
            /* Return List < Service >
             * that represent all records in service table
             */

            return (from service in _context.Services select service).ToList();
        }

        private List<Department> GetDepartments()
        {
            /*
             * Return List < Department 
             * that represent all records in department table
             */

            return (from department in _context.Departments select department).ToList();
        }

        private List<Clinic> GetHighFourClinics()
        {
            /*
             * Return List < Clinic >
             * that represent all records in clinic table
             */

            var query = (from cliRate in _context.ClinicRates
                         join cli in _context.Clinics
                         on cliRate.ClinicId equals cli.Id
                         group cliRate by cliRate.ClinicId into g
                         select new
                         {
                             ClinicID = g.Key,
                             Frequent = g.Where(x => x.ClinicId == x.ClinicId).Count(),
                             Average = g.Sum(x => x.Rate)

                         }).OrderByDescending(x => x.Average / x.Frequent).Take(4).Select(x => x.ClinicID).ToList();

            return (from q in query
                    join cli in _context.Clinics
                    on q.Value equals cli.Id
                    select cli).ToList();
        }

        private int GetYearsExperience()
        {
            /* Return int
             * that represent year of create website - year now
             */

            var websiteCreationDate = (from main in _context.Mains select main.WebsiteCreationDate).FirstOrDefault();
            return (DateTime.Now.Year - websiteCreationDate.Year);
            
        }

        private int GetPatientsNumber()
        {
            /* 
             * return integer
             * that represent number of patients
             */

            return (from patient
                    in _context.Accounts
                    where patient.Permission.Equals("USER")
                    select patient).Count();
        }

        private int GetDoctorsNumber()
        {
            /* 
             * return integer
             * that represent number of doctors
             */

            return (from doctor in _context.Accounts
                    where doctor.Permission.Equals("DOCTOR")
                    select doctor).Count();
        }

        private int GetClinicsNumber()
        {
            /* 
             * return integer
             * that represent number of clinics
             */

            return (from clinic in _context.Clinics select clinic).Count();
        }

        private object GetTestimonials()
        {
            /*
             * Return List < Testimonial >
             * that represent five testimonials that
             * accepted and latest publish date
             */

            #region GetTestimonialsImplementation
            var testimonials = (from testimonial
                    in _context.Testimonials
                    where testimonial.Status.Equals("Accepted")
                    join account
                    in _context.Accounts
                    on testimonial.AccountId equals account.Id
                    select new TestimonialJoin
                    {
                        Message = testimonial.Message,
                        Fname = account.Fname,
                        Lname = account.Lname,
                        ProfilePicture = account.ProfilePicture,
                        PublishDate = testimonial.PublishDate

                    }).OrderByDescending(x => x.PublishDate).Take(5).ToList();
            #endregion GetTestimonialsImplementation

            return testimonials;

        }

        private List<ContactUsCard> GetContactUsCards()
        {
            /*
             * Return List < ContactUsCard >
             * that represent cards of contact us information
             */

            return (from card
                    in _context.ContactUsCards
                    select card).ToList();
        }
        #endregion Getters

        public IActionResult Index()
        {
            #region ViewBagElements
            ViewBag.MainTable = GetMainPageInformation();
            ViewBag.ClinicTable = GetClinicTableRecords();
            ViewBag.HeaderLinkTable = GetHeaderLinkTableRecords();
            ViewBag.ClinicNames = GetClinicNames();
            ViewBag.FooterLinks = GetFooterQuickLinks();
            ViewBag.FooterServices = GetFooterServices();
            ViewBag.Services = GetServices();
            ViewBag.Departments = GetDepartments();
            ViewBag.Accounts = GetHighFourRecordsAccountsRate();
            ViewBag.ClinicNames = GetClinicsDoctorsWorksFor();
            ViewBag.Clinics = GetHighFourClinics();
            ViewBag.YearsExperience = GetYearsExperience();
            ViewBag.NumOfPatients = GetPatientsNumber();
            ViewBag.NumOfDoctors = GetDoctorsNumber();
            ViewBag.NumOfClinics = GetClinicsNumber();
            ViewBag.Testimonials = GetTestimonials();
            ViewBag.ContactUsCards = GetContactUsCards();
            #endregion ViewBagElements  

            ViewBag.IsLogged = H.IsLoggedIn;
            ViewBag.ProfilePicture = HttpContext.Session.GetString("ProfilePicture");
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.Mname = HttpContext.Session.GetString("Mname");
            ViewBag.Lname = HttpContext.Session.GetString("Lname");
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.Permission = HttpContext.Session.GetString("Permission");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult RedirectToHome()
        {
            return Redirect("Index");
        }
    }
}
