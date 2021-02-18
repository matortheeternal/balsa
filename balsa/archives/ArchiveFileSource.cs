using System.IO;
using System.Text;
using Ionic.Zlib;
using balsa.shared;

namespace balsa.archives {
    public class ArchiveFileSource : FileSource {
        internal readonly ArchiveFile archive;

        internal override Encoding stringEncoding => archive.encoding;

        internal ArchiveFileSource(string filePath, ArchiveFile archive) :
            base(filePath) {
            this.archive = archive;
            archive.source = this;
        }

        internal byte[] Decompress(int dataSize) {
            var decompressedDataSize = reader.ReadUInt32();
            var zstream = new ZlibStream(stream, CompressionMode.Decompress);
            var zreader = new BinaryReader(zstream);
            return zreader.ReadBytes((int)decompressedDataSize);
        }
    }
}
