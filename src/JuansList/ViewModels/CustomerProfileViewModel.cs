using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using JuansList.Models;

namespace JuansList.ViewModels
{
    public class CustomerProfileViewModel
    {
        public CustomerUser CustomerUser { get; set; }

        public List<Message> messages { get; set; }

        public List<Estimate> estimates { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
