using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JuansList.Models
{
    public class AlbumImages
    {
        [Key]
        public int AlbumImagesId { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int AlbumId { get; set; } 

    }
}
