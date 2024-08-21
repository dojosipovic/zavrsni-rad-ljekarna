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
            return base.GetAll().Include(r => r.Farmaceut).Include(r => r.StavkeRacuna);
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

        public ICollection<StavkeRacuna> GetInvoiceItems(int invoiceId)
        {
            using (var model = new DrugstoreModel())
            {
                var invoice = model.Racun.Include(n => n.StavkeRacuna).First(o => o.ID == invoiceId);
                foreach (var item in invoice.StavkeRacuna)
                {
                    model.Entry(item).Reference(i => i.Artikl).Load();
                }
                return invoice.StavkeRacuna;
            }
        }
    }
}
