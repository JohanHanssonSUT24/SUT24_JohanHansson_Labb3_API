using System.Text.Json.Serialization;

namespace SUT24_JohanHansson_Labb3_API.Models
{
    public class Link//Create Link class
    {
        public int Id { get; set; }//Add properties
        public string Url { get; set; }
        public int PersonInterestId {  get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]//Ignore if value is Null when converting to Json
        public PersonInterest PersonInterest { get; set; }//Property connecting PeronsInterest with Link
    }
}
