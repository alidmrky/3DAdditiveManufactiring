using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DAdditiveManufactiring
{
    public class PlacementOnMachine
    {
        /// <summary>
        /// First method called
        /// </summary>
        /// <param name="productInfo">ProductInfo</param>
        /// <param name="machineInfo">MachineInfo</param>
        /// <returns></returns>
        public CompletedPlacementInfoDto PreparePlacementOnMachine(PreparePlacementDto preparePlacementDto)
        {
            // Check Machine Volume Validation
            var isVolumeEnough = CheckMachinePlacementVolumeValidation(preparePlacementDto);
            if (!isVolumeEnough)
                return new CompletedPlacementInfoDto() { IsSuccess = false, Value = null };

            // DoWork 
            var placementWork = DoWork(preparePlacementDto);

            return new CompletedPlacementInfoDto() { IsSuccess = true, Value = null };
        }
        /// <summary>
        /// Machine layout is made in this method.If the part settles, return the layout plans of the machine.
        /// If the part does not fit into the machine, this info return.
        /// </summary>
        /// <returns></returns>
        public string DoWork(PreparePlacementDto preparePlacementDto)
        {
            // Define and set limit,product and machine information
            var lastLimit = preparePlacementDto.LastLimit;

            var productLength = preparePlacementDto.ProductInfo.ProductLength;

            var machineLength = preparePlacementDto.MachineInfo.MachineLength;

            var checkProduct = CheckCoordinateIsPlacement(productLength, lastLimit, machineLength);
            if (checkProduct == "IsCompleted")
                return "parça yerleşti";
            else if (checkProduct == "IsError_Z")
                return "Z ekseninde hata";
            else if (checkProduct == "IsError_Y")
                return "Y ekseninde hata";
            return "";
        }
        /// <summary>
        /// It checks the necessary information for the placement of the part.
        /// The information on which axis it does not settle returns to us.
        /// </summary>
        /// <param name="productLength"></param>
        /// <param name="lastLimit"></param>
        /// <param name="machineLength"></param>
        /// <returns></returns>
        public string CheckCoordinateIsPlacement(ProductLength productLength, LastProductLimit lastLimit, MachineLength machineLength)
        {
            if (productLength.Length_X + lastLimit.Limit_X <= machineLength.Length_X)
            {
                if (productLength.Length_Y + lastLimit.Limit_Y <= machineLength.Length_Y)
                {
                    if (productLength.Length_Z + lastLimit.Limit_Z <= machineLength.Length_Z)
                    {
                        return "IsCompleted";
                    }
                    else
                    {
                        return "IsError_Z";
                    }                    
                }
                else
                {
                    return "IsError_Y";
                }
            }
            else
            {
                return "IsError_X";
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

            if(maxMachineVolume < productVolume + currentMachineVolume)
                 return false;

            return true;
        }
        public bool CheckMachinePlacementLengthValidation(PreparePlacementDto preparePlacementDto)
        {
            return true;
        }

    }
}
