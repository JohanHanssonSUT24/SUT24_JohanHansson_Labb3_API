using System.Text.Json.Serialization;

namespace SUT24_JohanHansson_Labb3_API.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int PersonInterestId {  get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PersonInterest PersonInterest { get; set; }
    }
}
