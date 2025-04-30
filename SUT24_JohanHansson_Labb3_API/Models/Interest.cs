using System.Text.Json.Serialization;

namespace SUT24_JohanHansson_Labb3_API.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<PersonInterest> PersonInterests { get; set; }
    }
}
