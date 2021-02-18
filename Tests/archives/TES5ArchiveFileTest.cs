using NUnit.Framework;
using balsa.setup;
using balsa.archives;
using balsa;
using System.Linq;
using System.Text;
using System.Collections.Generic;

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
            Assert.AreEqual(104, archive.header.version);
            Assert.AreEqual(1, archive.header.folderCount);
            Assert.AreEqual(1, archive.header.fileCount);
            Assert.AreEqual(10, archive.header.totalFolderNameLength);
            Assert.AreEqual(9, archive.header.totalFileNameLength);
        }

        [Test]
        public void TestFileFlags() {
            var flags = archive.header.fileFlags;
            Assert.IsFalse(flags.HasFlag("Meshes"));
            Assert.IsFalse(flags.HasFlag("Textures"));
            Assert.IsFalse(flags.HasFlag("Menus"));
            Assert.IsFalse(flags.HasFlag("Sounds"));
            Assert.IsFalse(flags.HasFlag("Voices"));
            Assert.IsFalse(flags.HasFlag("Shaders"));
            Assert.IsFalse(flags.HasFlag("Trees"));
            Assert.IsFalse(flags.HasFlag("Fonts"));
            Assert.IsTrue(flags.HasFlag("Miscellaneous"));
        }

        [Test]
        public void TestArchiveFlags() {
            var flags = archive.header.archiveFlags;
            Assert.IsTrue(flags.HasFlag("Include Directory Names"));
            Assert.IsTrue(flags.HasFlag("Include File Names"));
            Assert.IsFalse(flags.HasFlag("Compressed"));
            Assert.IsFalse(flags.HasFlag("Retain Directory Names"));
            Assert.IsFalse(flags.HasFlag("Retain File Names"));
            Assert.IsFalse(flags.HasFlag("Retain File Name Offsets"));
            Assert.IsFalse(flags.HasFlag("Xbox 360 Archive"));
            Assert.IsFalse(flags.HasFlag("Retain Strings During Startup"));
            Assert.IsFalse(flags.HasFlag("Embed File Names"));
            Assert.IsFalse(flags.HasFlag("XMem Codec"));
        }

        [Test]
        public void TestFolders() {
            List<FolderRecord> folderRecords = archive.GetFolderRecords();
            Assert.AreEqual(1, folderRecords.Count);
            var folderRecord = folderRecords[0];
            Assert.AreEqual("interface", folderRecord.name);
        }
    }
}
