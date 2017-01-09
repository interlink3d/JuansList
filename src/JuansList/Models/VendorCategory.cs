using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JuansList.Models
{
    public class VendorCategory 
    {
        [Key]
        public int VendorCategoryId { get; set; }

        [Required]
        public VendorUser VendorUser { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
