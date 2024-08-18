using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ReceptRepository : Repository<Recept>
    {
        public ReceptRepository() : base(new DrugstoreModel())
        {
        }

        public IQueryable<Recept> GetPatientPrescrioptions(Pacijent pacijent)
        {
            var query = from e in Entities where e.PacijentID == pacijent.ID select e;
            return query.Include("Lijecnik");
        }
        public override int Update(Recept entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
