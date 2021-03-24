using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGunsExample
{
 
    public enum Group
    {
        Short,
        Medium,
        Long
    }
    public class UOM
    {
        public string Caliber;
        public  Group CaliberGroup;
    }
}
