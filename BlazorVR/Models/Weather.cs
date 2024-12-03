namespace BlazorVR.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public int No { get; set; }
        public required DateOnly Date { get; set; }
        public required int TemperatureC { get; set; }
        public string? Summary { get; set; }
    }
}
