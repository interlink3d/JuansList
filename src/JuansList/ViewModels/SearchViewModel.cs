using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using JuansList.Models;

namespace JuansList.ViewModels
{
    public class SearchViewModel
    {
        public CustomerUser CustomerUser { get; set; }

        public VendorUser VendorUser { get; set; }

        public List<VendorUser> vendors { get; set; }

        public List<VendorCategory> categories { get; set; }


    }
}
