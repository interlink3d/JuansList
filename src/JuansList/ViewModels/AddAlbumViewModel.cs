﻿using System;
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

        public AlbumImages Images { get; set; }
        
    }
}
