using Health_Care_V1._2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Health_Care_V1._2.Controllers
{
    public class EditProfileController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public EditProfileController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            this._context = context;
            this._webHostEnviroment = webHostEnviroment;
        }


        // GET: Accounts/Edit/
        public async Task<IActionResult> Edit(decimal? id)
        {
            #region ViewBagElements
            ViewBag.mainTable = (from record in _context.Mains select record).ToList().FirstOrDefault();
            ViewBag.Permission = HttpContext.Session.GetString("Permission");
            ViewBag.Fname = HttpContext.Session.GetString("Fname");
            ViewBag.LName = HttpContext.Session.GetString("Lname");
            ViewBag.AccountId = HttpContext.Session.GetInt32("AccountId");
            ViewBag.ProfileLinkStatus = "nav-item active";
            ViewBag.AccountId1 = id;
            #endregion ViewBagElements

            var account = await _context.Accounts.FindAsync(id);
            ViewBag.Email = account.Email;
            ViewBag.Username = account.Username;

            AccountAddress accountAddress = (from accAdd in _context.AccountAddresses
                                             where accAdd.AccountId.Equals(account.Id)
                                             select accAdd).FirstOrDefault();

            if (!(accountAddress is null))
            {
                ViewBag.Country = accountAddress.Country;
                ViewBag.City = accountAddress.City;
            }

            ViewBag.AccountPhoneNumbers = 
                await (from accPhone in _context.AccountPhoneNumbers
                where accPhone.AccountId.Equals(account.Id)
                select (int)accPhone.PhoneNumber).ToListAsync();
            

            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal? id, [Bind("Id,Username,Password,Email,Fname,Mname,Lname,Gender,Bod,Status,Permission,CreationDate,ProfilePicture,ImageFile")] Account account,
            string username, string email, string country, string city=null)
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

                account.Username = username;
                account.Email = email;
                account.Permission = HttpContext.Session.GetString("Permission");
                account.Status = "OK";

                HttpContext.Session.SetString("Fname", account.Fname);
                HttpContext.Session.SetString("Mname", account.Mname);
                HttpContext.Session.SetString("Lname", account.Lname);
                HttpContext.Session.SetString("ProfilePicture", account.ProfilePicture);

                _context.Update(account);
                await _context.SaveChangesAsync();

                AccountAddress accountAddress = (from accAdd in _context.AccountAddresses
                                                where accAdd.AccountId.Equals(account.Id)
                                                select accAdd).FirstOrDefault();

                if (accountAddress is null)
                {
                    accountAddress = new AccountAddress();
                    accountAddress.AccountId = account.Id;
                    accountAddress.Country = country;
                    accountAddress.City = city;
                        
                    _context.Add(accountAddress);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    accountAddress.Country = country;
                    accountAddress.City = city;

                    _context.Update(accountAddress);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Edit", new { account.Id });
            }
            return View(account);
        }

    }
}
