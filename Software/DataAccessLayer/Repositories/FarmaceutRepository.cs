using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class FarmaceutRepository : Repository<Farmaceut>
    {
        public FarmaceutRepository() : base(new DrugstoreModel())
        {
        }

        public override int Update(Farmaceut entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
