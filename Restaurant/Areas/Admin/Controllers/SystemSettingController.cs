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

    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> Repository { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public SystemSettingController(IRepository<SystemSetting> Repository, IHostingEnvironment _Host)
        {
            this.Repository = Repository;
            Host = _Host;
        }
        // GET: SystemSettingController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: SystemSettingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemSettingModel collection)
        {
            string logo1 = SaveImg(collection.FileLogo1);
            string logo2 = SaveImg(collection.FileLogo2);
            string note = SaveImg(collection.FileNote);
            try
            {
                var data = new SystemSetting
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingLogoImageUrl = logo1,
                    SystemSettingLogoImageUrl2 = logo2,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteImageUrl = note,
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    contactUsPhone = collection.contactUsPhone,
                    contactUsLocation = collection.contactUsLocation,
                    contactUsEmail = collection.contactUsEmail,
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

        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Repository.Find(id);
            var obj = new SystemSettingModel
            {
                SystemSettingCopyright = data.SystemSettingCopyright,
                SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2,
                SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl,
                SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl,
                SystemSettingMapLocation = data.SystemSettingMapLocation,
                contactUsPhone = data.contactUsPhone,
                contactUsLocation = data.contactUsLocation,
                contactUsEmail = data.contactUsEmail,
            };

            return View(obj);
        }

        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemSettingModel collection)
        {
            string logo1 = SaveImg(collection.FileLogo1);
            string logo2 = SaveImg(collection.FileLogo2);
            string note = SaveImg(collection.FileNote);
            try
            {
                if (!ModelState.IsValid)
                {

                    var x = Repository.Find(id);
                    var obj = new SystemSettingModel
                    {
                        SystemSettingCopyright = x.SystemSettingCopyright,
                        SystemSettingLogoImageUrl = x.SystemSettingLogoImageUrl,
                        SystemSettingLogoImageUrl2 = x.SystemSettingLogoImageUrl2,
                        SystemSettingWelcomeNoteBreef = x.SystemSettingWelcomeNoteBreef,
                        SystemSettingWelcomeNoteDesc = x.SystemSettingWelcomeNoteDesc,
                        SystemSettingWelcomeNoteTitle = x.SystemSettingWelcomeNoteTitle,
                        SystemSettingWelcomeNoteUrl = x.SystemSettingWelcomeNoteUrl,
                        SystemSettingWelcomeNoteImageUrl = x.SystemSettingWelcomeNoteImageUrl,
                        SystemSettingMapLocation = x.SystemSettingMapLocation,
                        contactUsPhone = x.contactUsPhone,
                        contactUsLocation = x.contactUsLocation,
                        contactUsEmail = x.contactUsEmail,
                    };

                    return View(obj);
                }
                var data = new SystemSetting
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingLogoImageUrl = (logo1 == "" ? collection.SystemSettingLogoImageUrl : logo1),
                    SystemSettingLogoImageUrl2 = (logo2 == "" ? collection.SystemSettingLogoImageUrl2 : logo2),
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteImageUrl = (note == "" ? collection.SystemSettingWelcomeNoteImageUrl : note),
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    contactUsPhone = collection.contactUsPhone,
                    contactUsLocation = collection.contactUsLocation,
                    contactUsEmail = collection.contactUsEmail,
                };
                Repository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Delete/5


        public ActionResult Delete(int id, SystemSetting collection)
        {
            collection.EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value;//User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Repository.Delete(id, collection);
            return RedirectToAction(nameof(Index));
        }
        public string SaveImg(IFormFile File)
        {
            string imgName = "";
            if (File != null)
            {

                string path = Path.Combine(Host.WebRootPath, "Admin/Images/SystemSetting");
                FileInfo f = new FileInfo(File.FileName);
                imgName = Guid.NewGuid().ToString() + f.Extension;
                string FullPath = Path.Combine(path, imgName);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return imgName;
        }
    }
}
