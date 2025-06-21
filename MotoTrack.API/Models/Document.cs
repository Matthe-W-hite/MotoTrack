using System.Text.Json.Serialization;

namespace MotoTrack.API.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; }

        public int ServiceHistoryId { get; set; }
        public ServiceHistory? ServiceHistory { get; set; }
    }
}
