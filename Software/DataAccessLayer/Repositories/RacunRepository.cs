using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RacunRepository : Repository<Racun>
    {
        public RacunRepository() : base(new DrugstoreModel())
        {
        }
        public override IQueryable<Racun> GetAll()
        {
            return base.GetAll().Include(r => r.Farmaceut);
        }
        public override int Update(Racun entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public override int Add(Racun entity, bool saveChanges = true)
        {
            using (var model = new DrugstoreModel())
            {
                foreach (var item in entity.StavkeRacuna)
                {
                    model.Artikl.Attach(item.Artikl);
                    item.Artikl.Kolicina -= item.Kolicina;
                }
                model.Racun.Add(entity);

                return saveChanges ? model.SaveChanges() : 0;
            }
        }
    }
}
