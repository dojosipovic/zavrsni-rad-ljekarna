using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public override IQueryable<Narudzba> GetAll()
        {
            return base.GetAll().Include("Dobavljac").Include("Farmaceut").Include("StatusNarudzbe").Include("StavkeNarudzbe");
        }

        public override int Add(Narudzba entity, bool saveChanges = true)
        {
            using(var model = new DrugstoreModel())
            {
                foreach (var item in entity.StavkeNarudzbe)
                {
                    model.Artikl.Attach(item.Artikl);
                }
                model.Narudzba.Add(entity);

                return saveChanges ? model.SaveChanges() : 0;
            }
        }

        public ICollection<StavkeNarudzbe> GetOrderItems(int orderId)
        {
            using (var model = new DrugstoreModel())
            {
                var order = model.Narudzba.Include(n => n.StavkeNarudzbe).First(o => o.ID == orderId);
                foreach(var item in order.StavkeNarudzbe)
                {
                    model.Entry(item).Reference(i => i.Artikl).Load();
                }
                return order.StavkeNarudzbe;
            }
        }

        public override int Update(Narudzba entity, bool saveChanges = true)
        {
            using (var model = new DrugstoreModel())
            {
                var existingOrder = model.Narudzba.Include(o => o.StavkeNarudzbe).FirstOrDefault(o => o.ID == entity.ID);

                if (existingOrder == null) throw new Exception("Narudžba nije pronađena!");

                model.Entry(existingOrder).CurrentValues.SetValues(entity);

                var itemsToRemove = existingOrder.StavkeNarudzbe
                    .Where(existingItem => !entity.StavkeNarudzbe.Any(newItem => newItem.ArtiklID == existingItem.ArtiklID && newItem.NarudzbaID == existingItem.NarudzbaID))
                    .ToList();

                foreach (var item in itemsToRemove) model.StavkeNarudzbe.Remove(item);

                foreach (var orderItem in entity.StavkeNarudzbe)
                {
                    var existingItem = existingOrder.StavkeNarudzbe
                        .SingleOrDefault(item => item.ArtiklID == orderItem.ArtiklID && item.NarudzbaID == orderItem.NarudzbaID);

                    if (existingItem != null) model.Entry(existingItem).CurrentValues.SetValues(orderItem);
                    else
                    {
                        existingOrder.StavkeNarudzbe.Add(new StavkeNarudzbe
                        {
                            ArtiklID = orderItem.ArtiklID,
                            NarudzbaID = entity.ID,
                            Kolicina = orderItem.Kolicina,
                        });
                    }
                }

                return saveChanges ? model.SaveChanges() : 0;
            }
        }

    }
}
