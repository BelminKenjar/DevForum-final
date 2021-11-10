namespace DevForum.Models
{
    public class ProfileDetails
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        public string GithubUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedinUrl { get; set; }


        public int? ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}