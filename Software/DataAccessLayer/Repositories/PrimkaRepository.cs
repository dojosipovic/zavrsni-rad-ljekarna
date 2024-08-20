using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PrimkaRepository : Repository<Primka>
    {
        public PrimkaRepository() : base(new DrugstoreModel())
        {
        }
        public override IQueryable<Primka> GetAll()
        {
            return base.GetAll().Include("Dobavljac").Include("Narudzba").Include("Farmaceut").Include("StavkePrimke");
        }
        public override int Update(Primka entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public override int Add(Primka entity, bool saveChanges = true)
        {
            using (var model = new DrugstoreModel())
            {
                foreach (var item in entity.StavkePrimke)
                {
                    model.Artikl.Attach(item.Artikl);
                    item.Artikl.Kolicina += item.Kolicina;
                }
                model.Primka.Add(entity);

                return saveChanges ? model.SaveChanges() : 0;
            }
        }

        public ICollection<StavkePrimke> GetReceiptItems(int receiptId)
        {
            using (var model = new DrugstoreModel())
            {
                var receipt = model.Primka.Include(p => p.StavkePrimke).First(p => p.ID == receiptId);
                foreach (var item in receipt.StavkePrimke)
                {
                    model.Entry(item).Reference(i => i.Artikl).Load();
                }
                return receipt.StavkePrimke;
            }
        }
    }
}
