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
    public class AppointemtJoinsController : Controller
    {
        private readonly ModelContext _context;

        public AppointemtJoinsController(ModelContext context)
        {
            _context = context;
        }

        // GET: AppointemtJoins
        public async Task<IActionResult> Index()
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AppointmentsLinkStatus = "nav-item active";
            #endregion ViewBagElements

            #region AppointmentsJoinQuery
            var query = (from app in _context.Appointments
                         join patAcc in _context.Accounts
                         on app.PatientId equals patAcc.Id
                         join doc in _context.Employees
                         on app.DoctorId equals doc.Id
                         join docAcc in _context.Accounts
                         on doc.AccountId equals docAcc.Id
                         join cli in _context.Clinics
                         on doc.ClinicId equals cli.Id
                         select new AppointemtJoin
                         {
                             //Appointment Inf
                             Id = app.Id,
                             FromDate = app.FromDate,
                             ToDate = app.ToDate,
                             Status = app.Status,

                             //Patient Inf
                             PatientFname = patAcc.Fname,
                             PatientLname = patAcc.Lname,

                             //Doctor Inf
                             DoctorFname = docAcc.Fname,
                             DoctorLname = docAcc.Lname,

                             //Clinic Inf
                             ClinicName = cli.ClinicName,
                             ClinicId = cli.Id
                         });

            #endregion AppointmentsJoinQuery

            return View(await query.ToListAsync());
        }

        // GET: AppointemtJoins/Details/5
        public IActionResult Details(decimal? id)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AppointmentsLinkStatus = "nav-item active";
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            #endregion ViewBagElements

            #region AppointmentsJoinQuery
            var query = (from app in _context.Appointments
                         where app.Id == id
                         join patAcc in _context.Accounts
                         on app.PatientId equals patAcc.Id
                         join doc in _context.Employees
                         on app.DoctorId equals doc.Id
                         join docAcc in _context.Accounts
                         on doc.AccountId equals docAcc.Id
                         join cli in _context.Clinics
                         on doc.ClinicId equals cli.Id
                         select new AppointemtJoin
                         {
                             //Appointment Inf
                             Id = app.Id,
                             FromDate = app.FromDate,
                             ToDate = app.ToDate,
                             CreationDate = app.CreationDate,
                             Status = app.Status,

                             //Patient Inf
                             PatientAccountId = patAcc.Id,
                             PatientFname = patAcc.Fname,
                             PatientMname = patAcc.Mname,
                             PatientLname = patAcc.Lname,
                             PatientEmail = patAcc.Email,
                             PatientGender = patAcc.Gender,
                             PatientBoD = patAcc.Bod,
                             PatientProfilePicture = patAcc.ProfilePicture,

                             //Employee Inf
                             DoctorId = doc.Id,

                             //Doctor Inf
                             DoctorAccountId = docAcc.Id,
                             DoctorFname = docAcc.Fname,
                             DoctorMname = docAcc.Mname,
                             DoctorLname = docAcc.Lname,
                             DoctorEmail = docAcc.Email,
                             DoctorProfilePicture = docAcc.ProfilePicture,

                             //Clinic Inf
                             ClinicId = cli.Id,
                             ClinicName = cli.ClinicName,
                             ClinicLogo = cli.ClinicLogo
                         }).FirstOrDefault();
            #endregion AppointmentsJoinQuery

            if (id == null)
            {
                return NotFound();
            }

            if (query == null)
            {
                return NotFound();
            }

            return View(query);
        }
    }
}
