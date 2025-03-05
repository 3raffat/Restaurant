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

    public class MasterSliderController : Controller
    {
        public IRepository<MasterSlider> Repository { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterSliderController(IRepository<MasterSlider> Repository, IHostingEnvironment _Host)
        {
            this.Repository = Repository;
            Host = _Host;
        }
        // GET: MasterSliderController
        public ActionResult Index()
        {
            return View(Repository.View());
        }

        // GET: MasterSliderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Update_Active(int id)
        {
            Repository.Active(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: MasterSliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSliderModel collection)
        {
            string imgName = SaveImg(collection.File);
            try
            {
                var data = new MasterSlider
                {
                    EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderUrl = imgName,

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

        // GET: MasterSliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Repository.Find(id);
            var obj = new MasterSliderModel
            {
                MasterSliderTitle = data.MasterSliderTitle,
                MasterSliderDesc = data.MasterSliderDesc,
                MasterSliderBreef = data.MasterSliderBreef,
                MasterSliderUrl = data.MasterSliderUrl,

            };

            return View(obj);
        }

        // POST: MasterSliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSliderModel collection)
        {

            //try
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        var x = Repository.Find(id);
            //        var obj = new MasterSliderModel
            //        {
            //            MasterSliderTitle = x.MasterSliderTitle,
            //            MasterSliderDesc = x.MasterSliderDesc,
            //            MasterSliderBreef = x.MasterSliderBreef,
            //            MasterSliderUrl = x.MasterSliderUrl,

            //        };

            //        return View(obj);


            //    }
            //    string imgName = SaveImg(collection.File);
            //    var data = new MasterSlider
            //    {
            //        EditId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
            //        CreateId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
            //        MasterSliderTitle = collection.MasterSliderTitle,
            //        MasterSliderDesc = collection.MasterSliderDesc,
            //        MasterSliderBreef = collection.MasterSliderBreef,
            //        MasterSliderUrl = (imgName == "" ? collection.MasterSliderUrl : imgName)
            //    };
            //    Repository.Update(id, data);
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Input Value Required...!");
                    var dataOBJ = Repository.Find(id);

                    var dataObj = new MasterSliderModel
                    {
                        MasterSliderTitle = dataOBJ.MasterSliderTitle,
                        MasterSliderDesc = dataOBJ.MasterSliderDesc,
                        MasterSliderBreef = dataOBJ.MasterSliderBreef,
                        MasterSliderUrl = dataOBJ.MasterSliderUrl,
                    };


                    return View(dataObj);
                }
                string ImageName = SaveImg(collection.File);


                //if(ImageName=="")
                //{
                //    ImageName =Products.Find(id).ProductImageUrl;
                //}

                var data = new MasterSlider
                {
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderUrl = (ImageName == "" ? collection.MasterSliderUrl : ImageName),

                };

                Repository.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        // GET: MasterSliderController/Delete/5


        public ActionResult Delete(int id, MasterSlider collection)
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

                string path = Path.Combine(Host.WebRootPath, "Admin/Images/Slider");
                FileInfo f = new FileInfo(File.FileName);
                imgName = Guid.NewGuid().ToString() + f.Extension;
                string FullPath = Path.Combine(path, imgName);
                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }

            return imgName;
        }
    }
}
