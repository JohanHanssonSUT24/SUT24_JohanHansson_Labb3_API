using System.Text.Json.Serialization;

namespace SUT24_JohanHansson_Labb3_API.Models
{
    public class Person //Creat Person class
    {
        public int Id { get; set; }//Add propeties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]//Ignore if value is Null when converting to Json
        public ICollection<PersonInterest> PersonInterests { get; set; }//Icollection if PersonInterest that is related to the person class.
    }
}
