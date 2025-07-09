namespace APIProjectLayer.Models
{
    public class UpdateTeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string SocialMedia { get; set; }
        public int ServicesId { get; set; }
    }

}
