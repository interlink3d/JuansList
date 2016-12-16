using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using JuansList.Models;

namespace JuansList.ViewModels
{
    public class AddCouponViewModel
    {
        public Coupon coupon { get; set; }
    }
}
