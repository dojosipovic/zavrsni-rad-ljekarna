using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class LijecnikRepository : Repository<Lijecnik>
    {
        public LijecnikRepository() : base(new DrugstoreModel())
        {
        }

        public override IQueryable<Lijecnik> GetAll()
        {
            return base.GetAll().Include("Ustanova").Include("Recept");
        }
        public override int Update(Lijecnik entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
