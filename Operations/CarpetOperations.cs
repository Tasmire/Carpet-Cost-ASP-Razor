using System.ComponentModel.DataAnnotations;

namespace Carpet_Cost__ASP_Razor_.Operations
{
    public class CarpetOperations
    {

        //calculates room area using the width/length inputs
        public int CalculateArea(int width, int length)
        {
            return width * length;
        }

        //calculates installation fee based on room area and installation cost
        public int CalculateInstallationFee(int area, int installationCost)
        {
            return area * installationCost;
        }

        //calculates underlay fee based on room area and underlay cost
        public int CalculateUnderlayFee(int area, int underlayCost)
        {
            return area * underlayCost;
        }

        //calculates total cost of carpet using all the values calculated above
        public int CalculateTotalCost(int area, int carpetCost, int installationFee, int underlayFee)
        {
            return area * carpetCost + installationFee + underlayFee;
        }
    }
}
