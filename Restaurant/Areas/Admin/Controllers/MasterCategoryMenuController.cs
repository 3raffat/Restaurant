using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class MasterCategoryMenuController : Controller
    {
        public IRepository<MasterCategoryMenu> Repository { get; }

        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> Repository)
        {
            this.Repository = Repository;
        }
        // GET: MasterCategoryMenuController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: MasterCategoryMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterCategoryMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterCategoryMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterCategoryMenu collection)
        {
            try
            {
                collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;   //User.FindFirst(ClaimTypes.NameIdentifier).Value;
                collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value;    //User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Repository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Repository.Find(id));
        }

        // POST: MasterCategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterCategoryMenu collection)
        {
            try
            {
                collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Repository.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Delete/5


        public ActionResult Delete(int id, MasterCategoryMenu collection)
        {
            collection.EditId = "1";//User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Repository.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
    }
}
