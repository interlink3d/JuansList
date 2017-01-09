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
    public class CouponsController : Controller
    {
        private ApplicationDbContext context;
        // Private variable for userManager helper function
        private readonly UserManager<VendorUser> _userManager;

        //Constructor functions that takes both context AND the userManager object
        //and sets them to the private variables above
        public CouponsController(UserManager<VendorUser> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            context = ctx;
        }

        // This task retrieves the currently authenticated user
        private Task<VendorUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        [HttpGet]
        public IActionResult AddCoupon()
        {
            Coupon model = new Coupon();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCoupon(Coupon coupon)
        {
            ModelState.Remove("VendorUser");

            if (ModelState.IsValid)
            {
                var VendorUser = await GetCurrentUserAsync();
                coupon.VendorUser = VendorUser;

                context.Add(coupon);
            }

            try
            {
                context.SaveChanges();
                return RedirectToAction("UpdateProfile", "Vendor");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("UpdateProfile", "Vendor");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCoupons()
        {
            var User = await GetCurrentUserAsync();

            var model = new AllCouponsViewModel();
            model.Coupons = await context.Coupon
                .Where(v => v.VendorUser == User)
                .OrderBy(d => d.Title).ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CouponDetail([FromRoute] int id)
        {
            var c = await context.Coupon
                    .SingleOrDefaultAsync(cp => cp.CouponId == id);

            if (c == null)
            {
                return NotFound();
            }

            var model = new CouponDetailViewModel()
            {
                SingleCoupon = c
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCoupon(Coupon SingleCoupon, [FromRoute] int id)
        {
            Coupon cpn = context.Coupon.Where(i => i.CouponId == id).SingleOrDefault();

            cpn.VendorUser = await GetCurrentUserAsync();
            cpn.Title = SingleCoupon.Title;
            cpn.Content = SingleCoupon.Content;

            if (ModelState.IsValid)
            {
                context.Add(cpn);
            }

            try
            {
                context.SaveChanges();
                return RedirectToAction("GetCoupons", "Coupons");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteCoupon([FromRoute] int id)
        {
            var cpn =
                from c in context.Coupon
                where c.CouponId == id
                select c;

            context.Coupon.Remove(cpn.SingleOrDefault());

            if (ModelState.IsValid)
            {
                context.SaveChanges();
                return RedirectToAction("UpdateProfile", "Vendor");
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}