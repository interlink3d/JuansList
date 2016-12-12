using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JuansList.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime DateStamp { get; set; }

        [Required]
        public VendorUser VendorUser { get; set; }

        [Required]
        public CustomerUser CustomerUser { get; set; }

    }
}
