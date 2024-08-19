using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PrimkaServices
    {
        public async Task<List<Primka>> GetAll()
        {
            using(var repo = new PrimkaRepository())
            {
                return await Task.Run(() => repo.GetAll().ToList());
            }
        }
    }
}
