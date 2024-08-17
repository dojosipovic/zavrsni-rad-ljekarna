using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class StatusRepository : Repository<StatusNarudzbe>
    {
        public StatusRepository() : base (new DrugstoreModel())
        {
        }
        public override int Update(StatusNarudzbe entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
