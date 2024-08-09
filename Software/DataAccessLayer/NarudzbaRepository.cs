using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NarudzbaRepository : Repository<Narudzba>
    {
        public NarudzbaRepository() : base(new DrugstoreModel())
        {
        }
        public override int Update(Narudzba entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
