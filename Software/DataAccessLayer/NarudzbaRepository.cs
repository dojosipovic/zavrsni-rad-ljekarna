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

        public override int Update(Narudzba entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
