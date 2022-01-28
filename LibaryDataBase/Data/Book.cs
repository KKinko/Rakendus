namespace LibaryDataBase.Data
{
    public class Book
    {
        public string BookID { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? Field { get; set; }

        public DateTime? PublishDate { get; set; }

        public int? PageCount { get; set; }
        public bool? Status { get; set; }

    }
}
