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
        public async Task <IActionResult> GetEstimates()
        {
            var model = new AllEstimatesViewModel();
            model.Estimates = await context.Estimate
                .OrderBy(d => d.DateStart).ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EstimateDetail([FromRoute] int id)
        {
            var e = await context.Estimate
                    .SingleOrDefaultAsync(m => m.EstimateId == id);

            if (e == null)
            {
                return NotFound();
            }

            var model = new EstimateDetailViewModel()
            {
                SingleEstimate = e
            };

            return View(model);
        }

        [HttpPost]
        public async Task <IActionResult> UpdateEstimate(Estimate SingleEstimate, [FromRoute] int id)
        {
            Estimate est = context.Estimate.Where(i => i.EstimateId == id).SingleOrDefault();

            est.VendorUser = await GetCurrentUserAsync();
            est.Title = SingleEstimate.Title;
            est.Description = SingleEstimate.Description;
            est.Price = SingleEstimate.Price;
            est.DateStart = SingleEstimate.DateStart;
            est.DateEnd = SingleEstimate.DateEnd;

            if (ModelState.IsValid)
            {
                context.Add(est);
            }

            try
            {
                context.SaveChanges();
                return RedirectToAction("GetEstimates", "Estimates");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteEstimate([FromRoute] int id)
        {
            var est =
                from e in context.Estimate
                where e.EstimateId == id
                select e;

            context.Estimate.Remove(est.SingleOrDefault());

            if (ModelState.IsValid)
            {
                context.SaveChanges();
                return RedirectToAction("GetEstimates", "Estimates");
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}