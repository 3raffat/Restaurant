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

    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> Repository { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterPartnerController(IRepository<MasterPartner> Repository, IHostingEnvironment _Host)
        {
            this.Repository = Repository;
            Host = _Host;
        }
        // GET: MasterPartnerController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: MasterPartnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterPartnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterPartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPartnerModel collection)
        {
            string imgName = SaveImg(collection.File);
            try
            {
                var data = new MasterPartner
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterPartnerLogoImageUrl = imgName,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
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

        // GET: MasterPartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Repository.Find(id);
            var obj = new MasterPartnerModel
            {
                MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl,
                MasterPartnerName = data.MasterPartnerName,
                MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl,

            };

            return View(obj);
        }

        // POST: MasterPartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPartnerModel collection)
        {

            try
            {
                if (!ModelState.IsValid)
                {

                    var x = Repository.Find(id);
                    var obj = new MasterPartnerModel
                    {
                        MasterPartnerWebsiteUrl = x.MasterPartnerWebsiteUrl,
                        MasterPartnerName = x.MasterPartnerName,
                        MasterPartnerLogoImageUrl = x.MasterPartnerLogoImageUrl,

                    };

                    return View(obj);


                }




                string imgName = SaveImg(collection.File);
                var data = new MasterPartner
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterPartnerLogoImageUrl = (imgName == "" ? collection.MasterPartnerLogoImageUrl : imgName),

                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                };
                Repository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Delete/5


        public ActionResult Delete(int id, MasterPartner collection)
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

                string path = Path.Combine(Host.WebRootPath, "Admin/Images/Partner");
                FileInfo f = new FileInfo(File.FileName);
                imgName = Guid.NewGuid().ToString() + f.Extension;
                string FullPath = Path.Combine(path, imgName);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return imgName;
        }
    }
}
