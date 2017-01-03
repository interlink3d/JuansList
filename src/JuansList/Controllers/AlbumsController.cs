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
            var model = new AddAlbumViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task <IActionResult> AddAlbum(AddAlbumViewModel model)
        {
            ModelState.Remove("VendorUser");

            if (ModelState.IsValid)
            {
                var VendorUser = await GetCurrentUserAsync();
                model.Album.VendorUser = VendorUser;
                model.Images.ImageUrl = model.Images.ImageUrl;
            
                context.Add(model);
           
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

            var b = await context.AlbumImages.ToListAsync();

            if (a == null)
            {
                return NotFound();
            }

            var model = new AlbumDetailViewModel()
            {
                SingleAlbum = a,
                Images = b
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAlbum(AlbumDetailViewModel model, [FromRoute] int id)
        {
            Album alb = context.Album.Where(i => i.AlbumId == id).SingleOrDefault();
            AlbumImages ai = context.AlbumImages.Where(aid => aid.AlbumId == id).SingleOrDefault();

            alb.VendorUser = await GetCurrentUserAsync();
            alb.Title = model.SingleAlbum.Title;
            ai.ImageUrl = model.SingleImage.ImageUrl;

            if (ModelState.IsValid)
            {
                context.Add(alb);
                context.Add(ai);
            }

            try
            {
                context.SaveChanges();
                return RedirectToAction("UpdateProfile", "Vendor");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteAlbum([FromRoute] int id)
        {
            var alb =
                from a in context.Album
                where a.AlbumId == id
                select a;

            context.Album.Remove(alb.SingleOrDefault());

            if (ModelState.IsValid)
            {
                context.SaveChanges();
                return RedirectToAction("UpdateProfile", "Vendor");
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteImage([FromRoute] int id)
        {
            var ai =
                from a in context.AlbumImages
                where a.AlbumImagesId == id
                select a;

            context.AlbumImages.Remove(ai.SingleOrDefault());

            if (ModelState.IsValid)
            {
                context.SaveChanges();
                return RedirectToAction("AlbumDetail", "Album");
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}