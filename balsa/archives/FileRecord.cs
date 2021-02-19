using System;
using System.IO;

namespace balsa.archives {
    public class FileRecord {
        public FileRecordBlock fileRecordBlock { get; internal set; }
        public byte[] hash { get; internal set; }
        public UInt32 size { get; internal set; }
        public UInt32 offset { get; internal set; }

        internal bool compressionToggle => (size & 0x40000000) == 1;

        internal ArchiveFileSource source => fileRecordBlock.source;
        internal ArchiveFile archive => fileRecordBlock.archive;

        internal int index {
            get => archive.GetFileRecordIndex(this);
        }

        public string fileName {
            get => archive.GetFileName(this);
        }

        internal string embeddedFileName {
            get {
                source.stream.Position = offset;
                return source.ReadString(1);
            }
        }

        public byte[] data {
            get {
                source.stream.Position = offset;
                bool compressed = source.archive.compressed ^ compressionToggle;
                if (source.archive.embedFileNames) source.ReadString(1);
                var dataOffset = source.stream.Position - offset;
                var dataSize = (int)(size - dataOffset);
                return compressed
                    ? source.Decompress(dataSize)
                    : source.reader.ReadBytes(dataSize);
            }
        }

        internal void ExtractTo(string outputPath) {
            if (fileName == null) throw new Exception("File does not have a filename");
            var fullPath = Path.Combine(outputPath, fileName);
            File.WriteAllBytes(fullPath, data);
        }
    }
}
