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
            return base.GetAll().Include("Dobavljac").Include("Farmaceut").Include("StatusNarudzbe");
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

        public override int Update(Narudzba entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
