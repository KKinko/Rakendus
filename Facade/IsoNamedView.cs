using System.ComponentModel;

namespace Rakendus.Facade
{
    public abstract class IsoNamedView : NamedView
    {
        [DisplayName("ISO Three-Letter Code")] public new string? Code { get; set; }
        [DisplayName("English Name")] public new string? Name { get; set; }
        [DisplayName("Native name")] public new string? Description { get; set; }
    }
}
