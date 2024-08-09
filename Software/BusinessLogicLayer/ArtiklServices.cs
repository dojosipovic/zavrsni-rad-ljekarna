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
    public class ArtiklServices
    {
        public async Task<List<Artikl>> GetAll()
        {
            using(var repo = new ArtiklRepository())
            {
                return await Task.Run(() =>  repo.GetAll().ToList());
            }
        }

        public async Task<bool> Add(Artikl artikl)
        {
            ValidateItem(artikl);

            using (var repo = new ArtiklRepository())
            {
                int affectedRows = await Task.Run(() => repo.Add(artikl));
                return affectedRows > 0;
            }
        }

        private static void ValidateItem(Artikl artikl)
        {
            if (artikl.Naziv.Length == 0 || artikl.Naziv.Length > 45)
                throw new ArtiklException("Naziv mora imati do 45 znakova!");
            if (artikl.Cijena < 0)
                throw new ArtiklException("Cijena ne smije biti negativna!");
            if (artikl.Kolicina < 0)
                throw new ArtiklException("Količina ne smije biti negativna!");
        }

        public async Task<bool> Remove(Artikl artikl)
        {
            using(var repo = new ArtiklRepository())
            {
                int affectedRows = await Task.Run(() => repo.Remove(artikl));
                return affectedRows > 0;
            }
        }

        public async Task<bool> Update(Artikl artikl)
        {
            ValidateItem(artikl);

            using (var repo = new ArtiklRepository())
            {
                int affectedRows = await Task.Run(() => repo.Update(artikl));
                return affectedRows > 0;
            }
        }
    }
}
