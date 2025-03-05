using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]

    public class TransactionContactUsController : Controller
    {
        public IRepository<TransactionContactUs> Repository { get; }

        public TransactionContactUsController(IRepository<TransactionContactUs> Repository)
        {
            this.Repository = Repository;
        }
        // GET: TransactionContactUsController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: TransactionContactUsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: TransactionContactUsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionContactUsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionContactUs collection)
        {
            try
            {

                collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value; //User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Repository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionContactUsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Repository.Find(id));
        }

        // POST: TransactionContactUsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionContactUs collection)
        {
            try
            {
                Repository.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionContactUsController/Delete/5


        public ActionResult Delete(int id, TransactionContactUs collection)
        {
            Repository.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
    }
}
