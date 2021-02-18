using NUnit.Framework;
using balsa.setup;
using balsa;

namespace Tests.setup {
    public class AssetManagerTests {
        public AssetManager manager;

        [OneTimeSetUp]
        public void Setup() {
            manager = new AssetManager(Games.TES5);
        }

        [Test]
        public void Test1() {
            Assert.Pass();
        }
    }
}