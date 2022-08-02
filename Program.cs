using System;

namespace _3DAdditiveManufactiring
{
    class Program
    {
        static void Main(string[] args)
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
            //PlacementInfo infos = new PlacementInfo();
            //infos.MachinePlacements.Add(new MachinePlacement() 
            //{
            //     MachineInfo = new MachineInfo(),
            //     PlacementProductInfos =new System.Collections.Generic.List<ProductInfo>(),
            //     LastProductLimit = new LastProductLimit()
            //});

            //var test = infos;

            PlacementOnMachine placement = new PlacementOnMachine();
            var test = placement.PreparePlacementOnMachine(new PreparePlacementDto()
            {
                ProductInfo = productInfo,
                MachineInfo = machineInfo,
                LastLimit = new LastProductLimit()
                {
                    LastCoordinate_X = 0, LastCoordinate_Y = 0, LastCoordinate_Z = 6,
                    Limit_X = 6, Limit_Y = 3, Limit_Z = 8, Total_Volume  = 90M
                }
            });

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
        
    }
}
