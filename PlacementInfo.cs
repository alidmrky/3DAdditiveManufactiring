using System.Collections.Generic;

namespace _3DAdditiveManufactiring
{
    public class PlacementInfo
    {
        public bool IsSuccess { get; set; }
        public List<MachinePlacement> MachinePlacements { get; set; } = new List<MachinePlacement>();
    }
    public class MachinePlacement
    {
        public MachineInfo MachineInfo { get; set; }
        public List<ProductInfo> PlacementProductInfos { get; set; } = new List<ProductInfo>();
        public LastProductLimit LastProductLimit { get; set; }
    }
}
