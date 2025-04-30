namespace SUT24_JohanHansson_Labb3_API.Models.DTOs
{
    public record CreateLinkRequest
    {
        public string Url { get; init; }
        public int PersonId { get; init; }
        public int InterestId { get; init; }
    }
}
