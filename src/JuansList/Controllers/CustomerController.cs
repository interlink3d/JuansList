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
        private readonly UserManager<CustomerUser> _userManager;

        //Constructor functions that takes both context AND the userManager object
        //and sets them to the private variables above
        public CustomerController(UserManager<CustomerUser> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            context = ctx;
        }

        // This task retrieves the currently authenticated user
        private Task<CustomerUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        public IActionResult Index()
        {
            return View();
        }
    }
}