using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace MotoTrack.API.Models
{
    public class ServiceHistory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Data jest wymagana.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Opis jest wymagany.")]
        [MaxLength(300, ErrorMessage = "Opis może mieć maksymalnie 300 znaków.")]
        public string Description { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Koszt nie może być ujemny.")]
        public decimal Cost { get; set; }

        public int CarId { get; set; }
        [JsonIgnore]
        public Car? Car { get; set; }
        public List<Document> Documents { get; set; } = new();

    }
}
