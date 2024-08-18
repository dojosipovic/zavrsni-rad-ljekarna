using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ReceptRepository : Repository<Recept>
    {
        public ReceptRepository() : base(new DrugstoreModel())
        {
        }

        public override IQueryable<Recept> GetAll()
        {
            return base.GetAll().Include("Lijecnik").Include("Pacijent");
        }

        public IQueryable<Recept> GetPatientPrescrioptions(int patientId)
        {
            var query = from e in Entities where e.PacijentID == patientId select e;
            return query.Include("Lijecnik");
        }

        public ICollection<StavkeRecepta> GetPrescrioptionItems(int prescriptionId)
        {
            using (var model = new DrugstoreModel())
            {
                var prescription = model.Recept.Include(n => n.StavkeRecepta).First(p => p.ID == prescriptionId);
                foreach (var item in prescription.StavkeRecepta)
                {
                    model.Entry(item).Reference(i => i.Artikl).Load();
                }
                return prescription.StavkeRecepta;
            }
        }

        public override int Update(Recept entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
