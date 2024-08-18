using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PacijentServices
    {
        public async Task<List<Pacijent>> GetAll()
        {
            using(var repo = new PacijentRepository())
            {
                return await Task.Run(() => repo.GetAll().ToList());
            }
        }
    }
}
