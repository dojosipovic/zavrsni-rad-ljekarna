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
    public class JedinicaMjereServices
    {
        public async Task<JedinicaMjere> GetJedinicaMjereByID(string id)
        {
            using(var repo = new JedinicaMjereRepository())
            {
                return await Task.Run(() => repo.GetJedinicaMjereByID(id));
            }
        }

        public async Task<List<JedinicaMjere>> GetAll()
        {
            using(var repo = new JedinicaMjereRepository())
            {
                return await Task.Run(() =>  repo.GetAll().ToList());
                //return repo.GetAll().ToList();
            }
        }

        public async Task<bool> Add(JedinicaMjere measureUnit)
        {
            if (measureUnit.ID.Length == 0 || measureUnit.ID.Length > 3)
                throw new JedinicaMjereException("Duljina ID-a ne smije biti prazna ni veća od 3 znaka!");
            if (measureUnit.Naziv.Length == 0 || measureUnit.Naziv.Length > 10)
                throw new JedinicaMjereException("Naziv ne smije biti prazan ni veći od 10 znakova!");
            using (var repo = new JedinicaMjereRepository())
            {
                int affectedRows = await Task.Run(() => repo.Add(measureUnit));
                return affectedRows > 0;
            }
        }

        public async Task<bool> Update(JedinicaMjere measureUnit)
        {
            if (measureUnit.Naziv.Length == 0 || measureUnit.Naziv.Length > 10)
                throw new JedinicaMjereException("Naziv ne smije biti prazan ni veći od 10 znakova!");
            using (var repo = new JedinicaMjereRepository())
            {
                int affectedRows = await Task.Run(() => repo.Update(measureUnit));
                return affectedRows > 0;
            }
        }

        public async Task<bool> Remove(JedinicaMjere measureUnit)
        {
            using (var repo = new JedinicaMjereRepository())
            {
                int affectedRows = await Task.Run(() => repo.Remove(measureUnit));
                return affectedRows > 0;
            }
        }
    }
}
