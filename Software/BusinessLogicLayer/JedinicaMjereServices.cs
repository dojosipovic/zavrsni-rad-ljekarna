using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class JedinicaMjereServices
    {
        public async Task<List<JedinicaMjere>> GetAll()
        {
            using(var repo = new JedinicaMjereRepository())
            {
                return await Task.Run(() =>  repo.GetAll().ToList());
                //return repo.GetAll().ToList();
            }
        }
    }
}
