using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public override IQueryable<Artikl> GetAll()
        {
            return base.GetAll().Include("JedinicaMjere");
        }

        public override int Update(Artikl entity, bool saveChanges = true)
        {
            var item = Entities.SingleOrDefault(e => e.ID == entity.ID);
            item.Naziv = entity.Naziv;
            item.Kolicina = entity.Kolicina;
            item.Cijena = entity.Cijena;
            item.JedinicaMjereID = entity.JedinicaMjereID;

            return saveChanges ? SaveChanges() : 0;
        }
    }
}
