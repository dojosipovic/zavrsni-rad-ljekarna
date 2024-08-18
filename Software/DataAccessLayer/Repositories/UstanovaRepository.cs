using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UstanovaRepository : Repository<Ustanova>
    {
        public UstanovaRepository() : base(new DrugstoreModel())
        {
        }

        public override IQueryable<Ustanova> GetAll()
        {
            return base.GetAll().Include("Lijecnik");
        }
        public override int Update(Ustanova entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
