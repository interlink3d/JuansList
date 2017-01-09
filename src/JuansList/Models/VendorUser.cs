using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JuansList.Models
{
    public class VendorUser : ApplicationUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public int Zip { get; set; }

        public string ProfileImage { get; set; }

        public string Website { get; set; }

        public int? Rating { get; set; }

        public ICollection<VendorCategory> VendorCategories { get; set; }

        public ICollection<Album> Albums { get; set; }

    }
}
