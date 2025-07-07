using System.Text.Json.Serialization;

namespace APIProjectLayer.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string SocialMedia { get; set; }
        public int ServicesId { get; set; }

        public Services Services { get; set; }

    }
}
