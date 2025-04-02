using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Carpet_Cost__ASP_Razor_.Operations;
using Carpet_Cost__ASP_Razor_.Model;

namespace Carpet_Cost__ASP_Razor_.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        //allows Model and Operation classes to be used
        public Carpet carpet { get; set; } = new Carpet();
        public CarpetOperations carpetOperations { get; set; } = new CarpetOperations();
        public CarpetChoice carpetChoice { get; set; } = new CarpetChoice();

        public void OnGet()
        {
            //displays on startup, when no values are entered
            carpet.Result = $"Enter your purchase details to view the total cost.";
        }

        public void OnPost()
        {
            //sets cost per meter squared for each optional add-on
            carpet.InstallationCost = 20;
            carpet.UnderlayCost = 20;

            //calculates room area
            carpet.RoomArea = carpetOperations.CalculateArea(carpet.RoomWidth, carpet.RoomLength);

            //calculates installation fee if the option is selected
            if (carpet.Installation == true)
            {
                carpet.InstallationFee = carpetOperations.CalculateInstallationFee(carpet.RoomArea, carpet.InstallationCost);
            } else { carpet.InstallationFee = 0; }

            //calculates underlay fee if the option is selected
            if (carpet.Underlay == true)
            {
                carpet.UnderlayFee = carpetOperations.CalculateUnderlayFee(carpet.RoomArea, carpet.UnderlayCost);
            }
            else { carpet.UnderlayFee = 0; }
            
            //grabs the cost and type of the selected carpet from the carpet list
            var selectedCarpet = carpet.CarpetChoiceList.FirstOrDefault(x => x.CarpetType == carpet.CarpetChoice);
            carpet.CarpetCost = selectedCarpet.CarpetCost;
            carpet.CarpetType = selectedCarpet.CarpetType;

            //calculates the total cost of the carpet purchase
            carpet.TotalCost = carpetOperations.CalculateTotalCost(carpet.RoomArea, carpet.CarpetCost, carpet.InstallationFee, carpet.UnderlayFee);

            //sets the result to be displayed on the front end, including the added fees
            carpet.Result = $"Room Area: {carpet.RoomArea} meters squared <br /> Final Cost: ${carpet.TotalCost} <br /> This includes a ${carpet.InstallationFee} installation fee and ${carpet.UnderlayFee} for carpet underlay.";
        }
    }
}
