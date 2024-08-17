using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NarudzbaRepository : Repository<Narudzba>
    {
        public NarudzbaRepository() : base(new DrugstoreModel())
        {
        }

        public override IQueryable<Narudzba> GetAll()
        {
            return base.GetAll().Include("Dobavljac").Include("Farmaceut").Include("StatusNarudzbe").Include("StavkeNarudzbe");
        }

        public override int Add(Narudzba entity, bool saveChanges = true)
        {
            using(var model = new DrugstoreModel())
            {
                model.Dobavljac.Attach(entity.Dobavljac);
                model.StatusNarudzbe.Attach(entity.StatusNarudzbe);
                foreach (var item in entity.StavkeNarudzbe)
                {
                    model.Artikl.Attach(item.Artikl);
                }
                model.Narudzba.Add(entity);

                return saveChanges ? model.SaveChanges() : 0;
            }
        }

        public ICollection<StavkeNarudzbe> GetOrderItems(int orderId)
        {
            using (var model = new DrugstoreModel())
            {
                var order = model.Narudzba.Include(n => n.StavkeNarudzbe).First(o => o.ID == orderId);
                foreach(var item in order.StavkeNarudzbe)
                {
                    model.Entry(item).Reference(i => i.Artikl).Load();
                }
                return order.StavkeNarudzbe;
            }
        }

        public override int Update(Narudzba entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
