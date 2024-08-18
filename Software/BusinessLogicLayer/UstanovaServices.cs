using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UstanovaServices
    {
        public async Task<List<Ustanova>> GetAll()
        {
            using(var repo = new UstanovaRepository())
            {
                return await Task.Run(() => repo.GetAll().ToList());
            }
        }
    }
}
