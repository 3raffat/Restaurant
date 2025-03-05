using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<MasterServices> MasterServices { get; }
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<MasterWorkingHours> MasterWorkingHours { get; }
        public IRepository<MasterSlider> MasterSlider { get; }
        public IRepository<MasterPartner> MasterPartner { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<MasterOffer> MasterOffer { get; }
        public IRepository<MasterFeedBack> MasterFeedBack { get; }
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<TransactionBookTable> TransactionBookTable { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }
        public IRepository<MasterSocialMedia> MasterSocialMedia { get; }
        public IRepository<TransactionContactUs> TransactionContactUs { get; }
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }

        public HomeController(IRepository<MasterServices> MasterServices,
            IRepository<MasterMenu> MasterMenu,
            IRepository<MasterWorkingHours> MasterWorkingHours,
            IRepository<MasterSlider> MasterSlider,
            IRepository<MasterPartner> MasterPartner,
            IRepository<SystemSetting> SystemSetting,
            IRepository<MasterOffer> MasterOffer,
            IRepository<MasterFeedBack> MasterFeedBack,
            IRepository<MasterSocialMedia> MasterSocialMedia,
            IRepository<MasterItemMenu> MasterItemMenu,
            IRepository<TransactionBookTable> TransactionBookTable,
            IRepository<TransactionNewsletter> TransactionNewsletter,
            IRepository<TransactionContactUs> TransactionContactUs,
            IRepository<MasterContactUsInformation> MasterContactUsInformation,
            IRepository<MasterCategoryMenu> MasterCategoryMenu)
        {
            this.MasterServices = MasterServices;
            this.MasterMenu = MasterMenu;
            this.MasterWorkingHours = MasterWorkingHours;
            this.MasterSlider = MasterSlider;
            this.MasterPartner = MasterPartner;
            this.SystemSetting = SystemSetting;
            this.MasterOffer = MasterOffer;
            this.MasterFeedBack = MasterFeedBack;
            this.MasterSocialMedia = MasterSocialMedia;
            this.MasterItemMenu = MasterItemMenu;
            this.TransactionBookTable = TransactionBookTable;
            this.TransactionNewsletter = TransactionNewsletter;
            this.TransactionContactUs = TransactionContactUs;
            this.MasterContactUsInformation = MasterContactUsInformation;
            this.MasterCategoryMenu = MasterCategoryMenu;
        }
        public IActionResult Index()
        {
            var set = SystemSetting.ViewClient().Last();
            var off = MasterOffer.ViewClient();
            var s = MasterContactUsInformation.ViewClient().Last();
            var data = new HomeModel
            {
                MasterMenu = MasterMenu.ViewClient(),
                MasterWorkingHours = MasterWorkingHours.ViewClient(),
                MasterSlider = MasterSlider.ViewClient(),
                MasterPartner = MasterPartner.ViewClient(),
                MasterFeedBack = MasterFeedBack.ViewClient(),
                MasterSocialMedia = MasterSocialMedia.ViewClient(),
                MasterItemMenu = MasterItemMenu.ViewClient(),
                MasterContactUsInformation = new MasterContactUsInformation
                {
                    MasterContactUsInformationIdesc = s.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = s.MasterContactUsInformationRedirect,
                },

                SystemSetting = new SystemSetting
                {
                    SystemSettingCopyright = set.SystemSettingCopyright,
                    SystemSettingLogoImageUrl = set.SystemSettingLogoImageUrl,
                    SystemSettingLogoImageUrl2 = set.SystemSettingLogoImageUrl2,
                    SystemSettingWelcomeNoteImageUrl = set.SystemSettingWelcomeNoteImageUrl,
                    SystemSettingWelcomeNoteUrl = set.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteTitle = set.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = set.SystemSettingWelcomeNoteBreef,
                    SystemSettingMapLocation = set.SystemSettingMapLocation,
                    SystemSettingWelcomeNoteDesc = set.SystemSettingWelcomeNoteDesc,
                    contactUsEmail = set.contactUsEmail,
                    contactUsLocation = set.contactUsLocation,
                    contactUsPhone = set.contactUsPhone,
                },
                MasterOffer = new MasterOffer(),
                //TransactionBookTable = new TransactionBookTable(),
                TransactionNewsletter = new TransactionNewsletter(),
            };
            if (off != null)
            {
                var offer = off.LastOrDefault();
                MasterOffer c = new MasterOffer
                {
                    MasterOfferTitle = offer?.MasterOfferTitle,
                    MasterOfferBreef = offer?.MasterOfferBreef,
                    MasterOfferDesc = offer?.MasterOfferDesc,
                    MasterOfferImageUrl = offer?.MasterOfferImageUrl,
                    MasterOfferBookNow = offer?.MasterOfferBookNow,

                };
                data.MasterOffer = c;
            }

            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HomeModel collection)
        {
            try
            {
                if (collection.TransactionBookTable != null)
                {

                    var data = collection.TransactionBookTable;
                    TransactionBookTable.Add(data);
                }
                if (collection.TransactionNewsletter != null)
                {

                    var data = collection.TransactionNewsletter;
                    TransactionNewsletter.Add(data);
                }
                if (collection.TransactionContactUs != null)
                {
                    var data = collection.TransactionContactUs;
                    TransactionContactUs.Add(data);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult About()
        {
            var s = MasterContactUsInformation.ViewClient().Last();

            var set = SystemSetting.ViewClient().Last();
            var data = new HomeModel
            {
                MasterServices = MasterServices.ViewClient(),
                MasterMenu = MasterMenu.ViewClient(),
                MasterSocialMedia = MasterSocialMedia.ViewClient(),
                TransactionNewsletter = new TransactionNewsletter(),
                SystemSetting = new SystemSetting
                {
                    SystemSettingCopyright = set.SystemSettingCopyright,
                    SystemSettingLogoImageUrl = set.SystemSettingLogoImageUrl,
                    SystemSettingLogoImageUrl2 = set.SystemSettingLogoImageUrl2,
                    SystemSettingWelcomeNoteImageUrl = set.SystemSettingWelcomeNoteImageUrl,
                    SystemSettingWelcomeNoteUrl = set.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteTitle = set.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = set.SystemSettingWelcomeNoteBreef,
                    SystemSettingMapLocation = set.SystemSettingMapLocation,
                    SystemSettingWelcomeNoteDesc = set.SystemSettingWelcomeNoteDesc,
                    contactUsEmail = set.contactUsEmail,
                    contactUsLocation = set.contactUsLocation,
                    contactUsPhone = set.contactUsPhone,
                },
                MasterContactUsInformation = new MasterContactUsInformation
                {
                    MasterContactUsInformationIdesc = s.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = s.MasterContactUsInformationRedirect,
                },
                MasterWorkingHours = MasterWorkingHours.ViewClient()

            };
            return View(data);
        }
        public IActionResult ContactUs()
        {
            var s = MasterContactUsInformation.ViewClient().Last();

            var set = SystemSetting.ViewClient().Last();
            var data = new HomeModel
            {
                MasterServices = MasterServices.ViewClient(),
                MasterMenu = MasterMenu.ViewClient(),
                MasterSocialMedia = MasterSocialMedia.ViewClient(),
                TransactionNewsletter = new TransactionNewsletter(),
                TransactionContactUs = new TransactionContactUs(),
                MasterContactUsInformation = new MasterContactUsInformation
                {
                    MasterContactUsInformationIdesc = s.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = s.MasterContactUsInformationRedirect,
                },
                SystemSetting = new SystemSetting
                {
                    SystemSettingCopyright = set.SystemSettingCopyright,
                    SystemSettingLogoImageUrl = set.SystemSettingLogoImageUrl,
                    SystemSettingLogoImageUrl2 = set.SystemSettingLogoImageUrl2,
                    SystemSettingWelcomeNoteImageUrl = set.SystemSettingWelcomeNoteImageUrl,
                    SystemSettingWelcomeNoteUrl = set.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteTitle = set.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = set.SystemSettingWelcomeNoteBreef,
                    SystemSettingMapLocation = set.SystemSettingMapLocation,
                    SystemSettingWelcomeNoteDesc = set.SystemSettingWelcomeNoteDesc,
                    contactUsEmail = set.contactUsEmail,
                    contactUsLocation = set.contactUsLocation,
                    contactUsPhone = set.contactUsPhone,
                },
                MasterWorkingHours = MasterWorkingHours.ViewClient()

            };
            return View(data);
        }
        public IActionResult Menu()
        {
            var s = MasterContactUsInformation.ViewClient().Last();

            var set = SystemSetting.ViewClient().Last();
            var data = new HomeModel
            {
                MasterPartner = MasterPartner.ViewClient(),
                MasterItemMenu = MasterItemMenu.ViewClient(),
                MasterServices = MasterServices.ViewClient(),
                MasterCategoryMenu = MasterCategoryMenu.ViewClient(),
                MasterMenu = MasterMenu.ViewClient(),
                MasterSocialMedia = MasterSocialMedia.ViewClient(),
                TransactionNewsletter = new TransactionNewsletter(),
                SystemSetting = new SystemSetting
                {
                    SystemSettingCopyright = set.SystemSettingCopyright,
                    SystemSettingLogoImageUrl = set.SystemSettingLogoImageUrl,
                    SystemSettingLogoImageUrl2 = set.SystemSettingLogoImageUrl2,
                    SystemSettingWelcomeNoteImageUrl = set.SystemSettingWelcomeNoteImageUrl,
                    SystemSettingWelcomeNoteUrl = set.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteTitle = set.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = set.SystemSettingWelcomeNoteBreef,
                    SystemSettingMapLocation = set.SystemSettingMapLocation,
                    SystemSettingWelcomeNoteDesc = set.SystemSettingWelcomeNoteDesc,
                    contactUsEmail = set.contactUsEmail,
                    contactUsLocation = set.contactUsLocation,
                    contactUsPhone = set.contactUsPhone,
                },
                MasterContactUsInformation = new MasterContactUsInformation
                {
                    MasterContactUsInformationIdesc = s.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = s.MasterContactUsInformationRedirect,
                },
                MasterWorkingHours = MasterWorkingHours.ViewClient()

            };
            return View(data);
        }
    }
}
