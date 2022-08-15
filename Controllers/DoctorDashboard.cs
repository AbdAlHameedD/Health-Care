using Health_Care_V1._2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;

namespace Health_Care_V1._2.Controllers
{
    public class Patient
    {
        public decimal PatientId { get; set; }
        public string PatientName { get; set; }
    }
    public class DoctorDashboard : Controller
    {
        private ModelContext _context;
        public DoctorDashboard(ModelContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(DateTime? fromDate = null, DateTime? toDate = null, decimal? patientId=null)
        {
            #region MainViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AppointmentsLinkStatus = "nav-item active";
            ViewBag.invoicesData = (from inv in _context.Invoices select inv).ToList();
            #endregion MainViewBagElements

            IQueryable<AppointemtJoin> query;
            if (fromDate is null && toDate is null && patientId is null)
            {
                #region AppointmentsJoinQuery
                query = (from app in _context.Appointments
                         where app.DoctorId == HttpContext.Session.GetInt32("DoctorId")
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
                             PatientAccountId = patAcc.Id,
                             PatientFname = patAcc.Fname,
                             PatientLname = patAcc.Lname,
                             PatientEmail = patAcc.Email,
                             PatientGender = patAcc.Gender,
                             PatientBoD = patAcc.Bod,

                             //Doctor Inf
                             DoctorId = doc.Id,
                             DoctorFname = docAcc.Fname,
                             DoctorLname = docAcc.Lname,

                             //Clinic Inf
                             ClinicName = cli.ClinicName,
                             ClinicId = cli.Id
                         });
                #endregion AppointmentsJoinQuery
            }
            else if (fromDate is null && toDate is null && !(patientId is null))
            {
                #region AppointmentsJoinQuery
                query = (from app in _context.Appointments
                         where app.DoctorId == HttpContext.Session.GetInt32("DoctorId") &&
                         app.PatientId == patientId
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
                             PatientAccountId = patAcc.Id,
                             PatientFname = patAcc.Fname,
                             PatientLname = patAcc.Lname,
                             PatientEmail = patAcc.Email,
                             PatientGender = patAcc.Gender,
                             PatientBoD = patAcc.Bod,

                             //Doctor Inf
                             DoctorId = doc.Id,
                             DoctorFname = docAcc.Fname,
                             DoctorLname = docAcc.Lname,

                             //Clinic Inf
                             ClinicName = cli.ClinicName,
                             ClinicId = cli.Id
                         });
                #endregion AppointmentsJoinQuery
            }
            else if (fromDate is null && !(toDate is null) && patientId is null)
            {
                #region AppointmentsJoinQuery
                query = (from app in _context.Appointments
                         where app.DoctorId == HttpContext.Session.GetInt32("DoctorId") &&
                         app.ToDate <= toDate
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
                             PatientAccountId = patAcc.Id,
                             PatientFname = patAcc.Fname,
                             PatientLname = patAcc.Lname,
                             PatientEmail = patAcc.Email,
                             PatientGender = patAcc.Gender,
                             PatientBoD = patAcc.Bod,

                             //Doctor Inf
                             DoctorId = doc.Id,
                             DoctorFname = docAcc.Fname,
                             DoctorLname = docAcc.Lname,

                             //Clinic Inf
                             ClinicName = cli.ClinicName,
                             ClinicId = cli.Id
                         });
                #endregion AppointmentsJoinQuery
            }
            else if (fromDate is null && !(toDate is null) && !(patientId is null))
            {
                #region AppointmentsJoinQuery
                query = (from app in _context.Appointments
                         where app.DoctorId == HttpContext.Session.GetInt32("DoctorId") &&
                         app.ToDate <= toDate && app.PatientId == patientId
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
                             PatientAccountId = patAcc.Id,
                             PatientFname = patAcc.Fname,
                             PatientLname = patAcc.Lname,
                             PatientEmail = patAcc.Email,
                             PatientGender = patAcc.Gender,
                             PatientBoD = patAcc.Bod,

                             //Doctor Inf
                             DoctorId = doc.Id,
                             DoctorFname = docAcc.Fname,
                             DoctorLname = docAcc.Lname,

                             //Clinic Inf
                             ClinicName = cli.ClinicName,
                             ClinicId = cli.Id
                         });
                #endregion AppointmentsJoinQuery
            }
            else if (!(fromDate is null) && toDate is null && patientId is null)
            {
                #region AppointmentsJoinQuery
                query = (from app in _context.Appointments
                         where app.DoctorId == HttpContext.Session.GetInt32("DoctorId") &&
                         app.FromDate >= fromDate
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
                             PatientAccountId = patAcc.Id,
                             PatientFname = patAcc.Fname,
                             PatientLname = patAcc.Lname,
                             PatientEmail = patAcc.Email,
                             PatientGender = patAcc.Gender,
                             PatientBoD = patAcc.Bod,

                             //Doctor Inf
                             DoctorId = doc.Id,
                             DoctorFname = docAcc.Fname,
                             DoctorLname = docAcc.Lname,

                             //Clinic Inf
                             ClinicName = cli.ClinicName,
                             ClinicId = cli.Id
                         });
                #endregion AppointmentsJoinQuery
            }
            else if (!(fromDate is null) && toDate is null && !(patientId is null))
            {
                #region AppointmentsJoinQuery
                query = (from app in _context.Appointments
                         where app.DoctorId == HttpContext.Session.GetInt32("DoctorId") &&
                         app.FromDate >= fromDate && app.PatientId == patientId
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
                             PatientAccountId = patAcc.Id,
                             PatientFname = patAcc.Fname,
                             PatientLname = patAcc.Lname,
                             PatientEmail = patAcc.Email,
                             PatientGender = patAcc.Gender,
                             PatientBoD = patAcc.Bod,

                             //Doctor Inf
                             DoctorId = doc.Id,
                             DoctorFname = docAcc.Fname,
                             DoctorLname = docAcc.Lname,

                             //Clinic Inf
                             ClinicName = cli.ClinicName,
                             ClinicId = cli.Id
                         });
                #endregion AppointmentsJoinQuery
            }
            else if (!(fromDate is null) && !(toDate is null) && patientId is null)
            {
                #region AppointmentsJoinQuery
                query = (from app in _context.Appointments
                         where app.DoctorId == HttpContext.Session.GetInt32("DoctorId") &&
                         app.FromDate >= fromDate && app.ToDate <= toDate
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
                             PatientAccountId = patAcc.Id,
                             PatientFname = patAcc.Fname,
                             PatientLname = patAcc.Lname,
                             PatientEmail = patAcc.Email,
                             PatientGender = patAcc.Gender,
                             PatientBoD = patAcc.Bod,

                             //Doctor Inf
                             DoctorId = doc.Id,
                             DoctorFname = docAcc.Fname,
                             DoctorLname = docAcc.Lname,

                             //Clinic Inf
                             ClinicName = cli.ClinicName,
                             ClinicId = cli.Id
                         });
                #endregion AppointmentsJoinQuery
            }
            else
            {
                #region AppointmentsJoinQuery
                query = (from app in _context.Appointments
                         where app.DoctorId == HttpContext.Session.GetInt32("DoctorId") &&
                         app.FromDate >= fromDate && app.ToDate <= toDate && app.PatientId == patientId
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
                             PatientEmail = patAcc.Email,
                             PatientGender = patAcc.Gender,
                             PatientBoD = patAcc.Bod,

                             //Doctor Inf
                             DoctorFname = docAcc.Fname,
                             DoctorLname = docAcc.Lname,

                             //Clinic Inf
                             ClinicName = cli.ClinicName
                         });
                #endregion AppointmentsJoinQuery
            }

            #region PatientDropListQuery
            ViewBag.PatientAcc = await (from app in _context.Appointments
                     where app.DoctorId == HttpContext.Session.GetInt32("DoctorId")
                     join acc in _context.Accounts
                     on app.PatientId equals acc.Id
                     select new Patient
                     {
                         PatientId = acc.Id,
                         PatientName = $"{acc.Fname} {acc.Lname}"
                     }).Distinct().ToListAsync();

            return View( await query.ToListAsync());
            #endregion PatientDropListQuery
        }

        public IActionResult Details(decimal? id)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AppointmentsLinkStatus = "nav-item active";
            ViewBag.invoicesData = (from inv in _context.Invoices select inv).ToList();
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
                             PatientFname = patAcc.Fname,
                             PatientMname = patAcc.Mname,
                             PatientLname = patAcc.Lname,
                             PatientEmail = patAcc.Email,
                             PatientGender = patAcc.Gender,
                             PatientBoD = patAcc.Bod,
                             PatientProfilePicture = patAcc.ProfilePicture
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

        public async Task<IActionResult> SetAppointment(decimal id, string status, string patientEmail, string pateintName,
            string clinicName, string doctorName, DateTime startDate, DateTime endDate) 
        {
            var appointment = (from app in _context.Appointments
                               where app.Id == id
                               select app).FirstOrDefault();

            appointment.Status = status;

            _context.Update(appointment);
            await _context.SaveChangesAsync();

            if (status == "Accepted" || status == "Rejected")
            {
                SmtpClient clientDetails = new SmtpClient();
                clientDetails.Port = 587;
                clientDetails.Host = "smtp.gmail.com";
                clientDetails.EnableSsl = true;
                clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientDetails.UseDefaultCredentials = false;
                clientDetails.Credentials = new NetworkCredential("dabdalhammed6@gmail.com", "457%@k8h%CcED*YN");

                MailMessage mailDetails = new MailMessage();
                mailDetails.From = new MailAddress("dabdalhammed6@gmail.com");
                mailDetails.To.Add(patientEmail);

                mailDetails.Subject = "Health Care - Your Appointment";
                mailDetails.IsBodyHtml = true;
                string emailBody = "";
                if (status == "Accepted")
                {
                    emailBody = $"Hello <span style='font-weight:bold;'> {pateintName}</span>," +
                        $" your appointment " +
                        $"with <span style='color: #0000ff; font-weight: bold;'>Dr.{doctorName}</span>" +
                        $" in <span style='font-weight: bold;'>{clinicName}</span> at " +
                        $"<span style='font-weight: bold'>{startDate}</span>" +
                        $" to <span style='font-weight: bold'>{endDate}</span>" +
                        $" is <span style='color:green; font-weight:bold;'> accepted, </span>" +
                        $"<span style='color:#BD2424;'>please be there before 30 min.</span>" +
                        $"<br /> <br /> <br /> <br />" +
                        $"<span style='color: #2439BD;'>Health Care</span> <br /> Thank you <br /> Sincerely";
                }
                if (status == "Rejected")
                {
                    emailBody = $"Hello <span style='font-weight:bold;'> {pateintName}</span>," +
                        $"unfortunately your appointment " +
                        $"with <span style='color: #0000ff; font-weight: bold;'>Dr.{doctorName}</span>" +
                        $" in <span style='font-weight: bold;'>{clinicName}</span> at " +
                        $"<span style='font-weight: bold'>{startDate}</span>" +
                        $" to <span style='font-weight: bold'>{endDate}</span>" +
                        $" is <span style='color:red; font-weight:bold;'> rejected, </span>" +
                        $"<span style='color:#BD2424;'>please try another date.</span>" +
                        $"<br /> <br /> <br /> <br />" +
                        $"<span style='color: #2439BD;'>Health Care</span> <br /> Thank you <br /> Sincerely";
                }
                mailDetails.Body = emailBody;
                clientDetails.Send(mailDetails);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateInvoice(decimal appointmentId, decimal clinicId, decimal patientId, decimal doctorId)
        {
            decimal? lastInvoiceId = (from inv in _context.Invoices
                                 select inv.Id).OrderByDescending(x => x).FirstOrDefault();

            decimal? newId;
            if (lastInvoiceId is null) { newId = 1; }
            else { newId = ++lastInvoiceId; }
            
            Invoice invoice = new Invoice();
            invoice.Id = (decimal)newId;
            invoice.AppointmentId = appointmentId;
            invoice.ClinicId = clinicId;
            invoice.PatientId = patientId;
            invoice.DoctorId = doctorId;
            invoice.CreationDate = DateTime.Now;
            invoice.Status = "UNPAID";

            _context.Add(invoice);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "InvoiceItems", new { invoiceId=newId });
        }

        public async Task<IActionResult> Patients(string fullName=null)
        {
            #region MainViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.PatientsLinkStatus = "nav-item active";
            #endregion MainViewBagElements

            List<Account> patients = new List<Account>();
            if (!(fullName is null))
            {
                patients = await (from acc in _context.Accounts
                                      where acc.Status == "OK" && acc.Permission == "USER"
                                      && (acc.Fname + " " + acc.Mname + " " + acc.Lname) == fullName
                                      select acc).ToListAsync();
            }
            else
            {
                patients = await (from acc in _context.Accounts
                                      where acc.Status == "OK" && acc.Permission == "USER"
                                      select acc).ToListAsync();
            }

            

            ViewBag.Patients = await (from acc in _context.Accounts
                                      where acc.Status == "OK" && acc.Permission == "USER"
                                      select acc).ToListAsync();

            return View(patients);
        }
    }
}
