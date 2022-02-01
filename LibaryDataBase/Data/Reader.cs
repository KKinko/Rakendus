using System.ComponentModel.DataAnnotations;

namespace LibaryDataBase.Data
{
    public class Reader
    {
        [Key]
        public  string ID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool? Gender { get; set; }

        public DateTime? DoB { get; set; }

        public int? Telefon { get; set; }
        public string? City { get; set; }
        public string? HomeAddress { get; set; }
        public string? Education { get; set; }
        public string? EmailAddress { get; set; }


    }
}
