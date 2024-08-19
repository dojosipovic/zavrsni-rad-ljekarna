using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public partial class StavkePrimke
    {
        public override bool Equals(object obj)
        {
            if (obj is StavkePrimke other)
            {
                return ArtiklID == other.ArtiklID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ArtiklID.GetHashCode();
        }
    }
}
