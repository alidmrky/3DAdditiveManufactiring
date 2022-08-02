using AdditiveManufactiring.Placement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditiveManufactiring.Placement.Interfaces
{
    public interface IPlacementOnMachine
    {
        CompletedPlacementInfoDto PreparePlacementOnMachine(PreparePlacementDto preparePlacementDto);
    }
}
