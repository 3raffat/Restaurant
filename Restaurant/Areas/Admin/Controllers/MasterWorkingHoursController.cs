using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class MasterWorkingHoursController : Controller
    {
        public IRepository<MasterWorkingHours> Repository { get; }

        public MasterWorkingHoursController(IRepository<MasterWorkingHours> Repository)
        {
            this.Repository = Repository;
        }
        // GET: MasterWorkingHoursController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: MasterWorkingHoursController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterWorkingHoursController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterWorkingHoursController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterWorkingHours collection)
        {
            try
            {
                collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;    //User.FindFirst(ClaimTypes.NameIdentifier).Value;
                collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value;  //User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Repository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHoursController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Repository.Find(id));
        }

        // POST: MasterWorkingHoursController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterWorkingHours collection)
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

        // GET: MasterWorkingHoursController/Delete/5


        public ActionResult Delete(int id, MasterWorkingHours collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;//User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Repository.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
    }
}

