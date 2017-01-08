using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using JuansList.Models;

namespace JuansList.ViewModels
{
    public class EditVendorProfileViewModel 
    {

        public VendorUser VendorUsers { get; set; }

        public List<VendorCategory> VenCat { get; set; }

        public List<Category> Categories { get; set; }

        public List<Album> Albums { get; set; }

        public List<Coupon> Coupons { get; set; }
    }
}
