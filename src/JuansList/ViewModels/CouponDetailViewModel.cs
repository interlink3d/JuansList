using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using JuansList.Models;

namespace JuansList.ViewModels
{
    public class CouponDetailViewModel
    {
        public Coupon SingleCoupon { get; set; }
    }
}
