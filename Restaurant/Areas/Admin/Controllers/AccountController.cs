using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.ViewModels;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]

    //[Route("Admin/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly UserManager<IdentityUser> UserManager;

        public AccountController(
            SignInManager<IdentityUser> _SignInManager,
            UserManager<IdentityUser> _UserManager
          )
        {
            SignInManager = _SignInManager;
            UserManager = _UserManager;
        }

        //[Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Index()
        {
            //var users = UserManager.Users;
            //var list = new List<RegisterModel>();
            //foreach (var user in users)
            //{
            //    var obj = new RegisterModel();
            //    obj.Email = user.Email;
            //    obj.UserName = user.UserName;
            //    list.Add(obj);
            //}
            var users = UserManager.Users.Select(x => new RegisterModel
            {
                UserName = x.UserName,
                Email = x.Email,

            }).ToList();

            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Email or Password is not correct");
                    return View();
                }

                var user = new IdentityUser
                {

                    UserName = collection.UserName


                };
                var data = await SignInManager.PasswordSignInAsync(collection.UserName, collection.Password, isPersistent: collection.RememberMe, false);

                if (data.Succeeded)
                {

                    return RedirectToAction("Index", "Home");

                }

                //Category.Add(collection);
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }

        //[Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Email or Password is not correct");
                    return View();
                }

                var user = new IdentityUser
                {
                    Email = collection.Email,
                    UserName = collection.UserName,
                    //Id = collection.UserId

                };
                var data = await UserManager.CreateAsync(user, collection.Password);

                if (data.Succeeded)
                {
                    return RedirectToAction(nameof(Index));

                }

                return RedirectToAction(nameof(Register));

            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Email or Password is not correct");
                    return View();
                }

                var user = new IdentityUser
                {
                    Email = collection.Email,
                    UserName = collection.UserName,
                    //Id = collection.UserId

                };
                var data = await UserManager.CreateAsync(user, collection.Password);

                if (data.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(Login));

                }

                return RedirectToAction(nameof(Register));

            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public async Task<ActionResult> Delete(string name)
        {
            var userr = await UserManager.FindByNameAsync(name);
            if (userr == null)
            {
                return NotFound();
            }
            var result = await UserManager.DeleteAsync(userr);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));

        }
        //public async Task<IActionResult> Edit(string Name)
        //{
        //    var user = await UserManager.FindByNameAsync(Name);
        //    var obj = new RegisterModel
        //    {
        //        UserName = user.UserName,
        //        Email = user.Email,

        //    };
        //    return View(obj);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(string Name, RegisterModel model)
        //{
        //    var user = await UserManager.FindByNameAsync(Name);

        //    user.Email = model.Email;
        //    user.NormalizedEmail = model.Email.ToUpperInvariant();
        //    user.UserName = model.UserName;
        //    user.NormalizedUserName = model.UserName.ToUpperInvariant();
        //    user.PasswordHash = model.Password;
        //    var result = await UserManager.UpdateAsync(user);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("Index", "Account");

        //    }
        //    return RedirectToAction("Index", "Account");

        //}

    }
}






