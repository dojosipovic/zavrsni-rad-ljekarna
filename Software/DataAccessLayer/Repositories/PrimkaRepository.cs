using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PrimkaRepository : Repository<Primka>
    {
        public PrimkaRepository() : base(new DrugstoreModel())
        {
        }
        public override IQueryable<Primka> GetAll()
        {
            return base.GetAll().Include("Dobavljac").Include("Narudzba").Include("Farmaceut");
        }
        public override int Update(Primka entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
