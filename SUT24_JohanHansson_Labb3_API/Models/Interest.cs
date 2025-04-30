using System.Text.Json.Serialization;

namespace SUT24_JohanHansson_Labb3_API.Models
{
    public class Interest//Interest class
    {
        public int Id { get; set; }//Add properties
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]//Ignore if value is Null when converting to Json
        public ICollection<PersonInterest> PersonInterests { get; set; }//Icollection if PersonInterest that is related to the interest class.
    }
}
