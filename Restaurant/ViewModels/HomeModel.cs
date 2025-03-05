using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class HomeModel
    {
        public List<MasterServices>? MasterServices { get; set; }
        public List<MasterMenu>? MasterMenu { get; set; }
        public SystemSetting? SystemSetting { get; set; }
        public MasterOffer? MasterOffer { get; set; }
        public List<MasterWorkingHours>? MasterWorkingHours { get; set; }
        public List<MasterSlider>? MasterSlider { get; set; }
        public List<MasterPartner>? MasterPartner { get; set; }
        public List<MasterFeedBack>? MasterFeedBack { get; set; }
        public List<MasterSocialMedia>? MasterSocialMedia { get; set; }
        public List<MasterItemMenu>? MasterItemMenu { get; set; }
        public List<MasterCategoryMenu>? MasterCategoryMenu { get; set; }
        public TransactionBookTable TransactionBookTable { get; set; }
        public TransactionNewsletter TransactionNewsletter { get; set; }
        public TransactionContactUs TransactionContactUs { get; set; }
        public MasterContactUsInformation MasterContactUsInformation { get; set; }


    }
}
