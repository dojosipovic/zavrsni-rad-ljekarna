using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public class StavkeRacunaViewModel
    {
        public Artikl Artikl { get; set; }
        public int Kolicina { get; set; }
        public double Cijena { get; set; }
        public string UkupnaCijena => (Kolicina * Cijena).ToString();
        public StavkeRacuna StavkaRacuna { get; set; }
    }
}
