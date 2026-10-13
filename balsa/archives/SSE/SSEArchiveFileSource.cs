using System;
using K4os.Compression.LZ4;

namespace balsa.archives {
    public class SSEArchiveFileSource : ArchiveFileSource {
        internal SSEArchiveFileSource(
            string filePath, ArchiveFile archive
        ) : base(filePath, archive) { }

        internal override byte[] Decompress(int dataSize) {
            var decompressedDataSize = reader.ReadUInt32();
            var inputLength = (dataSize & ~0x40000000) - 4;
            var input = reader.ReadBytes(inputLength);
            var output = new byte[decompressedDataSize];
            var decodedLength = LZ4Codec.Decode(
                input, 0, inputLength,
                output, 0, (int) decompressedDataSize
            );
            if (decodedLength != (int) decompressedDataSize)
                throw new Exception(
                    $"LZ4 output length mismatch: " +
                    $"expected {decompressedDataSize}, got {decodedLength}"
                );
            return output;
        }
    }
}
