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

        public override int Update(JedinicaMjere entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
