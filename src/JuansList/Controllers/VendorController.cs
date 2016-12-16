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

        public IActionResult Index()
        {
            return View();
        }


    }
}