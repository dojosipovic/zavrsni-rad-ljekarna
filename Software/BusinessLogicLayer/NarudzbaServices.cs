using BusinessLogicLayer.Exceptions;
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
            if (narudzba.StavkeNarudzbe.Count == 0)
                throw new NarudzbaException("Morate imati najmanje jednu stavku u narudžbi!");

            using(var repo = new NarudzbaRepository())
            {
                int affectedRows = await Task.Run(() => repo.Add(narudzba));
                return affectedRows > 0;
            }
        }

        public async Task<List<StavkeNarudzbe>> GetOrderItems(Narudzba narudzba)
        {
            using(var repo = new NarudzbaRepository())
            {
                return await Task.Run(() => repo.GetOrderItems(narudzba.ID).ToList());
            }
        }

        public async Task<bool> Update(Narudzba order)
        {
            if (order.StavkeNarudzbe.Count == 0)
                throw new NarudzbaException("Morate imati najmanje jednu stavku u narudžbi!");

            using (var repo = new NarudzbaRepository())
            {
                int affectedRows = await Task.Run(() => repo.Update(order));
                return affectedRows > 0;
            }
        }

        public async Task<bool> Remove(Narudzba order)
        {
            if (order.Status == StatusNarudzbeEnum.Zakljucena)
                throw new NarudzbaException("Ne možete obrisati zaključenu narudžbu!");

            using(var repo = new NarudzbaRepository())
            {
                int affectedRows = await Task.Run(() => repo.Remove(order));
                return affectedRows > 0;
            }
        }
    }
}
