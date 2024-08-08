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
                var farmaceut = repo.GetAll().ToList().Find(x => x.Korime == korime);
                return farmaceut;
            }
        }
    }
}
