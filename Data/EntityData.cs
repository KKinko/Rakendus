
using System.ComponentModel.DataAnnotations;

namespace Rakendus.Data
{
    public class EntityData {
        [Key]
        public string IsbnID { get; set; }
        [Key]
        public string ID { get; set; }
    }
}
