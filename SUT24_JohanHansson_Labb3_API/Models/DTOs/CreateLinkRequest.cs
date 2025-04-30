namespace SUT24_JohanHansson_Labb3_API.Models.DTOs
{
    public record CreateLinkRequest//DTO using record for Immutability due not to change the values.
    {
        public string Url { get; init; }
        public int PersonId { get; init; }
        public int InterestId { get; init; }
    }
}
