using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]

    public class TransactionNewsletterController : Controller
    {
        public IRepository<TransactionNewsletter> Repository { get; }

        public TransactionNewsletterController(IRepository<TransactionNewsletter> Repository)
        {
            this.Repository = Repository;
        }
        // GET: TransactionNewsletterController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: TransactionNewsletterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: TransactionNewsletterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionNewsletterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionNewsletter collection)
        {
            try
            {

                collection.CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value;  //User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Repository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionNewsletterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Repository.Find(id));
        }

        // POST: TransactionNewsletterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionNewsletter collection)
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

        // GET: TransactionNewsletterController/Delete/5


        public ActionResult Delete(int id, TransactionNewsletter collection)
        {
            Repository.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
    }
}
