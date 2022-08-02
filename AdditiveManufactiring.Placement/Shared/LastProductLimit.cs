
using System.ComponentModel;

namespace AdditiveManufactiring.Placement.Shared
{
    public class LastProductLimit
    {
        [DefaultValue(0)]
        public int Limit_X { get; set; }
        [DefaultValue(0)]
        public int Limit_Y { get; set; }
        [DefaultValue(0)]
        public int Limit_Z { get; set; }
        [DefaultValue(0)]
        public int LastCoordinate_X { get; set; }
        [DefaultValue(0)]
        public int LastCoordinate_Y { get; set; }
        [DefaultValue(0)]
        public int LastCoordinate_Z { get; set; }
        [DefaultValue(0)]
        public decimal Total_Volume { get; set; }
    }
}
