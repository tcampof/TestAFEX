using System.ComponentModel.DataAnnotations;

namespace Videos.Models
{
    public class Video
    {
        [Key]
        public int? id_videos { get; set; }
        [Required]
        public string kind { get; set; }
        [Required]
        public string etag { get; set; }
        [Required]
        public string id { get; set; }
        public string url { get; set; }

    }
}
