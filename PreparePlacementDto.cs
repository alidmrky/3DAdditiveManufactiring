using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdditiveManufactiring
{
    public class PreparePlacementDto
    {
        public MachineInfo MachineInfo { get; set; }
        public ProductInfo ProductInfo { get; set; }
        public LastProductLimit LastLimit { get; set; }
        public decimal Volume { get; set; }
    }
}
