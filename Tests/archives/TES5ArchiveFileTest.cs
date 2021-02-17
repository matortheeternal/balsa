using NUnit.Framework;
using balsa.setup;
using balsa.archives;
using balsa;

namespace Tests.archives {
    public class TES5ArchiveFileTest {
        public AssetManager manager;
        public TES5ArchiveFile archive;

        [OneTimeSetUp]
        public void Setup() {
            manager = new AssetManager(Games.TES5);
            var archivePath = TestHelpers.FixturePath("TES5.bsa");
            archive = (TES5ArchiveFile) manager.LoadArchive(archivePath);
        }

        [Test]
        public void Test1() {
            Assert.Pass();
        }
    }
}
