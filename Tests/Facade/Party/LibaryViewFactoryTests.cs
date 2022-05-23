using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rakendus.Aids;
using Rakendus.Data.Party;
using Rakendus.Domain.Party;
using Rakendus.Facade.Party;

namespace Rakendus.Tests.Facade.Party
{
    [TestClass] public class LibaryViewFactoryTests : ViewFactoryTests<LibaryViewFactory, LibaryView, Libary, LibaryData>
    {
        protected override Libary toObject(LibaryData d) => new(d);
    }
}