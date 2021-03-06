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
    public class CustomerController : Controller
    {
        private ApplicationDbContext context;
        // Private variable for userManager helper function
        private readonly UserManager<VendorUser> _userManager;
        private readonly UserManager<CustomerUser> _userManager2;

        //Constructor functions that takes both context AND the userManager object
        //and sets them to the private variables above
        public CustomerController(UserManager<VendorUser> userManager, UserManager<CustomerUser> userManager2, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _userManager2 = userManager2;
            context = ctx;
        }

        // This task retrieves the currently authenticated user
        private Task<CustomerUser> GetCurrentUserAsync() => _userManager2.GetUserAsync(HttpContext.User);


        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var User = await GetCurrentUserAsync();

            var model = new CustomerProfileViewModel();
            model.CustomerUser = User;

            model.estimates = await context.Estimate.ToListAsync();

            model.messages = await context.Message.ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromRoute] int id)
        {
            var user = await GetCurrentUserAsync();

            var model = new SearchViewModel();

            model.vendors = await context.VendorUser
                .Include(vcg => vcg.VendorCategories)
                .Where(v => v.VendorCategories.FirstOrDefault().CategoryId == id)
                .ToListAsync();

            //model.categories =
            //                    (from vc in context.VendorCategory
            //                     where vc.CategoryId == id
            //                     join c in context.Category on vc.CategoryId == c.CategoryId
            //                     select vc).ToListAsync();

            return View(model);
        }
    }
}