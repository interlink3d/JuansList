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
using Microsoft.AspNetCore.Routing;

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
            ModelState.Remove("Album.VendorUser");
            ModelState.Remove("AlbumImages.AlbumId");

            if (ModelState.IsValid)
            {
                var VendorUser = await GetCurrentUserAsync();

                Album newAlbum = new Album();
                newAlbum.VendorUser = VendorUser;
                newAlbum.Title = model.Album.Title;
                context.Add(newAlbum);
                await context.SaveChangesAsync();

                AlbumImages alimg = new AlbumImages();
                alimg.ImageUrl = model.Images.ImageUrl;
                alimg.AlbumId = newAlbum.AlbumId;          
                context.Add(alimg);
                await context.SaveChangesAsync();

            }

            try
            {
                return RedirectToAction("UpdateProfile", "Vendor");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("Profile", "Vendor");
            }
        }


        [HttpGet]
        public IActionResult AddImage([FromRoute] int id)
        {
            AlbumImages model = new AlbumImages();
            model.AlbumId = id;

            return View(model);
        }

        [HttpPost]
        public IActionResult AddImage(AlbumImages image, [FromRoute] int id)
        {
            var albId = context.Album
                .Where(i => i.AlbumId == id).SingleOrDefault();

            if (ModelState.IsValid)
            {
                image.AlbumId = albId.AlbumId;
                context.Add(image);
            }

            try
            {
                context.SaveChanges();
                return RedirectToAction("AlbumDetail", new RouteValueDictionary(
                new { controller = "Albums", action = "AlbumDetail", Id = id }));
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task <IActionResult> GetAlbums()
        {
            var User = await GetCurrentUserAsync();

            var model = new AllAlbumsViewModel();
            model.Albums = await context.Album
                .Where(v => v.VendorUser == User)
                .OrderBy(a => a.Title).ToListAsync();

            return View();
        }

        [HttpGet]
        public async Task <IActionResult> AlbumDetail([FromRoute] int id)
        {
            var a = await context.Album
                    .SingleOrDefaultAsync(i => i.AlbumId == id);

            var b = await context.AlbumImages
                    .Where(aid => aid.AlbumId == id).ToListAsync();

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
            ModelState.Remove("SingleAlbum.VendorUser");
            ModelState.Remove("SingleAlbum.Images");

            Album alb = context.Album.Where(i => i.AlbumId == id).SingleOrDefault();
            //AlbumImages ai = context.AlbumImages.Where(aid => aid.AlbumId == id).ToAsyncEnumerable();
            List<AlbumImages> ai = model.Images.ToList();
                //context.AlbumImages.Where(aid => aid.AlbumId == id).ToList();


            if (ModelState.IsValid)
            {
                var VendorUser = await GetCurrentUserAsync();
                alb.VendorUser = VendorUser;
                alb.Title = model.SingleAlbum.Title;
                alb.Images = model.Images.ToArray();

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


        [HttpGet]
        public async Task<IActionResult> AlbumView ([FromRoute] int id)
        {
            var User = await GetCurrentUserAsync();

            var model = new AlbumDetailViewModel();

            model.SingleAlbum = context.Album
                .Where(v => v.VendorUser == User)
                .Where(i => i.AlbumId == id).SingleOrDefault();

            model.Images = await context.AlbumImages
                .Where(aid => aid.AlbumId == id).ToListAsync();

            return View(model);

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
                return RedirectToAction("UpdateProfile", "Vendor");
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}