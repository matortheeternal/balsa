using System;
using System.IO;
using System.Text;
using Ionic.Zlib;
using balsa.shared;

namespace balsa.archives {
    public class ArchiveFileSource : FileSource {
        internal readonly ArchiveFile archive;

        internal Encoding stringEncoding => archive.encoding;

        internal ArchiveFileSource(string filePath, ArchiveFile archive) :
            base(filePath) {
            this.archive = archive;
            archive.source = this;
        }

        internal dynamic ReadPrefix(int prefixLength) {
            switch (prefixLength) {
                case 1: return reader.ReadByte();
                case 2: return reader.ReadUInt16();
                case 4: return reader.ReadUInt32();
            }
            throw new Exception($"Unknown prefix length {prefixLength}");
        }

        internal string ReadZString(byte terminator = 0) {
            byte[] bytes = new byte[32];
            int i = 0;
            do {
                byte b = reader.ReadByte();
                if (b == 0) break;
                if (i >= bytes.Length) {
                    var newBytes = new byte[bytes.Length * 2];
                    bytes.CopyTo(newBytes, 0);
                    bytes = newBytes;
                }
                bytes[i++] = b;
            } while (true);
            if (i == 0) return string.Empty;
            return stringEncoding.GetString(bytes, 0, i);
        }

        internal string ReadBString(int len) {
            var bytes = reader.ReadBytes(len);
            return stringEncoding.GetString(bytes, 0, len);
        }

        internal string ReadString(int prefixLength = 0, bool nullTerminated = true) {
            if (prefixLength > 0) {
                dynamic len = ReadPrefix(prefixLength);
                if (nullTerminated) len--;
                return ReadBString(len);
            }
            if (!nullTerminated)
                throw new Exception("Cannot read unterminated string of unknown length.");
            return ReadZString();
        }

        internal byte[] Decompress(int dataSize) {
            var decompressedDataSize = reader.ReadUInt32();
            var zstream = new ZlibStream(stream, CompressionMode.Decompress);
            var zreader = new BinaryReader(zstream);
            return zreader.ReadBytes((int)decompressedDataSize);
        }
    }
}
