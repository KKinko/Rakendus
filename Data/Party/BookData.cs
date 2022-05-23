
namespace Rakendus.Data.Party
{
    public sealed class BookData : UniqueData
    {
        public string? Isbn { get; set; }
        public string? Title { get; set; }
        public string? Field { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? PageCount { get; set; }
    }
}
