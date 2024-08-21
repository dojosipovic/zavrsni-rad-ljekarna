using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public class RacunViewModel
    {
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public Farmaceut Farmaceut { get; set; }
        public string UkupnaVrijednost { get; set; }
        public Racun Racun { get; set; }
    }
}
