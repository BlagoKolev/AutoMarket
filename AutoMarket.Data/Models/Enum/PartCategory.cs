using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoMarket.Data.Models.Enum
{
    public enum PartCategory
    {
        Engine = 1,
        Transmission = 2,
        [Display(Name = "Filters and oil")] FiltersAndOil = 3,
        Suspension = 4,
        Straps = 5,
        Body = 6,
        Mufflers = 7,
        Consumables = 8,
        Lights = 9,
        [Display(Name = "Fuel system")] FuelSystem = 10,
        [Display(Name = "Electrical system")] ElectricalSystem = 11,
        [Display(Name = "Ignited system")] IgnitedSystem = 12,
        [Display(Name = "Air conditioner system")] AirConditionerSystem = 13,
        [Display(Name = "Steering system")] SteeringSystem = 14,
        [Display(Name = "Cooling system")] CoolingSystem = 15,
        [Display(Name = "Brake system")] BrakeSystem = 16,
    }
}
