using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class MasterOfferController : Controller
    {
        public IRepository<MasterOffer> Repository { get; }
        public IWebHostEnvironment Host { get; }

        public MasterOfferController(IRepository<MasterOffer> Repository, IWebHostEnvironment _Host)
        {
            this.Repository = Repository;
            Host = _Host;
        }
        // GET: MasterOfferController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: MasterOfferController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterOfferController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterOfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOfferModel collection)
        {
            string imgName = SaveImg(collection.File);
            try
            {
                var data = new MasterOffer
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferBookNow = collection.MasterOfferBookNow,
                    MasterOfferImageUrl = imgName,
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

        // GET: MasterOfferController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Repository.Find(id);
            var obj = new MasterOfferModel
            {
                MasterOfferImageUrl = data.MasterOfferImageUrl,
                MasterOfferTitle = data.MasterOfferTitle,
                MasterOfferBreef = data.MasterOfferBreef,
                MasterOfferDesc = data.MasterOfferDesc,
                MasterOfferBookNow = data.MasterOfferBookNow,

            };
            return View(obj);
        }

        // POST: MasterOfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterOfferModel collection)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Input Value Required...!");
                    var dataOBJ = Repository.Find(id);

                    var dataObj = new MasterOfferModel
                    {
                        MasterOfferTitle = dataOBJ.MasterOfferTitle,
                        MasterOfferDesc = dataOBJ.MasterOfferDesc,
                        MasterOfferBreef = dataOBJ.MasterOfferBreef,
                        MasterOfferImageUrl = dataOBJ.MasterOfferImageUrl,
                        MasterOfferBookNow = dataOBJ.MasterOfferBookNow,

                    };


                    return View(dataObj);
                }
                string ImageName = SaveImg(collection.File);


                //if(ImageName=="")
                //{
                //    ImageName =Products.Find(id).ProductImageUrl;
                //}

                var data = new MasterOffer
                {
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferImageUrl = (ImageName == "" ? collection.MasterOfferImageUrl : ImageName),
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferBookNow = collection.MasterOfferBookNow,


                };

                Repository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        // GET: MasterOfferController/Delete/5


        public ActionResult Delete(int id, MasterOffer collection)
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

                string path = Path.Combine(Host.WebRootPath, "Admin/Images/Offers");
                FileInfo f = new FileInfo(File.FileName);
                imgName = Guid.NewGuid().ToString() + f.Extension;
                string FullPath = Path.Combine(path, imgName);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return imgName;
        }
    }
}
