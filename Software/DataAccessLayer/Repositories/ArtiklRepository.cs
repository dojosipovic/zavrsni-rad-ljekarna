using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ArtiklRepository : Repository<Artikl>
    {
        public ArtiklRepository() : base(new DrugstoreModel())
        {
        }

        public override int Update(Artikl entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
