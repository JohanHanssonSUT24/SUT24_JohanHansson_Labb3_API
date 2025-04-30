using System.Text.Json.Serialization;

namespace SUT24_JohanHansson_Labb3_API.Models
{
    public class PersonInterest //Create PersonInterest class
    {
        public int Id { get; set; } //Add properties
        public int PersonId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]//Ignore if value is Null when converting to Json
        public Person? Person { get; set; } //Navigation property
        public int InterestId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Interest? Interest { get; set; } //Navigation property

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Link>? Links { get; set; } //ICollection of links connected to Person and Interest
    }
}
