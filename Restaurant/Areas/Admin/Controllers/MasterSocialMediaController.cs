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

    public class MasterSocialMediaController : Controller
    {
        public IRepository<MasterSocialMedia> Repository { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterSocialMediaController(IRepository<MasterSocialMedia> Repository, IHostingEnvironment _Host)
        {
            this.Repository = Repository;
            Host = _Host;
        }
        // GET: MasterSocialMediaController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: MasterSocialMediaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterSocialMediaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSocialMediaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSocialMediaModel collection)
        {

            try
            {
                var data = new MasterSocialMedia
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterSocialMediaImageUrl = collection.MasterSocialMediaImageUrl,
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl,
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

        // GET: MasterSocialMediaController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Repository.Find(id);
            var obj = new MasterSocialMediaModel
            {
                MasterSocialMediaImageUrl = data.MasterSocialMediaImageUrl,
                MasterSocialMediaUrl = data.MasterSocialMediaUrl,

            };

            return View(obj);
        }

        // POST: MasterSocialMediaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMediaModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var x = Repository.Find(id);
                    var obj = new MasterSocialMediaModel
                    {
                        MasterSocialMediaImageUrl = x.MasterSocialMediaImageUrl,
                        MasterSocialMediaUrl = x.MasterSocialMediaUrl,

                    };

                    return View(obj);
                }
                string imgName = SaveImg(collection.File);

                var data = new MasterSocialMedia
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl,
                    MasterSocialMediaImageUrl = collection.MasterSocialMediaImageUrl
                };
                Repository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediaController/Delete/5


        public ActionResult Delete(int id, MasterSocialMedia collection)
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

                string path = Path.Combine(Host.WebRootPath, "Admin/Images/Media");
                FileInfo f = new FileInfo(File.FileName);
                imgName = Guid.NewGuid().ToString() + f.Extension;
                string FullPath = Path.Combine(path, imgName);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return imgName;
        }
    }
}
