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
            var supplier = Entities.SingleOrDefault(s => s.ID == entity.ID);

            supplier.IBAN = entity.IBAN;
            supplier.Naziv = entity.Naziv;
            supplier.OIB = entity.OIB;
            supplier.Adresa = entity.Adresa;
            supplier.Email = entity.Email;

            return saveChanges ? SaveChanges() : 0;
        }
    }
}
