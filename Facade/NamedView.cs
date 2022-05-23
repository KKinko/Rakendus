using System.ComponentModel;

namespace Rakendus.Facade
{
    public abstract class NamedView : UniqueView
    {
        [DisplayName("Code")] public string? Code { get; set; }
        [DisplayName("Name")] public string? Name { get; set; }
        [DisplayName("Description")] public string? Description { get; set; }
    }
}
