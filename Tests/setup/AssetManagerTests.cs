using NUnit.Framework;
using balsa.setup;

namespace Tests.setup {
    public class AssetManagerTests {
        public AssetManager manager;

        [OneTimeSetUp]
        public void Setup() {
            manager = new AssetManager();
        }

        [Test]
        public void Test1() {
            Assert.Pass();
        }
    }
}