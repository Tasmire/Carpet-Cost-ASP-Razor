using System.ComponentModel.DataAnnotations;

namespace Carpet_Cost__ASP_Razor_.Model
{

    public class CarpetChoice
    {
        //value types for carpet choice
        public int CarpetCost { get; set; }
        public string CarpetType { get; set; }
    }
    public class Carpet
    {
        public int CarpetCost { get; set; }
        public string CarpetType { get; set; }

        [Display(Name = "Select a Carpet Type")]
        public string CarpetChoice { get; set; }

        //creates a choice list for carpet cost and type
        public List<CarpetChoice> CarpetChoiceList { get; set; }

        public Carpet()
        {
            //adds all three carpet types
            CarpetChoiceList = new List<CarpetChoice>
            {
                new CarpetChoice { CarpetCost = 100, CarpetType = "Cheap" },
                new CarpetChoice { CarpetCost = 200, CarpetType = "Home" },
                new CarpetChoice { CarpetCost = 300, CarpetType = "Luxurious" }
            };
        }

        //cost: price per meters squared, fee: total cost for the customer
        public int InstallationCost { get; set; }
        public int InstallationFee { get; set; }
        public int UnderlayCost { get; set; }
        public int UnderlayFee { get; set; }


        //input values for front end form
        [Display(Name = "Enter the Room Width (m)")]
        public int RoomWidth { get; set; }
        [Display(Name = "Enter the Room Length (m)")]
        public int RoomLength { get; set; }
        public int RoomArea { get; set; }

        //checkbox values for front end form
        [Display(Name = "Do you need professional carpet installation?")]
        public bool Installation { get; set; }
        [Display(Name = "Do you want underlay for your carpet?")]
        public bool Underlay { get; set; }

        //values for total carpet cost
        public int TotalCost { get; set; }

        public string Result { get; set; }
    }
}
