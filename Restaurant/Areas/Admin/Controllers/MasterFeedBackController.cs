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

    public class MasterFeedBackController : Controller
    {
        public IRepository<MasterFeedBack> Repository { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterFeedBackController(IRepository<MasterFeedBack> Repository, IHostingEnvironment _Host)
        {
            this.Repository = Repository;
            Host = _Host;
        }
        // GET: MasterFeedBackController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: MasterFeedBackController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterFeedBackController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterFeedBackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterFeedBackModel collection)
        {
            string imgName = SaveImg(collection.CustomerImg);
            try
            {
                var data = new MasterFeedBack
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterFeedBackCustomerName = collection.MasterFeedBackCustomerName,
                    MasterFeedBackDesc = collection.MasterFeedBackDesc,
                    MasterFeedBackCustomerUrl = imgName
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

        // GET: MasterFeedBackController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Repository.Find(id);
            var obj = new MasterFeedBackModel
            {
                MasterFeedBackCustomerName = data.MasterFeedBackCustomerName,
                MasterFeedBackDesc = data.MasterFeedBackDesc,
                MasterFeedBackCustomerUrl = data.MasterFeedBackCustomerUrl,
            };

            return View(obj);
        }

        // POST: MasterFeedBackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterFeedBackModel collection)
        {

            try
            {
                if (!ModelState.IsValid)
                {

                    var x = Repository.Find(id);
                    var obj = new MasterFeedBackModel
                    {
                        MasterFeedBackCustomerName = x.MasterFeedBackCustomerName,
                        MasterFeedBackDesc = x.MasterFeedBackDesc,
                        MasterFeedBackCustomerUrl = x.MasterFeedBackCustomerUrl,

                    };

                    return View(obj);


                }




                string imgName = SaveImg(collection.CustomerImg);
                var data = new MasterFeedBack
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterFeedBackCustomerUrl = (imgName == "" ? collection.MasterFeedBackCustomerUrl : imgName),

                    MasterFeedBackCustomerName = collection.MasterFeedBackCustomerName,
                    MasterFeedBackDesc = collection.MasterFeedBackDesc,
                };
                Repository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterFeedBackController/Delete/5


        public ActionResult Delete(int id, MasterFeedBack collection)
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

                string path = Path.Combine(Host.WebRootPath, "Admin/Images/FeedBack");
                FileInfo f = new FileInfo(File.FileName);
                imgName = Guid.NewGuid().ToString() + f.Extension;
                string FullPath = Path.Combine(path, imgName);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return imgName;
        }
    }
}
