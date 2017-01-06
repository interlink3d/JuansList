using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using JuansList.Models;


namespace JuansList.ViewModels
{
    public class VendorProfileViewModel
    {

        public VendorUser VendorUser { get; set; }

        public List<VendorCategory> VenCat { get; set; }

        public List<Album> Albums { get; set; }

        public List<AlbumImages> Images { get; set; }

        public List<Coupon> Coupons { get; set; }

        public List<Review> Reviews { get; set; }

    }
}
