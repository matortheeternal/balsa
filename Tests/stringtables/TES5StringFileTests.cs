using NUnit.Framework;
using balsa.setup;
using balsa.stringtables;
using balsa;
using System.Collections.Generic;
using System;

namespace Tests.stringtables {
    public class TES5StringFileTests {
        public AssetManager manager;
        public TES5StringFile stringFile;

        [OneTimeSetUp]
        public void Setup() {
            manager = new AssetManager(Games.TES5);
            var stringsPath = TestHelpers.FixturePath("TES5.strings");
            stringFile = (TES5StringFile)manager.LoadStrings(stringsPath);
        }

        [Test]
        public void TestStrings() {
            var expectedStrings = new Dictionary<UInt32, string>(5) {
                { 0x1, "Test" },
                { 0x2, "Abc123" },
                { 0x3, "Pasta" },
                { 0x4, "Iron Thing" },
                { 0xFF600, "One Very Long String" }
            };
            CollectionAssert.AreEqual(expectedStrings, stringFile.strings);
        }
    }
}
