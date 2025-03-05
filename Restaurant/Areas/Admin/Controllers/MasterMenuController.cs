using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]

    public class MasterMenuController : Controller
    {
        public IRepository<MasterMenu> Repository { get; }

        public MasterMenuController(IRepository<MasterMenu> Repository)
        {
            this.Repository = Repository;
        }
        // GET: MasterMenuController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: MasterMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMenu collection)
        {
            try
            {
                collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;      //User.FindFirst(ClaimTypes.NameIdentifier).Value;
                collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value;    //User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Repository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Repository.Find(id));
        }

        // POST: MasterMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterMenu collection)
        {
            try
            {
                collection.EditId = "1";
                Repository.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Delete/5


        public ActionResult Delete(int id, MasterMenu collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;  //User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Repository.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
    }
}
