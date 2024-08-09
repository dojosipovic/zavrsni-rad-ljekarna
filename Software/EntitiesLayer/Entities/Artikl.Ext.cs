using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public partial class Artikl
    {
        public override string ToString()
        {
            return Naziv;
        }

        public override bool Equals(object obj)
        {
            if (obj is Narudzba other)
            {
                return ID == other.ID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
