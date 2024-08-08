using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DobavljacRepository : Repository<Dobavljac>
    {
        public DobavljacRepository() : base(new DrugstoreModel())
        {
        }
        public override int Update(Dobavljac entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
