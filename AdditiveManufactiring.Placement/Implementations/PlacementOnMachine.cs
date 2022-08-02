using AdditiveManufactiring.Placement.Interfaces;
using AdditiveManufactiring.Placement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditiveManufactiring.Placement.Implementations
{
    public class PlacementOnMachine : IPlacementOnMachine
    {
        public PlacementOnMachine()
        {

        }
        public CompletedPlacementInfoDto CompletedPlacementInfo { get; set; }
        public int PlacementCoordinate_X { get; set; }
        public int PlacementCoordinate_Y { get; set; }
        public int PlacementCoordinate_Z { get; set; }
        public CompletedPlacementInfoDto PreparePlacementOnMachine(PreparePlacementDto preparePlacementDto)
        {
            // Check Machine Volume Validation
            var isVolumeEnough = CheckMachinePlacementVolumeValidation(preparePlacementDto);
            if (!isVolumeEnough)
                return new CompletedPlacementInfoDto() { IsSuccess = false, Value = null };

            var isLengthEnough = CheckMachinePlacementLengthValidation(preparePlacementDto);
            if (!isLengthEnough)
                return new CompletedPlacementInfoDto() { IsSuccess = false, Value = null };

            // DoWork 
            var placementWork = DoWork(preparePlacementDto);
            if (!placementWork.IsSuccess)
                return new CompletedPlacementInfoDto() { IsSuccess = false, Value = null };

            return placementWork;
        }
        /// <summary>
        /// Machine layout is made in this method.If the part settles, return the layout plans of the machine.
        /// If the part does not fit into the machine, this info return.
        /// </summary>
        /// <returns></returns>
        public CompletedPlacementInfoDto DoWork(PreparePlacementDto preparePlacementDto)
        {
            bool completePlacement = false;
            // Define and set limit,product and machine information
            var lastLimit = preparePlacementDto.LastLimit;

            var tempLastLimit = lastLimit;

            var productLength = preparePlacementDto.ProductInfo.ProductLength;

            var machineLength = preparePlacementDto.MachineInfo.MachineLength;

            while (!completePlacement)
            {
                var checkProduct = CheckCoordinateIsPlacement(productLength, tempLastLimit, machineLength);
                if (checkProduct == PlacementType.IsCompleted)
                {
                    return CompletedAndPreparePlacementInfo(tempLastLimit, productLength);
                }
                else if (checkProduct == PlacementType.Error_X)
                {
                    // X-ekseninde hata alırsa x sıfırlanır hem limiti hem koordinatı
                    // Z nin yeni koordinatları z nin limiti olur
                    tempLastLimit.Limit_X = 0;
                    tempLastLimit.LastCoordinate_X = 0;
                    tempLastLimit.LastCoordinate_Z = tempLastLimit.Limit_Z;
                }
                else if (checkProduct == PlacementType.Error_Z)
                {
                    // Z eksenine yerleşmezse bir üst katmana geçilir
                    // Z koordinat ve limtiler sıfırlanır
                    // X koordinat ve limitler sıfırlanır
                    tempLastLimit.Limit_X = 0;
                    tempLastLimit.LastCoordinate_X = 0;

                    tempLastLimit.Limit_Z = 0;
                    tempLastLimit.LastCoordinate_Z = 0;

                    tempLastLimit.LastCoordinate_Y = tempLastLimit.Limit_Y;
                }
                else if (checkProduct == PlacementType.Error_Y)
                {
                    return new CompletedPlacementInfoDto() { IsSuccess = false };
                }
            }

            return new CompletedPlacementInfoDto() { IsSuccess = false };
        }
        /// <summary>
        /// It checks the necessary information for the placement of the part.
        /// The information on which axis it does not settle returns to us.
        /// </summary>
        /// <param name="productLength"></param>
        /// <param name="lastLimit"></param>
        /// <param name="machineLength"></param>
        /// <returns></returns>
        public PlacementType CheckCoordinateIsPlacement(ProductLength productLength, LastProductLimit lastLimit, MachineLength machineLength)
        {
            if (productLength.Length_X + lastLimit.LastCoordinate_X <= machineLength.Length_X)
            {
                PlacementCoordinate_X = productLength.Length_X + lastLimit.LastCoordinate_X;

                if (productLength.Length_Y + lastLimit.LastCoordinate_Y <= machineLength.Length_Y)
                {
                    PlacementCoordinate_Y = lastLimit.LastCoordinate_Y != 0 ? lastLimit.LastCoordinate_Y : 0;

                    if (productLength.Length_Z + lastLimit.LastCoordinate_Z <= machineLength.Length_Z)
                    {
                        PlacementCoordinate_Z = lastLimit.LastCoordinate_Z != 0 ? lastLimit.LastCoordinate_Z : 0;

                        return PlacementType.IsCompleted;
                    }
                    else
                    {
                        return PlacementType.Error_Z;
                    }
                }
                else
                {
                    return PlacementType.Error_Y;
                }
            }
            else
            {
                return PlacementType.Error_X;
            }
        }
        /// <summary>
        /// The first placement validation of the part on the Machine is done here. Volume control is provided.
        /// This method can be removed if it is not wanted to be used.
        /// </summary>
        /// <returns></returns>
        public bool CheckMachinePlacementVolumeValidation(PreparePlacementDto preparePlacementDto)
        {
            decimal productVolume = preparePlacementDto.ProductInfo.ProductLength.Volume;

            decimal currentMachineVolume = preparePlacementDto.LastLimit.Total_Volume;

            decimal maxMachineVolume = preparePlacementDto.MachineInfo.MachineLength.Volume;

            if (maxMachineVolume < productVolume + currentMachineVolume)
                return false;

            return true;
        }
        public bool CheckMachinePlacementLengthValidation(PreparePlacementDto preparePlacementDto)
        {
            var productLength = preparePlacementDto.ProductInfo.ProductLength;

            var machineLength = preparePlacementDto.MachineInfo.MachineLength;

            if (productLength.Length_X > machineLength.Length_X)
                return false;
            if (productLength.Length_Y > machineLength.Length_Y)
                return false;
            if (productLength.Length_Z > machineLength.Length_Z)
                return false;

            return true;
        }
        public CompletedPlacementInfoDto CompletedAndPreparePlacementInfo(LastProductLimit lastProductLimit, ProductLength productLength)
        {
            var newProductLimit = new LastProductLimit();
            newProductLimit.LastCoordinate_X = PlacementCoordinate_X;
            newProductLimit.LastCoordinate_Y = PlacementCoordinate_Y;
            newProductLimit.LastCoordinate_Z = PlacementCoordinate_Z;

            // X eksenine yerleşim yapıldığından bu eksenin yeni limiti eski limitin üzerine eklenmesi gerekiyor
            newProductLimit.Limit_X = PlacementCoordinate_X;
            // Sınır çizgilerinde değişiklik varsa değiştirilecek yoksa aynı kalacak
            newProductLimit.Limit_Y = lastProductLimit.LastCoordinate_Y + productLength.Length_Y <= lastProductLimit.Limit_Y ? lastProductLimit.Limit_Y : lastProductLimit.LastCoordinate_Y + productLength.Length_Y;
            newProductLimit.Limit_Z = lastProductLimit.LastCoordinate_Z + productLength.Length_Z <= lastProductLimit.Limit_Z ? lastProductLimit.Limit_Z : lastProductLimit.LastCoordinate_Z + productLength.Length_Z;

            return new CompletedPlacementInfoDto()
            {
                IsSuccess = true,
                Value = new CompletedPlacementInfoDetail()
                {
                    LastProductLimit = newProductLimit,
                    Coordinate_X = lastProductLimit.LastCoordinate_X,
                    Coordinate_Y = lastProductLimit.LastCoordinate_Y,
                    Coordinate_Z = lastProductLimit.LastCoordinate_Z
                }
            };

        }
    }
}
