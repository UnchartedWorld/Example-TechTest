using System.Text.Json.Serialization;

namespace MotivWebApp.DTOs
{
    public class UserResponse
    {
        [JsonPropertyName("title")]
        public string NameTitle { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("medium")]
        public string PictureURL { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("date")]
        public string DateOfBirth { get; set; }
    }
}
