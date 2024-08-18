using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ReceptServices
    {
        public async Task<List<Recept>> GetPatientPrescrioptions(Pacijent pacijent)
        {
            using(var repo = new ReceptRepository())
            {
                return await Task.Run(() => repo.GetPatientPrescrioptions(pacijent.ID).ToList());
            }
        }

        public async Task<List<StavkeRecepta>> GetPrescrioptionItems(Recept recept)
        {
            using(var repo = new ReceptRepository())
            {
                return await Task.Run(() => repo.GetPrescrioptionItems(recept.ID).ToList());
            }
        }
    }
}
