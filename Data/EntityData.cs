
using System.ComponentModel.DataAnnotations;

namespace Rakendus.Data
{
    public class EntityData
    {
        [Key] public string ID { get; set; } = Guid.NewGuid().ToString();
    }
}
