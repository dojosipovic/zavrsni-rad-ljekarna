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
    public class DobavljacService
    {
        public async Task<List<Dobavljac>> GetAll()
        {
            using(var repo = new DobavljacRepository())
            {
                return await Task.Run(() => repo.GetAll().ToList());
            }
        }

        public async Task<bool> Remove(Dobavljac dobavljac)
        {
            using(var repo = new DobavljacRepository())
            {
                int affectedRows = await Task.Run(() => repo.Remove(dobavljac));
                return affectedRows > 0;
            }
        }

        public async Task<bool> Add(Dobavljac dobavljac)
        {
            VerifyData(dobavljac);

            using (var repo = new DobavljacRepository())
            {
                int affectedRows = await Task.Run(() => repo.Add(dobavljac));
                return affectedRows > 0;
            }
        }

        private static void VerifyData(Dobavljac dobavljac)
        {
            if (!Regex.IsMatch(dobavljac.OIB, @"^\d{11}$"))
                throw new DobavljacException("OIB mora sadržavati 11 znamenaka!");
            if (dobavljac.Naziv.Length == 0 || dobavljac.Naziv.Length > 45)
                throw new DobavljacException("Naziv mora biti duljine do 45 znakova!");
            if (!Regex.IsMatch(dobavljac.IBAN, @"^[A-Z]{2}\d{19}$"))
                throw new DobavljacException("IBAN se mora sastojati od 2 početna slova i 19 znamenaka!");
            if (!Regex.IsMatch(dobavljac.Email, @"^(?=.{1,50}$)[a-zA-Z0-9._]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                throw new DobavljacException("Email nije ispravan!");
            if (dobavljac.Adresa.Length == 0 || dobavljac.Adresa.Length > 200)
                throw new DobavljacException("Adresa mora biti duga do 200 znakova!");
        }

        public async Task<bool> Update(Dobavljac dobavljac)
        {
            VerifyData(dobavljac);

            using (var repo = new DobavljacRepository())
            {
                int affectedRows = await Task.Run(() => repo.Update(dobavljac));
                return affectedRows > 0;
            }
        }
    }
}
