using System;

namespace balsa.archives {
    public class FO3ArchiveHeader {
        public byte[] fileId { get; internal set; }
        public UInt32 version { get; internal set; }
        public UInt32 folderOffset { get; internal set; }
        public FO3ArchiveFlags archiveFlags { get; internal set; }
        public UInt32 folderCount { get; internal set; }
        public UInt32 fileCount { get; internal set; }
        public UInt32 totalFolderNameLength { get; internal set; }
        public UInt32 totalFileNameLength { get; internal set; }
        public FO3FileFlags fileFlags { get; internal set; }

        public static FO3ArchiveHeader Read(ArchiveFileSource source) {
            return new FO3ArchiveHeader() {
                fileId = source.reader.ReadBytes(4),
                version = source.reader.ReadUInt32(),
                folderOffset = source.reader.ReadUInt32(),
                archiveFlags = FO3ArchiveFlags.Read(source),
                folderCount = source.reader.ReadUInt32(),
                fileCount = source.reader.ReadUInt32(),
                totalFolderNameLength = source.reader.ReadUInt32(),
                totalFileNameLength = source.reader.ReadUInt32(),
                fileFlags = FO3FileFlags.Read(source)
            };
        }
    }
}
