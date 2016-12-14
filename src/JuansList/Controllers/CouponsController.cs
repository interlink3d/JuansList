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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCoupon()
        {
            return View();
        }
    }
}