using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuansList.Models;

namespace JuansList.ViewModels
{
    public class AlbumDetailViewModel
    {
        public Album SingleAlbum { get; set; }

        public AlbumImages SingleImage { get; set; }

        public List<AlbumImages> Images { get; set; }

    }
}
