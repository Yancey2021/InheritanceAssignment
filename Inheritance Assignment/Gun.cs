using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGunsExample
{
    enum Material
    {
        Wood,
        Synthetic
    }
  
    public abstract class Gun
    {
        public int capacity;
        public double barrelLength;
        Material bodyMaterial;
        public UOM myUOM;
    }
}
