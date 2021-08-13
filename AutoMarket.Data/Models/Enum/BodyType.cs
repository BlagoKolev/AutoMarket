using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Data.Models.Enum
{
    public enum BodyType
    {
        Van = 1,
        SUV = 2,
        Cabrio = 3,
        Wagon = 4,
        Coupe = 5,
        Minivan = 6,
        [Display(Name = "Pickup truck")] [Description("Pickup truck")] PickupTruck = 7,
        Sedan = 8,
        Limousine = 9,
        Hatchback = 10
    }
}
