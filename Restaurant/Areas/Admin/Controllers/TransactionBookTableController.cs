using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]

    public class TransactionBookTableController : Controller
    {
        public IRepository<TransactionBookTable> Repository { get; }

        public TransactionBookTableController(IRepository<TransactionBookTable> Repository)
        {
            this.Repository = Repository;
        }
        // GET: TransactionBookTableController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: TransactionBookTableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: TransactionBookTableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionBookTableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionBookTable collection)
        {
            try
            {
                collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;    //User.FindFirst(ClaimTypes.NameIdentifier).Value;
                collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value; //User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Repository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionBookTableController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Repository.Find(id));
        }

        // POST: TransactionBookTableController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionBookTable collection)
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

        // GET: TransactionBookTableController/Delete/5


        public ActionResult Delete(int id, TransactionBookTable collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;//User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Repository.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
    }
}
