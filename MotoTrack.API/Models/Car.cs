namespace MotoTrack.API.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string PlateNumber { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<ServiceHistory> ServiceHistories { get; set; } = new();
        public List<Document> Documents { get; set; } = new();
    }
}
