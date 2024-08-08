using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class JedinicaMjereRepository : Repository<JedinicaMjere>
    {
        public JedinicaMjereRepository() : base(new DrugstoreModel())
        {
        }

        public JedinicaMjere GetJedinicaMjereByID(string id)
        {
            var query = from e in Entities where e.ID == id select e;
            return query.FirstOrDefault();
        }

        public override int Update(JedinicaMjere entity, bool saveChanges = true)
        {
            var measureUnit = Entities.SingleOrDefault(m => m.ID == entity.ID);
            measureUnit.Naziv = entity.Naziv;

            return saveChanges ? SaveChanges() : 0;
        }
    }
}
