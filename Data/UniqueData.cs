
using System.ComponentModel.DataAnnotations;

namespace Rakendus.Data
{
    public abstract class UniqueData
    {
        public static string NewID => Guid.NewGuid().ToString();
        protected static byte[] empty => Array.Empty<byte>();
        [Timestamp] public byte[] Token { get; set; } = empty;
        [Key] public string ID { get; set; } = NewID;
    }
}
