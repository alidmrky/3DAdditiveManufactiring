using System;

namespace _3DAdditiveManufactiring
{
    class Program
    {
        static void Main(string[] args)
        {
            PlacementInfo infos = new PlacementInfo();
            infos.MachinePlacements.Add(new MachinePlacement() 
            {
                 MachineInfo = new MachineInfo(),
                 PlacementProductInfos =new System.Collections.Generic.List<ProductInfo>(),
                 LastProductLimit = new LastProductLimit()
            });

            var test = infos;

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
