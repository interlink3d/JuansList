using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JuansList.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int Profesionalism { get; set; }

        [Required]
        public int Quality { get; set; }

        [Required]
        public int Communication { get; set; }

        [Required]
        public int Efficiency { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Reply { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public VendorUser VendorUser { get; set; }

        [Required]
        public CustomerUser CustomerUser { get; set; }

    }
}
