using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Rakendus.Tests
{
    public abstract class AssertTests
    {
        protected static void inconclusive() => Assert.Inconclusive();
        protected static void IsNotNull([NotNull] object? o = null) => Assert.IsNotNull(o);
        protected static void areEqual(object? expected, object? actual) => Assert.AreEqual(expected, actual);
    }
}
