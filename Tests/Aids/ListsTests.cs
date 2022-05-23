﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Rakendus.Aids;
using Rakendus.Data.Party;

namespace Rakendus.Tests.Aids {
    [TestClass] public class ListsTests : TypeTests {
        private List<int> list = new ();
        [TestInitialize] public void Init() => list = new List<int>() { 1, 2, 3, 4, 5, 6 };
        [TestMethod]public void GetFirstTest() => areEqual(1, Lists.GetFirst(list));
        [TestMethod] public void RemoveTest() {
            var cnt = Lists.Remove(list, x => x < 4);
            areEqual(3, cnt);
            areEqual(4, Lists.GetFirst(list));
        }
        [TestMethod] public void IsEmptyTest() {
            List<ItemData>? items = null;
            isFalse(Lists.IsEmpty(list));
            isTrue(Lists.IsEmpty(items));
            isTrue(Lists.IsEmpty(new List<string>()));
        }
        [TestMethod] public void ContainsItemTest() {
            isTrue(Lists.ContainsItem(list, x => x < 2));
            isFalse(Lists.ContainsItem(list, x => x > 6));
        }
    }
}
