namespace AdditiveManufactiring.Placement.Shared
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public ProductLength ProductLength { get; set; }
        public ProductPlacement ProductPlacement { get; set; }
    }
    public class ProductLength
    {
        public int Length_X { get; set; }
        public int Length_Y { get; set; }
        public int Length_Z { get; set; }
        public decimal Volume { get; set; }
    }
    public class ProductPlacement
    {
        public int Location_X { get; set; }
        public int Location_Y { get; set; }
        public int Location_Z { get; set; }
        public int MachineId { get; set; }
    }
}
