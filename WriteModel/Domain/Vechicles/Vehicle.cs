using Domain.Enums;

namespace Domain.Vechicles
{
    public abstract class Vehicle
    {
        public string PlateNumber { get; set; }
        public VehicleType Type { get; set; }
    }
}
