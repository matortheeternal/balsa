using NUnit.Framework;
using balsa.setup;
using balsa.archives;
using balsa;
using System.Linq;
using System.Text;

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
        public void TestArchiveHeader() {
            byte[] bsaMagic = Encoding.ASCII.GetBytes("BSA\0");
            Assert.IsTrue(archive.header.fileId.SequenceEqual(bsaMagic));
            Assert.AreEqual(archive.header.version, 104);
            var flags = archive.header.archiveFlags;
            Assert.IsTrue(flags.HasFlag("Include Directory Names"));
            Assert.IsTrue(flags.HasFlag("Include File Names"));
            Assert.IsTrue(flags.HasFlag("Compressed"));
            Assert.IsTrue(flags.HasFlag("Retain Directory Names"));
            Assert.IsTrue(flags.HasFlag("Retain File Names"));
            Assert.IsTrue(flags.HasFlag("Retain File Name Offsets"));
            Assert.IsFalse(flags.HasFlag("Xbox 360 Archive"));
            Assert.IsTrue(flags.HasFlag("Retain Strings During Startup"));
            Assert.IsTrue(flags.HasFlag("Embed File Names"));
            Assert.IsTrue(flags.HasFlag("XMem Codec"));
        }
    }
}
