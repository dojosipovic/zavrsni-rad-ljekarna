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
            var pharmacist = Entities.First(x => x.ID == entity.ID);
            pharmacist.Ime = entity.Ime;
            pharmacist.Prezime = entity.Prezime;
            pharmacist.Email = entity.Email;
            pharmacist.Adresa = entity.Adresa;
            pharmacist.Lozinka = entity.Lozinka;

            return saveChanges ? SaveChanges() : 0;
        }
    }
}
