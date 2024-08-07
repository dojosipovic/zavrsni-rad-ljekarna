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
        public List<Artikl> GetItems()
        {
            using(var repo = new ArtiklRepository())
            {
                return repo.GetAll().ToList();
            }
        }
    }
}
