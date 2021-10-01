//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebApplication2.Data.Models;
//using WebApplication2.Services.View_Models;

//namespace WebApplication2.Controllers
//{
//    public class AuthController : Controller
//    {
//        private readonly UserManager<User> userManager;
//        private readonly SignInManager<User> signInManager;
//        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
//        {
//            this.userManager = userManager;
//            this.signInManager = signInManager;
//        }
//        public IActionResult Register()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Register(RegisterViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                // Copy data from RegisterViewModel to IdentityUser
//                var user = new User
//                {
//                    UserName = model.FirstName + "_" + model.LastName,
//                    Email = model.Email
//                };

//                var result = await userManager.CreateAsync(user, model.Password);

//                if (result.Succeeded)
//                {
//                    await signInManager.SignInAsync(user, isPersistent: false);
//                    return RedirectToAction("Index", "Home");
//                }

//            }
//            return View(model);
//        }

//    }
//}
