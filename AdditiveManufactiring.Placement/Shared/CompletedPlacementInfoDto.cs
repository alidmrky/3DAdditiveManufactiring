namespace AdditiveManufactiring.Placement.Shared
{
    public class CompletedPlacementInfoDto
    {
        public bool IsSuccess { get; set; }
        public CompletedPlacementInfoDetail Value { get; set; }
    }
    public class CompletedPlacementInfoDetail
    {
        public LastProductLimit LastProductLimit { get; set; }
        public int Coordinate_X { get; set; }
        public int Coordinate_Y { get; set; }
        public int Coordinate_Z { get; set; }

    }
}
