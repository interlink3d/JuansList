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
    public class EstimatesController : Controller
    {
        private ApplicationDbContext context;
        // Private variable for userManager helper function
        private readonly UserManager<VendorUser> _userManager;
        private readonly UserManager<CustomerUser> _userManager2;

        //Constructor functions that takes both context AND the userManager object
        //and sets them to the private variables above
        public EstimatesController(UserManager<VendorUser> userManager, UserManager<CustomerUser> userManager2, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _userManager2 = userManager2;
            context = ctx;
        }

        // This task retrieves the currently authenticated user
        private Task<VendorUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private Task<CustomerUser> GetCurrentUserAsync2() => _userManager2.GetUserAsync(HttpContext.User);

        [HttpGet]
        public IActionResult AddEstimate()
        {
            Estimate model = new Estimate();

            return View(model);
        }

        [HttpPost]
        public async Task <IActionResult> AddEstimate(Estimate estimate)
        {
            ModelState.Remove("VendorUser");
            ModelState.Remove("CustomerUser");

            if (ModelState.IsValid)
            {
                var VendorUser = await GetCurrentUserAsync();
                estimate.VendorUser = VendorUser;

                context.Add(estimate);
            }

            try
            {
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("AddEstimate", "Estimates");
            }
        }

        [HttpGet]
        public IActionResult GetEstimates()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetEstimate()
        {
            return View();
        }
    }
}