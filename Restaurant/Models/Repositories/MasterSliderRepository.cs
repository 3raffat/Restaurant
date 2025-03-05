using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterSliderRepository : IRepository<MasterSlider>
    {
        public AppDbContext DB { get; }

        public MasterSliderRepository(AppDbContext _DB)
        {
            DB = _DB;
        }


        public void Active(int Id)
        {
            var data = Find(Id);
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            DB.Update(data);
            DB.SaveChanges();
        }

        public void Add(MasterSlider entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.EditDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            DB.MasterSliders.Add(entity);
            DB.SaveChanges();

        }

        public void Delete(int Id, MasterSlider entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            DB.MasterSliders.Update(data);
            DB.SaveChanges();
        }

        public MasterSlider Find(int Id)
        {
            return DB.MasterSliders.SingleOrDefault(x => x.MasterSliderId == Id);
        }

        public void Update(int Id, MasterSlider entity)
        {
            var data = Find(Id);
            data.MasterSliderTitle = entity.MasterSliderTitle;
            data.MasterSliderDesc = entity.MasterSliderDesc;
            data.MasterSliderBreef = entity.MasterSliderBreef;
            data.MasterSliderUrl = entity.MasterSliderUrl;

            DB.MasterSliders.Update(data);
            DB.SaveChanges();
        }

        public List<MasterSlider> View()
        {
            return DB.MasterSliders.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSlider> ViewClient()
        {
            return DB.MasterSliders.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
