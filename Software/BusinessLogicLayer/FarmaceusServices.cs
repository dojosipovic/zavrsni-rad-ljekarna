using BusinessLogicLayer.Exceptions;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class FarmaceusServices
    {
        public Farmaceut GetFarmaceutByKorime(string korime)
        {
            using(var repo = new FarmaceutRepository())
            {
                return repo.GetAll().ToList().Find(x => x.Korime == korime);
            }
        }

        public async Task<List<Farmaceut>> GetAll()
        {
            using(var repo = new FarmaceutRepository())
            {
                return await Task.Run(() => repo.GetAll().ToList());
            }
        }
    }
}
