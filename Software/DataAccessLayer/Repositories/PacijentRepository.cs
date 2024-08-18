using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PacijentRepository : Repository<Pacijent>
    {
        public PacijentRepository() : base(new DrugstoreModel())
        {
        }

        public override IQueryable<Pacijent> GetAll()
        {
            return base.GetAll().Include("Recept");
        }
        public override int Update(Pacijent entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
