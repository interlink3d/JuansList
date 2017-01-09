using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using JuansList.Data;
using JuansList.Models;
using JuansList.ViewModels;

namespace JuansList.Controllers
{
    public class VendorController : Controller
    {
        private ApplicationDbContext context;
        // Private variable for userManager helper function
        private readonly UserManager<VendorUser> _userManager;
        private readonly UserManager<CustomerUser> _userManager2;

        //Constructor functions that takes both context AND the userManager object
        //and sets them to the private variables above
        public VendorController(UserManager<VendorUser> userManager, UserManager<CustomerUser> userManager2, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _userManager2 = userManager2;
            context = ctx;
        }

        // This task retrieves the currently authenticated user
        private Task<VendorUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public async Task<IActionResult> Profile()
        {
            var User = await GetCurrentUserAsync();
            var VendorUID = User.Id;

            var model = new VendorProfileViewModel();
            model.VendorUser = User;
            model.Coupons = await context.Coupon
                .Where(v => v.VendorUser == User)
                .OrderBy(t => t.Title).ToListAsync();

            model.Albums = await context.Album
                .Where(v => v.VendorUser == User)
                .Include(ai => ai.Images)
                .OrderBy(a => a.Title).ToListAsync();

            model.VenCat = await context.VendorCategory
                .Where(v => v.VendorUser == User)
                .Include(cat => cat.Category)
                .OrderBy(c => c.Category.Name).ToListAsync();



            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProfile()
        {
            var User = await GetCurrentUserAsync();

            var model = new EditVendorProfileViewModel();
            model.VendorUsers = User;
            model.Coupons = await context.Coupon
                .Where(v => v.VendorUser == User)
                .OrderBy(t => t.Title).ToListAsync();

            model.Albums = await context.Album
                .Where(v => v.VendorUser == User)
                .OrderBy(a => a.Title).ToListAsync();

            model.Categories = await context.Category
                .OrderBy(cc => cc.Name).ToListAsync();

            model.VenCat = await context.VendorCategory
                .Where(v => v.VendorUser == User)
                .OrderBy(c => c.Category.Name).ToListAsync();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(EditVendorProfileViewModel model, [FromRoute] string Id)
        {
            var User = await GetCurrentUserAsync();

            VendorUser vu = context.VendorUser.Where(i => i.Id == Id).SingleOrDefault();

            vu.FirstName = model.VendorUsers.FirstName;
            vu.LastName = model.VendorUsers.LastName;
            vu.CompanyName = model.VendorUsers.CompanyName;
            vu.Description = model.VendorUsers.Description;
            vu.StreetAddress = model.VendorUsers.StreetAddress;
            vu.Zip = model.VendorUsers.Zip;
            vu.ProfileImage = model.VendorUsers.ProfileImage;
            vu.Website = model.VendorUsers.Website;

            if (ModelState.IsValid)
            {
                context.Add(vu);
            }

            try
            {
                context.SaveChanges();
                return RedirectToAction("Profile", "Vendor");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCat(EditVendorProfileViewModel model, [FromBody] int [] cat)
        {
                model.CatListing = cat;
                var User = await GetCurrentUserAsync();
            
                if (ModelState.IsValid)
                {
                    foreach (int catid in model.CatListing)
                    {
                        context.VendorCategory.Add(new VendorCategory { VendorUser = User, CategoryId = catid });
                    }
                }
                context.SaveChanges();
                return RedirectToAction("Profile", "Vendor");
            

            //    var User = await GetCurrentUserAsync();

            //    List <Category> c = model.Categories.ToList();
            //    foreach (Category cat in c)
            //    {
            //        // Try to find an Attendee record that matches the EmployeeId and current ProgramId (from loop)
            //        VendorCategory vct = await context.VendorCategory.Where(a => a.VendorUser.Id == User.Id).SingleOrDefaultAsync();
            //        if (vct == null && model.VenCat != null && model.VenCat.Contains(vct))
            //        {
            //            // If a program was selected but no attendee record exists, add one
            //            context.VendorCategory.Add(new VendorCategory { Category = model.Categories.SingleOrDefault(), VendorUser = User });
            //        }
            //        else if (vct != null && model.VenCat != null && !model.VenCat.Contains(vct))
            //        {
            //            // If a program was not selected, but an attendee record exists, remove it
            //            context.VendorCategory.Remove(vct);
            //        }
            //        else if (vct != null && model.VenCat == null)
            //        {
            //            // If a program was not selected, but an attendee record exists, remove it
            //            context.VendorCategory.Remove(vct);
            //        }


            //    await context.SaveChangesAsync();
            //}

            //try
            //{
            //    return RedirectToAction("Profile", "Vendor");
            //}

            //catch (DbUpdateException)
            //{
            //    return RedirectToAction("Index", "Home");
            //}


        }
    }
}