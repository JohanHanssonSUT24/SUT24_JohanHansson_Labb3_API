using System.Text.Json.Serialization;

namespace SUT24_JohanHansson_Labb3_API.Models
{
    public class PersonInterest
    {
        public int Id { get; set; }
        public int PersonId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Person? Person { get; set; }
        public int InterestId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Interest? Interest { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Link>? Links { get; set; }
    }
}
