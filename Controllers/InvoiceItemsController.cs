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
    public class InvoiceItemsController : Controller
    {
        private readonly ModelContext _context;
        public static List<InvoiceItem> invoiceItems = new List<InvoiceItem>();

        public InvoiceItemsController(ModelContext context)
        {
            _context = context;
        }

        // GET: InvoiceItems
        public IActionResult Index(decimal invoiceId)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.AppointmentsLinkStatus = "nav-item active";
            ViewBag.InvoiceId = invoiceId;
            ViewBag.InvoiceItems = InvoiceItemsController.invoiceItems;
            #endregion ViewBagElements

            return View();
        }

        private bool InvoiceItemExists(decimal id)
        {
            return _context.InvoiceItems.Any(e => e.Id == id);
        }
        
        public IActionResult AddItem(decimal invoiceId, string itemName, string itemDescription, int quantity, decimal itemPrice)
        {
            InvoiceItem newItem = new InvoiceItem();
            newItem.InvoiceId = invoiceId;
            newItem.ItemName = itemName;
            newItem.ItemDescription = itemDescription;
            newItem.Quantity = quantity;
            newItem.Price = itemPrice;

            InvoiceItemsController.invoiceItems.Add(newItem);

            return RedirectToAction("Index", new { invoiceId=invoiceId });
        }
        public async Task<IActionResult> RemoveInvoice(decimal invoiceId)
        {
            Invoice invoice = (from inv in _context.Invoices
                               where inv.Id == 3
                               select inv).FirstOrDefault();

            if (!(invoice is null))
            {
                _context.Remove(invoice);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "DoctorDashboard");
        }
        public async Task<IActionResult> SaveInvoice()
        {
            foreach(InvoiceItem invItem in InvoiceItemsController.invoiceItems)
            {
                _context.Add(invItem);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "DoctorDashboard");
        }
    }
}
