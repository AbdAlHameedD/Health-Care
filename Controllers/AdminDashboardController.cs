using Health_Care_V1._2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Health_Care_V1._2.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly ModelContext _context;

        public AdminDashboardController(ModelContext context)
        {
            this._context = context;
        }

        private double GetNumberOfAdminAccounts()
        {
            /*
             * Return int
             * that represent number of admin accounts in the system
             */

            return (from account
                    in _context.Accounts
                    where account.Permission.Equals("ADMIN")
                    select account).Count();
        }

        private double GetNumberOfDoctorAccounts()
        {
            /*
             * Return int
             * that represent number of Doctor accounts in the system
             */

            return (from account
                    in _context.Accounts
                    where account.Permission.Equals("DOCTOR")
                    select account).Count();
        }

        private double GetNumberOfPatientAccounts()
        {
            /*
             * Return int
             * that represent number of patient accounts in the system
             */

            return (from account
                    in _context.Accounts
                    where account.Permission.Equals("USER")
                    select account).Count();
        }

        private double GetPercentage(double number, int total)
        {
            /*
             * Return double
             * that represent precentage
             */

            double precentage = (number / total) * 100;

            return Math.Round(precentage, 1);
        }
        
        private int GetNumberOfAccounts()
        {
            /*
             * Return int
             * that represent number of all records in account table
             */

            return _context.Accounts.Count();
        }

        private string GetMonthName(int month)
        {
            /*
             * Return string
             * thar represent Name of the month
             */

            switch (month)
            {
                case 1: return "Jan";
                case 2: return "Feb";
                case 3: return "Mar";
                case 4: return "Apr";
                case 5: return "May";
                case 6: return "Jun";
                case 7: return "Jul";
                case 8: return "Aug";
                case 9: return "Sep";
                case 10: return "Oct";
                case 11: return "Nov";
                case 12: return "Dec";
                default: return "NaN";
            }
        }

        private int GetNumberAppointments(DateTime startDate, DateTime endDate, string appointmentsStatus)
        {
            /*
             * Return int
             * that represent number of appointment
             * in the specific status and for period of time
             */

            return (from app in _context.Appointments
                         where app.CreationDate >= startDate &&
                         app.CreationDate < endDate &&
                         app.Status == appointmentsStatus
                         select app).Count();
        }

        private Tuple<List<string>, List<int>, List<int>, List<int>> GetAppointmentsData()
        {
            /*
             * Return Tuple of lists
             * that represent data for appointments chart
             */

            #region GetAppointmentsDataImplementation
            List<string> months = new List<string>();
            List<int> completedAppointmets = new List<int>();
            List<int> waitingAppointmets = new List<int>();
            List<int> cancelledAppointmets = new List<int>();

            int month = DateTime.Now.Month + 1;
            DateTime now = new DateTime(DateTime.Now.Year, month, 1);
            DateTime beforeYear = now.AddYears(-1);
            
            while (beforeYear <= now)
            {
                months.Add(GetMonthName(beforeYear.Month));
                completedAppointmets.Add(GetNumberAppointments(beforeYear, beforeYear.AddMonths(1).AddDays(-1), "Completed"));
                waitingAppointmets.Add(GetNumberAppointments(beforeYear, beforeYear.AddMonths(1).AddDays(-1), "Waiting"));
                cancelledAppointmets.Add(GetNumberAppointments(beforeYear, beforeYear.AddMonths(1).AddDays(-1), "Cancelled"));
                beforeYear = beforeYear.AddMonths(1);
            }
            #endregion GetAppointmentsDataImplementation

            return new Tuple<List<string>, List<int>, List<int>, List<int>>(months, completedAppointmets, waitingAppointmets, cancelledAppointmets);
        }
        private decimal GetSales(DateTime startDate, DateTime endDate, IEnumerable<InvoiceJoin> data)
        {
            /*
             * Return decimal
             * that represent sales
             * in the specific period of time
             */

            return (from inv in data
                    where inv.CreationDate >= startDate &&
                    inv.CreationDate < endDate &&
                    inv.Status == "PAID"
                    select inv).Sum(s => s.InvoiceTotalPrice);
        }
        private List<decimal> GetSalesForYear()
        {
            /*
             * Return Tuple of lists
             * that represent data for sales chart
             */
            #region GetSalesForYearImplementation
            var query = (from item in _context.InvoiceItems
                         join inv in _context.Invoices
                         on item.InvoiceId equals inv.Id
                         select new InvoiceJoin
                         {
                             InvoiceId = inv.Id,
                             CreationDate = inv.CreationDate,
                             InvoiceTotalPrice = item.Price,
                             Status = inv.Status
                         }).ToList().GroupBy(d => d.InvoiceId).Select(g => new InvoiceJoin
                         {
                             InvoiceId = g.Key,
                             InvoiceTotalPrice = g.Sum(s => s.InvoiceTotalPrice),
                             CreationDate = g.First().CreationDate,
                             Status = g.First().Status
                         });


            List<string> months = new List<string>();
            List<decimal> sales = new List<decimal>();

            int month = DateTime.Now.Month + 1;
            DateTime now = new DateTime(DateTime.Now.Year, month, 1);
            DateTime beforeYear = now.AddYears(-1);

            while (beforeYear <= now)
            {
                months.Add(GetMonthName(beforeYear.Month));
                sales.Add(GetSales(beforeYear, beforeYear.AddMonths(1).AddDays(-1), query));
                beforeYear = beforeYear.AddMonths(1);
            }
            #endregion GetSalesForYearImplementation

            return sales;
        }

        public IActionResult Index()
        {
            #region MainViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.DashboardLinkStatus = "nav-item active";
            #endregion MainViewBagElements

            #region AccountsStatisticsViewBag
            ViewBag.AdminAccountsNumber = GetNumberOfAdminAccounts();
            ViewBag.DoctorAccountsNumber = GetNumberOfDoctorAccounts();
            ViewBag.PatientAccountsNumber = GetNumberOfPatientAccounts();
            ViewBag.TotalAccountsNumber = GetNumberOfAccounts();

            ViewBag.AdminAccountsPrecentage = GetPercentage(ViewBag.AdminAccountsNumber, ViewBag.TotalAccountsNumber);
            ViewBag.DoctorAccountsPrecentage = GetPercentage(ViewBag.DoctorAccountsNumber, ViewBag.TotalAccountsNumber);
            ViewBag.PatientAccountsPrecentage = GetPercentage(ViewBag.PatientAccountsNumber, ViewBag.TotalAccountsNumber);
            #endregion AccountsStatisticsViewBag

            #region AppointmentsStatisticsViewBag
            var AppointmentFullData = GetAppointmentsData();

            ViewBag.AppointmentLabels = AppointmentFullData.Item1;
            ViewBag.CompletedAppointments = AppointmentFullData.Item2;
            ViewBag.WaitingAppointments = AppointmentFullData.Item3;
            ViewBag.CancelledAppointments = AppointmentFullData.Item4;
            #endregion AppointmentsStatisticsViewBag

            #region SalesStatisticsViewBag
            ViewBag.PaidInvoices = GetSalesForYear();
            #endregion SalesStatisticsViewBag

            return View();
        }
    }
}
