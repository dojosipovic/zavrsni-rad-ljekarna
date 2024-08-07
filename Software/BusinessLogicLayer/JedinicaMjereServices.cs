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
        public List<JedinicaMjere> GetAll()
        {
            using(var repo = new JedinicaMjereRepository())
            {
                return repo.GetAll().ToList();
            }
        }
    }
}
