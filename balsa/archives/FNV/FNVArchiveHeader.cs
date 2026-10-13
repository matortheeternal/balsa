using System;

namespace balsa.archives {
    public class FNVArchiveHeader {
        public byte[] fileId { get; internal set; }
        public UInt32 version { get; internal set; }
        public UInt32 folderOffset { get; internal set; }
        public FNVArchiveFlags archiveFlags { get; internal set; }
        public UInt32 folderCount { get; internal set; }
        public UInt32 fileCount { get; internal set; }
        public UInt32 totalFolderNameLength { get; internal set; }
        public UInt32 totalFileNameLength { get; internal set; }
        public FNVFileFlags fileFlags { get; internal set; }

        public static FNVArchiveHeader Read(ArchiveFileSource source) {
            return new FNVArchiveHeader() {
                fileId = source.reader.ReadBytes(4),
                version = source.reader.ReadUInt32(),
                folderOffset = source.reader.ReadUInt32(),
                archiveFlags = FNVArchiveFlags.Read(source),
                folderCount = source.reader.ReadUInt32(),
                fileCount = source.reader.ReadUInt32(),
                totalFolderNameLength = source.reader.ReadUInt32(),
                totalFileNameLength = source.reader.ReadUInt32(),
                fileFlags = FNVFileFlags.Read(source)
            };
        }
    }
}
