namespace WebApplication2.CQRS.DTO
{
    public class GroupAllDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int StudentCount { get; set; }
        public int? IdSpecial { get; set; }
        public required string TitleSpecial { get; set; }
    }
}
