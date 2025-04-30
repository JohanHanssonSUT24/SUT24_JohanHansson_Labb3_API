using System.Text.Json.Serialization;

namespace SUT24_JohanHansson_Labb3_API.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<PersonInterest> PersonInterests { get; set; }
    }
}
