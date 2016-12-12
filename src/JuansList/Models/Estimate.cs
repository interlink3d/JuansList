using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JuansList.Models
{
    public class Estimate
    {
        [Key]
        public int EstimateId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int? Price { get; set; }
        
        [Required]
        public DateTime DateStart { get; set; }
        
        [Required]
        public DateTime DateEnd { get; set; }
        
        [Required]
        public VendorUser VendorUser { get; set; }

        [Required]
        public CustomerUser CustomerUser { get; set; }
         
    }
}
