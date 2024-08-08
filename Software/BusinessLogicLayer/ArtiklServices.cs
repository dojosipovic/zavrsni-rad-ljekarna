using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ArtiklServices
    {
        public async Task<List<Artikl>> GetAll()
        {
            using(var repo = new ArtiklRepository())
            {
                return await Task.Run(() =>  repo.GetAll().ToList());
                //return repo.GetAll().ToList();
            }
        }
    }
}
