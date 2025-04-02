using System.ComponentModel.DataAnnotations;

namespace Carpet_Cost__ASP_Razor_.Operations
{
    public class CarpetOperations
    {

        public int CalculateArea(int width, int length)
        {
            return width * length;
        }

        public int CalculateInstallationCost(int area, int installationCost)
        {
            return area * installationCost;
        }

        public int CalculateUnderlayCost(int area, int underlayCost)
        {
            return area * underlayCost;
        }

        public int CalculateTotalCost(int area, int carpetCost, int installationCost, int underlayCost)
        {
            return area * carpetCost + installationCost + underlayCost;
        }
    }
}
