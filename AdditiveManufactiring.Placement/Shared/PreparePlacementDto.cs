namespace AdditiveManufactiring.Placement.Shared
{
    public class PreparePlacementDto
    {
        public MachineInfo MachineInfo { get; set; }
        public ProductInfo ProductInfo { get; set; }
        public LastProductLimit LastLimit { get; set; }
        public decimal Volume { get; set; }
    }
}
