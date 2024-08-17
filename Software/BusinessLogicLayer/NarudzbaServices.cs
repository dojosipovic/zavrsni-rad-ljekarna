using DataAccessLayer;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class NarudzbaServices
    {
        public async Task<List<Narudzba>> GetAll()
        {
            using (var repo = new NarudzbaRepository())
            {
                return await Task.Run(() => repo.GetAll().ToList());
            }
        }

        public async Task<bool> Add(Narudzba narudzba)
        {
            using(var repo = new NarudzbaRepository())
            {
                int affectedRows = await Task.Run(() => repo.Add(narudzba));
                return affectedRows > 0;
            }
        }
    }
}
