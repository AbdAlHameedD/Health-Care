using Health_Care_V1._2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Health_Care_V1._2.Controllers
{
    static class Reservation
    {
        public static Appointment NewAppointment { get; set; }
    }

    public class PatientDashboardController : Controller
    {
        private ModelContext _context;

        public PatientDashboardController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Appointments(decimal accountId)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AppointmentsLinkStatus = "nav-item active";
            ViewBag.invoicesData = _context.Invoices.ToList();
            #endregion ViewBagElements

            #region AppointmentsJoinQuery
            var query = (from app in _context.Appointments
                     where app.PatientId == HttpContext.Session.GetInt32("AccountId")
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
                         DoctorEmail = docAcc.Email,
                         DoctorProfilePicture = docAcc.ProfilePicture,

                         //Clinic Inf
                         ClinicName = cli.ClinicName,
                         ClinicId = cli.Id
                     });
            #endregion AppointmentsJoinQuery

            return View(query);
        }
        public IActionResult Details(decimal? id)
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

                             //Doctor Inf
                             DoctorFname = docAcc.Fname,
                             DoctorMname = docAcc.Mname,
                             DoctorLname = docAcc.Lname,
                             DoctorEmail = docAcc.Email,
                             DoctorProfilePicture = docAcc.ProfilePicture,

                             //Clinic Inf
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

        [HttpGet]
        public IActionResult Create(decimal patientId, string appointmentErrorMsg=null)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AppointmentsLinkStatus = "nav-item active";
            ViewBag.AppointmentExists = appointmentErrorMsg;
            #endregion ViewBagElements

            #region DoctorsSelectListQuery
            ViewData["DoctorId1"] =
                new SelectList(from acc in _context.Accounts
                                join emp in _context.Employees
                                on acc.Id equals emp.AccountId
                                join cli in _context.Clinics
                                on emp.ClinicId equals cli.Id
                                where acc.Permission == "DOCTOR"
                                select new
                                {
                                    AccountId = acc.Id,
                                    FullName = acc.Fname + " " + acc.Mname + " " + acc.Lname,
                                    DoctorId = emp.Id,
                                    ClinicId = cli.Id,
                                    ClinicName = cli.ClinicName
                                },
                "DoctorId",
                "FullName");
            #endregion DoctorsSelectListQuery

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id", "PatientId", "DoctorId", "FromDate", "ToDate", "Status", "CreationDate")] Appointment appointment)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AppointmentsLinkStatus = "nav-item active";
            #endregion ViewBagElements

            if (appointment.FromDate.Minute > 55)
                appointment.FromDate = appointment.FromDate.AddMinutes(-appointment.FromDate.Minute).AddHours(1);
            else
                appointment.FromDate = appointment.FromDate.AddMinutes(-appointment.FromDate.Minute);

            appointment.ToDate = appointment.FromDate.AddMinutes(55);
            appointment.Status = "Waiting";
            appointment.CreationDate = DateTime.Now;
            appointment.PatientId = ViewBag.AccountId;

            if (IsDateAvailable(appointment.FromDate, appointment.DoctorId))
            {
                string appointmentErrorMsg = "There is appointment in this date please choose another date";
                return RedirectToAction("Create", new { patientId = ViewBag.AccountId, appointmentErrorMsg = appointmentErrorMsg });
            }
            if (IsDateDuplicate(appointment.FromDate, appointment.PatientId))
            {
                string appointmentErrorMsg = "You have an appointment in the same date";
                return RedirectToAction("Create", new { patientId = ViewBag.AccountId, appointmentErrorMsg = appointmentErrorMsg });
            }

            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Confirmed = true;

                    #region ClinicNameQuery
                    ViewBag.ClinicName = (from doc in _context.Employees
                                          join cli in _context.Clinics
                                          on doc.ClinicId equals cli.Id
                                          select cli.ClinicName).FirstOrDefault();
                    #endregion ClinicNameQuery

                    #region DoctorNameQuery
                    ViewBag.DoctorName = (from doc in _context.Employees
                                          join acc in _context.Accounts
                                          on doc.AccountId equals acc.Id
                                          select new
                                          {
                                              FullName = acc.Fname + " " + acc.Lname
                                          }).FirstOrDefault();
                    #endregion DoctorNameQuery

                    ViewBag.FromDate = appointment.FromDate;
                    ViewBag.ToDate = appointment.ToDate;

                    Reservation.NewAppointment = appointment;
                    return View();
                }
                return RedirectToAction("Create", new { patientId = ViewBag.AccountId });
            }
            catch
            {
                return RedirectToAction("Create", new { patientId = ViewBag.AccountId });
            }
        }

        public async Task<IActionResult> Doctors(decimal? doctorId=null, decimal? clinicId=null)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.DoctorsLinkStatus = "nav-item active";
            #endregion ViewBagElements

            #region RatesQuery
            var rates = (from docRate in _context.DoctorRates
                         group docRate by docRate.DoctorId into g
                         select new
                         {
                             DoctorId = g.Key,
                             Rate = g.Sum(x => x.Rate),
                             Frequent = g.Where(x => x.DoctorId == x.DoctorId).Count()
                         }).OrderByDescending(x => x.Rate);
            #endregion RatesQuery

            IQueryable<DoctorsJoin> query;
            if (doctorId is null && clinicId is null)
            {
                #region ModelQuery
                query = (from rate in rates
                         join doc in _context.Employees
                         on rate.DoctorId equals doc.Id
                         join acc in _context.Accounts
                         on doc.AccountId equals acc.Id
                         join cli in _context.Clinics
                         on doc.ClinicId equals cli.Id
                         select new DoctorsJoin
                         {
                             // Rate Inf
                             Rate = rate.Rate,
                             Frequent = rate.Frequent,

                             // Account Inf
                             FullName = $"{acc.Fname} {acc.Mname} {acc.Lname}",
                             ProfilePicture = acc.ProfilePicture,

                             // Clinic Inf
                             ClinicName = cli.ClinicName
                         });
                #endregion ModelQuery
            }
            else if (doctorId is null && !(clinicId is null))
            {
                #region ModelQuery
                query = (from rate in rates
                             join doc in _context.Employees
                             on rate.DoctorId equals doc.Id
                             join acc in _context.Accounts
                             on doc.AccountId equals acc.Id
                             join cli in _context.Clinics
                             on doc.ClinicId equals cli.Id
                             where cli.Id == clinicId
                             select new DoctorsJoin
                             {
                                 // Rate Inf
                                 Rate = rate.Rate,
                                 Frequent = rate.Frequent,

                                 // Account Inf
                                 FullName = $"{acc.Fname} {acc.Mname} {acc.Lname}",
                                 ProfilePicture = acc.ProfilePicture,

                                 // Clinic Inf
                                 ClinicName = cli.ClinicName
                             });
                #endregion ModelQuery
            }
            else if (!(doctorId is null) && clinicId is null)
            {
                #region ModelQuery
                query = (from rate in rates
                             join doc in _context.Employees
                             on rate.DoctorId equals doc.Id
                             join acc in _context.Accounts
                             on doc.AccountId equals acc.Id
                             join cli in _context.Clinics
                             on doc.ClinicId equals cli.Id
                             where doc.Id == doctorId
                             select new DoctorsJoin
                             {
                                 // Rate Inf
                                 Rate = rate.Rate,
                                 Frequent = rate.Frequent,

                                 // Account Inf
                                 FullName = $"{acc.Fname} {acc.Mname} {acc.Lname}",
                                 ProfilePicture = acc.ProfilePicture,

                                 // Clinic Inf
                                 ClinicName = cli.ClinicName
                             });
                #endregion ModelQuery
            }
            else
            {
                #region ModelQuery
                query = (from rate in rates
                             join doc in _context.Employees
                             on rate.DoctorId equals doc.Id
                             join acc in _context.Accounts
                             on doc.AccountId equals acc.Id
                             join cli in _context.Clinics
                             on doc.ClinicId equals cli.Id
                             where doc.Id == doctorId &&
                             cli.Id == clinicId
                            select new DoctorsJoin
                             {
                                 // Rate Inf
                                 Rate = rate.Rate,
                                 Frequent = rate.Frequent,

                                 // Account Inf
                                 FullName = $"{acc.Fname} {acc.Mname} {acc.Lname}",
                                 ProfilePicture = acc.ProfilePicture,

                                 // Clinic Inf
                                 ClinicName = cli.ClinicName
                             });
                #endregion ModelQuery
            }

            #region ClinicsQuery
            ViewBag.Clinics = (from cli in _context.Clinics
                               select cli);
            #endregion ClinicsQuery

            #region DoctorAccountJoinQuery
            ViewBag.Doctors = (from acc in _context.Accounts
                               join doc in _context.Employees
                               on acc.Id equals doc.AccountId
                               select new DoctorAccountJoin
                               {
                                   FullName = $"{acc.Fname} {acc.Mname} {acc.Lname}",
                                   AccountId = acc.Id,
                                   EmployeeId = doc.Id
                               });
            #endregion DoctorAccountJoinQuery

            return View(await query.ToListAsync());
        }
        public IActionResult Payment()
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.PaymentLinkStatus = "nav-item active";
            #endregion ViewBagElements
            decimal accountId = ViewBag.AccountId;

            var creditCard = (from card in _context.CreditCards
                              where card.AccountId == accountId
                              select card).FirstOrDefault();

            return View(creditCard);
        }
        [HttpPost]
        public IActionResult Payment([Bind("Id,AccountId,CardType,CardNumber,ExpMonth,ExpYear,ModifiedDate")] CreditCard creditCard)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.PaymentLinkStatus = "nav-item active";
            #endregion ViewBagElements
            decimal? accountId = ViewBag.AccountId;

            creditCard.AccountId = accountId;
            creditCard.ModifiedDate = DateTime.Now;

            var query = (from card in _context.CreditCards
                         where card.AccountId == accountId
                         select card).FirstOrDefault();

            if (!(query is null))
            {
                creditCard.Id = query.Id;
                _context.Update(creditCard);
                _context.SaveChanges();
            }
            else
            {
                _context.Add(creditCard);
                _context.SaveChanges();
            }
            return View(creditCard);
        }
        public async Task<IActionResult> Rate(decimal invoiceId)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AppointmentsLinkStatus = "nav-item active";
            #endregion ViewBagElements

            #region InvoiceQuery
            Invoice invoice = (from inv in _context.Invoices
                               where inv.Id == invoiceId
                               select inv).FirstOrDefault();

            invoice.Status = "PAID";
            _context.Update(invoice);
            await _context.SaveChangesAsync();
            #endregion InvoiceQuery

            #region ClinicQuery
            ViewBag.Clinic = (from cli in _context.Clinics
                             where cli.Id == invoice.ClinicId
                             select cli).FirstOrDefault();
            #endregion ClinicQuery

            #region DoctorAccountJoinQuery
            ViewBag.Doctor = (from emp in _context.Employees
                        where emp.Id == invoice.DoctorId
                        join acc in _context.Accounts
                        on emp.AccountId equals acc.Id
                        select new DoctorAccountJoin
                        {
                            AccountId = acc.Id,
                            EmployeeId = emp.Id,
                            FullName = $"{acc.Fname} {acc.Mname} {acc.Lname}",
                            ProfilePicture = acc.ProfilePicture
                        }).FirstOrDefault();
            #endregion DoctorAccountJoinQuery

            return View(invoice);

        }
        public async Task<IActionResult> AppointmentConfirmed()
        {
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");

            _context.Add(Reservation.NewAppointment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Appointments", new { accountId=ViewBag.AccountId });
        }
        public async Task<IActionResult> InvoiceDetails(decimal invoiceId, decimal appointmentId, decimal clinicId, decimal doctorName, decimal patientId)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AppointmentsLinkStatus = "nav-item active";
            ViewBag.DoctorName = doctorName;
            ViewBag.ClinicId = clinicId;
            #endregion ViewBagElements

            #region InvoiceQuery
            ViewBag.Invoice = (from inv in _context.Invoices
                               where inv.Id == invoiceId
                               select inv).FirstOrDefault();
            #endregion InvoiceQuery

            #region PatientQuery
            ViewBag.Patient = (from account in _context.Accounts
                               where account.Id == patientId
                               select account).FirstOrDefault();
            #endregion PatientQuery

            #region PatientAddressQuery
            ViewBag.PatientAddress = (from patAdd in _context.AccountAddresses
                               where patAdd.AccountId == patientId
                               select patAdd).FirstOrDefault();
            #endregion PatientAddressQuery

            #region PatientPhoneNumberQuery
            ViewBag.PatientPhoneNumber = (from patPhone in _context.AccountPhoneNumbers
                                          where patPhone.AccountId == patientId
                                          select patPhone.PhoneNumber).FirstOrDefault();
            #endregion PatientPhoneNumberQuery

            #region ClinicQuery
            ViewBag.Clinic = (from cli in _context.Clinics
                              where cli.Id == clinicId
                              select cli).FirstOrDefault();
            #endregion ClinicQuery

            #region ClinicAddressesQuery
            ViewBag.ClinicAddresses = (from cliAdd in _context.ClinicAddresses
                                       where cliAdd.ClinicId == clinicId
                                       select cliAdd).ToList();
            #endregion ClinicAddressesQuery

            #region ClinicPhoneNumberQuery
            ViewBag.ClinicPhoneNumber = (from cliPhone in _context.ClinicPhoneNumbers
                                         where cliPhone.ClinicId == clinicId
                                               select cliPhone).FirstOrDefault();
            #endregion ClinicPhoneNumberQuery

            #region InvoiceItemsQuery
            List<InvoiceItem> invoiceItems = await (from invItem in _context.InvoiceItems
                                 where invItem.InvoiceId == invoiceId
                                 select invItem).ToListAsync();
            #endregion InvoiceItemsQuery

            #region CalculateTotalPrice
            decimal totalPrice = 0;
            foreach (InvoiceItem invoiceItem in invoiceItems)
            {
                totalPrice += (invoiceItem.Quantity * invoiceItem.Price);
            }
            ViewBag.TotalPrice = totalPrice.ToString("c");
            #endregion CalculateTotalPrice

            return View(invoiceItems);
        }
        public async Task<IActionResult> SetAppointment(decimal id, string status)
        {
            var appointment = (from app in _context.Appointments
                               where app.Id == id
                               select app).FirstOrDefault();
                
            appointment.Status = status;

            _context.Update(appointment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Appointments");
        }
        private bool IsDateAvailable(DateTime fromDate, decimal? doctorId)
        {
            return (from record in _context.Appointments
                     where record.FromDate == fromDate &&
                     record.DoctorId == doctorId &&
                     record.Status == "Accepted"
                     select record).Any();
        }
        private bool IsDateDuplicate(DateTime fromDate, decimal? patientId)
        {
            return (from record in _context.Appointments
                     where record.PatientId == patientId &&
                     record.FromDate == fromDate &&
                     (record.Status != "Cancelled" ||
                     record.Status != "Rejected")
                     select record).Any();
        }
    }
}
