using System.ComponentModel.DataAnnotations;

namespace Rakendus.Facade
{
    public abstract class BaseView
    {
        [Required] public string ID { get; set; } = Guid.NewGuid().ToString();
    }
}
