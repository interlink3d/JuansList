using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JuansList.Models;

namespace JuansList.Controllers
{
    public class VendorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}