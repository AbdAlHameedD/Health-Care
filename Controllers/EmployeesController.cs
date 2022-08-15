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
    public class EmployeesController : Controller
    {
        private readonly ModelContext _context;

        public EmployeesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(decimal clinicId, string clinicName)
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

            var query = await (from emp in _context.Employees
                                 join acc in _context.Accounts
                                 on emp.AccountId equals acc.Id
                                 where acc.Permission.Equals("DOCTOR") && emp.ClinicId.Equals(clinicId)
                                 select new EmployeeJoin
                                 {
                                     EmployeeId = emp.Id,
                                     AccountId = acc.Id,
                                     Fname = acc.Fname,
                                     Mname = acc.Mname,
                                     Lname = acc.Lname,
                                     Gender = acc.Gender,
                                     Salary = emp.Salary
                                 }).ToListAsync();

            return View(query);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(decimal? id, decimal clinicId, string clinicName, string fullName, decimal accountId, string gender)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.ClinicId = clinicId;
            ViewBag.ClinicName = clinicName;
            ViewBag.FullName = fullName;
            ViewBag.AccountId1 = accountId;
            ViewBag.Gender = gender;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Account)
                .Include(e => e.Clinic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
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


            var employeesAccounts = (from acc in _context.Accounts
                         join emp in _context.Employees
                         on acc.Id equals emp.AccountId
                         where acc.Permission.Equals("DOCTOR")
                         select acc);

            var doctorsAccountsWithoutClinic = (from acc in _context.Accounts
                                                where acc.Permission.Equals("DOCTOR")
                                                select acc).Except(employeesAccounts);

            ViewData["AccountId1"] =
                new SelectList((from acc in doctorsAccountsWithoutClinic
                select new
                {
                    ID = acc.Id,
                    FullName = acc.Fname + " " + acc.Mname + " " + acc.Lname
                }),
                "ID",
                "FullName");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountId,ClinicId,Salary")] Employee employee, decimal clinicId, string clinicName)
        {
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");

            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { clinicId = clinicId, clinicName = clinicName });
            }


            var employeesAccounts = (from acc in _context.Accounts
                                     join emp in _context.Employees
                                     on acc.Id equals emp.AccountId
                                     select acc);

            var doctorsAccountsWithoutClinic = (from acc in _context.Accounts
                                                select acc).Except(employeesAccounts);

            ViewData["AccountId"] =
                new SelectList((from acc in doctorsAccountsWithoutClinic
                                select new
                                {
                                    ID = acc.Id,
                                    FullName = acc.Fname + " " + acc.Mname + " " + acc.Lname
                                }),
                "ID",
                "FullName");

            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(decimal? id, string employeeName, decimal clinicId1,  
            string clinicName, decimal accountId)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.EmployeeName = employeeName;
            ViewBag.ClinicId1 = clinicId1;
            ViewBag.ClinicName = clinicName;
            ViewBag.AccountId1 = accountId;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            ViewData["ClinicsName"] = new SelectList(_context.Clinics, "Id", "ClinicName", employee.ClinicId);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,AccountId,ClinicId,Salary")] Employee employee, decimal clinicId1, string clinicName, decimal accountId)
        {
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");

            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    employee.AccountId = accountId;

                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { clinicId=clinicId1, clinicName= clinicName });
            }
            ViewData["ClinicsName"] = new SelectList(_context.Clinics, "Id", "ClinicName", employee.ClinicId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(decimal? id, decimal clinicId, string clinicName, string fullName, decimal accountId, string gender)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ClinicLinkStatus = "nav-item active";
            ViewBag.ClinicId = clinicId;
            ViewBag.ClinicName = clinicName;
            ViewBag.FullName = fullName;
            ViewBag.AccountId1 = accountId;
            ViewBag.Gender = gender;
            #endregion ViewBagElements

            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Account)
                .Include(e => e.Clinic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id, string clinicId, string clinicName)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { clinicId = clinicId, clinicName = clinicName });
        }

        private bool EmployeeExists(decimal id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
