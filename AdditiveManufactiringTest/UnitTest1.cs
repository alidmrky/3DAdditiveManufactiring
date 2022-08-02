using AdditiveManufactiring.Placement.Implementations;
using AdditiveManufactiring.Placement.Interfaces;
using AdditiveManufactiring.Placement.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdditiveManufactiringTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IPlacementOnMachine _placementOnMachine;

        [TestMethod]
        public void TestMethod1()
        {
            ProductInfo productInfo = new ProductInfo()
            {
                Id = 1,
                ProductLength = new ProductLength()
                {
                    Length_X = 6,
                    Length_Y = 3,
                    Length_Z = 5,
                    Volume = 90        
                },
            };
            MachineInfo machineInfo = new MachineInfo()
            {
                MachineLength = new MachineLength()
                {
                    Length_X = 9,
                    Length_Y = 10,
                    Length_Z = 9
                }
            };
            //var placementDFt = _placementOnMachine.PreparePlacementOnMachine(new PreparePlacementDto()
            //{
            //    ProductInfo = productInfo,
            //    MachineInfo = machineInfo,
            //    LastLimit = new LastProductLimit()
            //    {
            //        LastCoordinate_X = 0, LastCoordinate_Y = 0, LastCoordinate_Z = 6,
            //        Limit_X = 6, Limit_Y = 3, Limit_Z = 8, Total_Volume  = 90M
            //    },
            //    Volume = 0
            //});

            var placement312 = new PlacementOnMachine();
            placement312.PreparePlacementOnMachine(new PreparePlacementDto()
            {
                ProductInfo = productInfo,
                MachineInfo = machineInfo,
                LastLimit = new LastProductLimit()
                {
                    LastCoordinate_X = 0,
                    LastCoordinate_Y = 0,
                    LastCoordinate_Z = 6,
                    Limit_X = 6,
                    Limit_Y = 3,
                    Limit_Z = 8,
                    Total_Volume = 90M
                },
                Volume = 0
            });
            
        }
    }
}
