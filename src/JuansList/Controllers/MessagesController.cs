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
    public class MessagesController : Controller
    {
        private ApplicationDbContext context;
        // Private variable for userManager helper function
        private readonly UserManager<VendorUser> _userManager;

        //Constructor functions that takes both context AND the userManager object
        //and sets them to the private variables above
        public MessagesController(UserManager<VendorUser> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            context = ctx;
        }

        // This task retrieves the currently authenticated user
        private Task<VendorUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        [HttpGet]
        public IActionResult AddMessage()
        {
            Message model = new Message();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(Message message)
        {
            ModelState.Remove("VendorUser");
            ModelState.Remove("VendorUserId");
            ModelState.Remove("CustomerUser");

            if (ModelState.IsValid)
            {
                var VendorUser = await GetCurrentUserAsync();
                message.VendorUser = VendorUser;

                context.Add(message);
            }

            try
            {
                context.SaveChanges();
                return RedirectToAction("Profile", "Vendor");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("AddMessage", "Messages");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var User = await GetCurrentUserAsync();

            var model = new AllMessagesViewModel();
            model.Messages = await context.Message
                .Where(v => v.VendorUser == User)
                .OrderBy(d => d.DateStamp).ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetail([FromRoute] int id)
        {
            var m = await context.Message
                    .SingleOrDefaultAsync(mi => mi.MessageId == id);

            if (m == null)
            {
                return NotFound();
            }

            var model = new MessageDetailViewModel()
            {
                SingleMessage = m
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMessage(Message SingleMessage, [FromRoute] int id)
        {
            ModelState.Remove("VendorUser");

            Message msg = context.Message.Where(i => i.MessageId == id).SingleOrDefault();

            msg.VendorUser = await GetCurrentUserAsync();
            msg.Text = SingleMessage.Text;
            msg.DateStamp = SingleMessage.DateStamp;
           
            if (ModelState.IsValid)
            {
                context.Add(msg);
            }

            try
            {
                context.SaveChanges();
                return RedirectToAction("GetMessages", "Messages");
            }

            catch (DbUpdateException)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteMessage([FromRoute] int id)
        {
            var msg =
                from m in context.Message
                where m.MessageId == id
                select m;

            context.Message.Remove(msg.SingleOrDefault());

            if (ModelState.IsValid)
            {
                context.SaveChanges();
                return RedirectToAction("GetMessages", "Messages");
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}