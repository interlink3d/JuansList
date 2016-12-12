using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace JuansList.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public VendorUser VendorUser { get; set; }

        public ICollection<AlbumImages> Images {get; set;}

    }
}
