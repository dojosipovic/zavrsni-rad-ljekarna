using BusinessLogicLayer.Exceptions;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class FarmaceusServices
    {
        public Farmaceut GetFarmaceutByKorime(string korime)
        {
            using(var repo = new FarmaceutRepository())
            {
                return repo.GetAll().ToList().Find(x => x.Korime == korime);
            }
        }

        public async Task<List<Farmaceut>> GetAll()
        {
            using(var repo = new FarmaceutRepository())
            {
                return await Task.Run(() => repo.GetAll().ToList());
            }
        }

        public async Task<bool> Update(Farmaceut farmaceut)
        {
            if (farmaceut.Ime.Length > 20 || farmaceut.Ime.Length == 0)
                throw new FarmaceutException("Ime ne smije biti prazno niti dulje od 20 znakova");
            if (farmaceut.Prezime.Length > 30 || farmaceut.Prezime.Length == 0)
                throw new FarmaceutException("Prezime ne smije biti prazno niti dulje od 30 znakova");
            if (farmaceut.Adresa.Length > 200 || farmaceut.Adresa.Length == 0)
                throw new FarmaceutException("Adresa ne smije biti prazna niti dulja od 200 znakova");
            if (!Regex.IsMatch(farmaceut.Email, @"^(?=.{1,50}$)[a-zA-Z0-9._]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                throw new FarmaceutException("Email nije ispravan!");
            if (farmaceut.Lozinka.Length < 6 || farmaceut.Lozinka.Length > 50)
                throw new FarmaceutException("Lozinka ne smije biti kraća od 6 ni dolja od 50 znakova");
            if (!Regex.IsMatch(farmaceut.Lozinka, @"^[a-zA-Z0-9!@#$%^&?_*]{6,50}$"))
                throw new FarmaceutException("Lozinka smije sadržavati samo slova, brojeve i !@#$%^&?_*");

            using (var repo = new FarmaceutRepository())
            {
                int affectedRows = await Task.Run(() => repo.Update(farmaceut));
                return affectedRows > 0;
            }
        }
    }
}
