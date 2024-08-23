using Domian;

namespace FinalProjectAPI.helper
{
    public class FinshedSangan
    {
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Model { get; set; }
        public int? Car { get; set; }
        public int? Year { get; set; }
        public int? EngineType { get; set; }
        public int? Distance { get; set; }
        public string? City { get; set; }
        public long Region { get; set; }
        public double? Totalprice { get; set; }

        public double? Tax { get; set; }
        public List<CarService>? SelectedServices { get; set; }
    }
}
