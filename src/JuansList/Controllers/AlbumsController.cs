using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using JuansList.Data;
using JuansList.Models;
using JuansList.ViewModels;

namespace JuansList.Controllers
{
    public class AlbumsController : Controller
    {
        private ApplicationDbContext context;
        // Private variable for userManager helper function
        private readonly UserManager<VendorUser> _userManager;

        //Constructor functions that takes both context AND the userManager object
        //and sets them to the private variables above
        public AlbumsController(UserManager<VendorUser> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            context = ctx;
        }

        // This task retrieves the currently authenticated user
        private Task<VendorUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        [HttpGet]
        public IActionResult AddAlbum()
        {
            var model = new Album();

            return View(model);
        }

        [HttpPost]
        public async Task <IActionResult> AddAlbum(Album album)
        {
            ModelState.Remove("VendorUser");

            if (ModelState.IsValid)
            {
                var VendorUser = await GetCurrentUserAsync();
                album.VendorUser = VendorUser;
                album.Images = album.Images;
            
                context.Add(album);
            }

            try
            {
                context.SaveChanges();
                return RedirectToAction("UpdateProfile", "Vendor");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("Profile", "Vendor");
            }
        }


        [HttpPost]
        public IActionResult AddImage()
        {
            return View();
        }

        [HttpGet]
        public async Task <IActionResult> GetAlbums()
        {
            var model = new AllAlbumsViewModel();
            model.Albums = await context.Album
                .OrderBy(a => a.Title).ToListAsync();

            return View();
        }

        [HttpGet]
        public async Task <IActionResult> AlbumDetail([FromRoute] int id)
        {
            var a = await context.Album
                    .SingleOrDefaultAsync(i => i.AlbumId == id);

            if (a == null)
            {
                return NotFound();
            }

            var model = new AlbumDetailViewModel()
            {
                SingleAlbum = a
            };

            return View(model);
        }
    }
}