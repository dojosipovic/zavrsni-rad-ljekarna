using BusinessLogicLayer.Exceptions;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PrimkaServices
    {
        public async Task<List<Primka>> GetAll()
        {
            using(var repo = new PrimkaRepository())
            {
                return await Task.Run(() => repo.GetAll().ToList());
            }
        }

        public async Task<bool> Add(Primka primka)
        {
            if (primka.StavkePrimke.Count == 0)
                throw new PrimkaException("Morate imati najmanje jednu stavku u primki!");

            using (var repo = new PrimkaRepository())
            {
                int affectedRows = await Task.Run(() => repo.Add(primka));
                return affectedRows > 0;
            }
        }

        public async Task<List<StavkePrimke>> GetReceiptItems(Primka receipt)
        {
            using(var repo = new PrimkaRepository())
            {
                return await Task.Run(() => repo.GetReceiptItems(receipt.ID).ToList());
            }
        }
    }
}
