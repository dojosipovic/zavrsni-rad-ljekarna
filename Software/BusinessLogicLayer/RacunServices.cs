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
    public class RacunServices
    {
        public async Task<List<Racun>> GetALl()
        {
            using(var repo = new RacunRepository())
            {
                return await Task.Run(() => repo.GetAll().ToList());
            }
        }

        public async Task<bool> Add(Racun racun)
        {
            if (racun.StavkeRacuna.Count == 0)
                throw new RacunException("Morate imati najmanje jednu stavku u računu!");

            foreach(var item in racun.StavkeRacuna)
            {
                int amount = item.Artikl.Kolicina - item.Kolicina;
                if (amount < 0)
                    throw new RacunException($"Nedostaju vam {Math.Abs(amount)} {item.Artikl}!");
            }

            using (var repo = new RacunRepository())
            {
                int affectedRows = await Task.Run(() => repo.Add(racun));
                return affectedRows > 0;
            }
        }

        public async Task<List<StavkeRacuna>> GetInvoiceItems(Racun racun)
        {
            using(var repo = new RacunRepository())
            {
                return await Task.Run(() => repo.GetInvoiceItems(racun.ID).ToList());
            }
        }
    }
}
