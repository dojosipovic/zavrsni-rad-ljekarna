using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class LijecnikServices
    {
        public async Task<List<Lijecnik>> GetAll()
        {
            using(var repo = new LijecnikRepository())
            {
                return await Task.Run(() => repo.GetAll().ToList());
            }
        }
    }
}
