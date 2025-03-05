using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> Repository { get; }
        public IRepository<MasterCategoryMenu> CategoryMenu { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterItemMenuController(IRepository<MasterItemMenu> Repository, IRepository<MasterCategoryMenu> CategoryMenu, IHostingEnvironment _Host)
        {
            this.Repository = Repository;
            this.CategoryMenu = CategoryMenu;
            Host = _Host;
        }
        // GET: MasterItemMenuController
        public ActionResult Index()
        {
            var data = Repository.View();


            return View(data);
        }

        // GET: MasterItemMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterItemMenuController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryMenu = CategoryMenu.View();
            return View();
        }

        // POST: MasterItemMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterItemMenuModel collection)
        {
            string imgName = SaveImg(collection.File);
            try
            {
                ViewBag.CategoryMenu = CategoryMenu.View();

                var data = new MasterItemMenu
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuImageUrl = imgName,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                };

                //collection.EditId = "1";     //User.FindFirst(ClaimTypes.NameIdentifier).Value;
                //collection.CreateId = "1";  //User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Repository.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryMenu = CategoryMenu.View();

            var data = Repository.Find(id);
            var obj = new MasterItemMenuModel
            {
                MasterItemMenuImageUrl = data.MasterItemMenuImageUrl,
                MasterItemMenuTitle = data.MasterItemMenuTitle,
                MasterItemMenuDesc = data.MasterItemMenuDesc,
                MasterItemMenuPrice = data.MasterItemMenuPrice,
                MasterCategoryMenuId = data.MasterCategoryMenuId,

            };
            return View(obj);
        }

        // POST: MasterItemMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterItemMenuModel collection)
        {
            string imgName = SaveImg(collection.File);
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Input Value Required...!");
                    ViewBag.CategoryMenu = CategoryMenu.View();

                    var s = Repository.Find(id);
                    var obj = new MasterItemMenuModel
                    {
                        MasterItemMenuTitle = s.MasterItemMenuTitle,
                        MasterItemMenuDesc = s.MasterItemMenuDesc,
                        MasterItemMenuPrice = s.MasterItemMenuPrice,
                        MasterCategoryMenuId = s.MasterCategoryMenuId,

                    };
                    return View(obj);
                }
                var data = new MasterItemMenu
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,

                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuImageUrl = (imgName == "" ? collection.MasterItemMenuImageUrl : imgName)
                };
                Repository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Delete/5


        public ActionResult Delete(int id, MasterItemMenu collection)
        {
            collection.EditId = "1";//User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Repository.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
        public string SaveImg(IFormFile File)
        {
            string imgName = "";
            if (File != null)
            {

                string path = Path.Combine(Host.WebRootPath, "Admin/Images/ItemMenu");
                FileInfo f = new FileInfo(File.FileName);
                imgName = Guid.NewGuid().ToString() + f.Extension;
                string FullPath = Path.Combine(path, imgName);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return imgName;
        }
    }
}
