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

    public class MasterServicesController : Controller
    {
        public IRepository<MasterServices> Repository { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterServicesController(IRepository<MasterServices> Repository, IHostingEnvironment _Host)
        {
            this.Repository = Repository;
            Host = _Host;
        }
        // GET: MasterServicesController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: MasterServicesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterServicesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterServicesModel collection)
        {
            try
            {
                var data = new MasterServices
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesDesc = collection.MasterServicesDesc,
                    MasterServicesImage = collection.MasterServicesImage,
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

        // GET: MasterServicesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Repository.Find(id);
            var obj = new MasterServicesModel
            {
                MasterServicesTitle = data.MasterServicesTitle,
                MasterServicesDesc = data.MasterServicesDesc,
                MasterServicesImage = data.MasterServicesImage,

            };

            return View(obj);
        }

        // POST: MasterServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterServicesModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {



                    var x = Repository.Find(id);
                    var obj = new MasterServicesModel
                    {
                        MasterServicesTitle = x.MasterServicesTitle,
                        MasterServicesDesc = x.MasterServicesDesc,
                        MasterServicesImage = x.MasterServicesImage,

                    };

                    return View(obj);


                }


                var data = new MasterServices
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesDesc = collection.MasterServicesDesc,
                    MasterServicesImage = collection.MasterServicesImage,
                };
                Repository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServicesController/Delete/5


        public ActionResult Delete(int id, MasterServices collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;  //User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Repository.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
        public string SaveImg(IFormFile File)
        {
            string imgName = "";
            if (File != null)
            {

                string path = Path.Combine(Host.WebRootPath, "Admin/Images/Services");
                FileInfo f = new FileInfo(File.FileName);
                imgName = Guid.NewGuid().ToString() + f.Extension;
                string FullPath = Path.Combine(path, imgName);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return imgName;
        }
    }
}
