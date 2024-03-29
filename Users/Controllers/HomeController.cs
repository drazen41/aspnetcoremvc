﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Users.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Users.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<AppUser> userManager;
        public HomeController(UserManager<AppUser>usrMgr)
        {
            userManager = usrMgr;
        }
        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            return View(GetData(nameof(Index)));
        }
        //[Authorize(Roles = "Users")]
        [Authorize(Policy ="DCUsers")]
        public IActionResult OtherAction() => View("Index",GetData(nameof(OtherAction)));
        [Authorize(Policy ="NotBob")]
        public IActionResult NotBob() => View("Index", GetData(nameof(NotBob)));
        private Dictionary<string, object> GetData(string actionName) =>
            new Dictionary<string, object>
            {
                ["Action"] = actionName,
                ["User"] = HttpContext.User.Identity.Name,
                ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
                ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
                ["In Users Role"] = HttpContext.User.IsInRole("Users"),
                ["City"] = CurrentUser.Result.City,
                ["Qualification"] = CurrentUser.Result.Qualifications
            };
        [Authorize]
        public async Task<IActionResult> UserProps()
        {
            return View(await CurrentUser);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserProps([Required]Cities city,[Required]QualificationLevels qualifications)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await CurrentUser;
                user.City = city;
                user.Qualifications = qualifications;
                await userManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            return View(await CurrentUser);
        }
        private Task<AppUser> CurrentUser => userManager.FindByNameAsync(HttpContext.User.Identity.Name);
    }
}
