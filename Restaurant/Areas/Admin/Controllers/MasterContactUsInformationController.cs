using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class MasterContactUsInformationController : Controller
    {
        public IRepository<MasterContactUsInformation> Repository { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterContactUsInformationController(IRepository<MasterContactUsInformation> Repository, IHostingEnvironment _Host, AppDbContext app)
        {
            this.Repository = Repository;
            Host = _Host;
        }
        // GET: MasterContactUsInformationController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: MasterContactUsInformationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterContactUsInformationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterContactUsInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterContactUsInformationModel collection)
        {
            string imgName = SaveImg(collection.File);
            try
            {
                var data = new MasterContactUsInformation
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                    MasterContactUsInformationImageUrl = imgName,
                    MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
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

        // GET: MasterContactUsInformationController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Repository.Find(id);
            var obj = new MasterContactUsInformationModel
            {
                MasterContactUsInformationImageUrl = data.MasterContactUsInformationImageUrl,
                MasterContactUsInformationRedirect = data.MasterContactUsInformationRedirect,
                MasterContactUsInformationIdesc = data.MasterContactUsInformationIdesc,

            };
            return View(obj);
        }

        // POST: MasterContactUsInformationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterContactUsInformationModel collection)
        {
            string imgName = SaveImg(collection.File);
            try
            {
                if (!ModelState.IsValid)
                {

                    var s = Repository.Find(id);
                    var obj = new MasterContactUsInformationModel
                    {
                        MasterContactUsInformationImageUrl = s.MasterContactUsInformationImageUrl,
                        MasterContactUsInformationRedirect = s.MasterContactUsInformationRedirect,
                        MasterContactUsInformationIdesc = s.MasterContactUsInformationIdesc,

                    };
                    return View(obj);


                }



                var data = new MasterContactUsInformation
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
                    MasterContactUsInformationImageUrl = (imgName == "" ? collection.MasterContactUsInformationImageUrl : imgName),
                };
                Repository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Delete/5


        public ActionResult Delete(int id, MasterContactUsInformation collection)
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

                string path = Path.Combine(Host.WebRootPath, "Admin/Images/ContactUsInfo");
                FileInfo f = new FileInfo(File.FileName);
                imgName = Guid.NewGuid().ToString() + f.Extension;
                string FullPath = Path.Combine(path, imgName);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return imgName;
        }
    }
}
