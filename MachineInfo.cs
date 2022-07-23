using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdditiveManufactiring
{
    public class MachineInfo
    {
        public int Id { get; set; }
        public decimal Htm { get; set; }
        public decimal Setm { get; set; }
        public MachineLength MachineLength { get; set; }
    }
    public class MachineLength
    {
        public int Length_X { get; set; }
        public int Length_Y { get; set; }
        public int Length_Z { get; set; }
        public decimal Volume { get; set; }
    }
}
