using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JuansList.Models;

namespace JuansList.ViewModels
{
    public class AddAlbumViewModel
    {
        public Album Album { get; set; }

        public AlbumImages AlbumImages { get; set; }

        public VendorUser VendorUser { get; set; }
    }
}
