using System.ComponentModel.DataAnnotations;

namespace Rakendus.Facade
{
    public abstract class UniqueView
    {
        [Required] public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required] public byte[] Token { get; set; } = Array.Empty<byte>();
    }
}
