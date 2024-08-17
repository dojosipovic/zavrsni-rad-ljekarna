using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class StatusServices
    {
        public async Task<List<StatusNarudzbe>> GetAll()
        {
            using (var repo = new StatusRepository())
            {
                return await Task.Run(() => repo.GetAll().ToList());
            }
        }
    }
}
