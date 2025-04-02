using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Carpet_Cost__ASP_Razor_.Operations;
using Carpet_Cost__ASP_Razor_.Model;

namespace Carpet_Cost__ASP_Razor_.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public Carpet carpet { get; set; } = new Carpet();
        public CarpetOperations carpetOperations { get; set; } = new CarpetOperations();
        public CarpetChoice carpetChoice { get; set; } = new CarpetChoice();

        public void OnGet()
        {
            carpet.Result = $"Enter your purchase details to view the total cost.";
        }

        public void OnPost()
        {
            carpet.InstallationCost = 20;
            carpet.UnderlayCost = 20;

            carpet.RoomArea = carpetOperations.CalculateArea(carpet.RoomWidth, carpet.RoomLength);
            if (carpet.Installation == true)
            {
                carpet.InstallationFee = carpetOperations.CalculateInstallationCost(carpet.RoomArea, carpet.InstallationCost);
            } else { carpet.InstallationFee = 0; }

            if (carpet.Underlay == true)
            {
                carpet.UnderlayFee = carpetOperations.CalculateUnderlayCost(carpet.RoomArea, carpet.UnderlayCost);
            }
            else { carpet.UnderlayFee = 0; }

            var selectedCarpet = carpet.CarpetChoiceList.FirstOrDefault(c => c.CarpetType == carpet.CarpetChoice);
            carpet.CarpetCost = selectedCarpet.CarpetCost;
            carpet.CarpetType = selectedCarpet.CarpetType;

            carpet.TotalCost = carpetOperations.CalculateTotalCost(carpet.RoomArea, carpet.CarpetCost, carpet.InstallationFee, carpet.UnderlayFee);

            carpet.Result = $"Room Area: {carpet.RoomArea} meters squared <br /> Final Cost: ${carpet.TotalCost} <br /> This includes a ${carpet.InstallationFee} installation fee and ${carpet.UnderlayFee} for carpet underlay.";

            Console.WriteLine(carpet.CarpetType);
            Console.WriteLine(carpet.CarpetCost);
        }
    }
}
