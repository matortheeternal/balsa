using System;

namespace balsa.archives {
    public class SSEArchiveHeader {
        public byte[] fileId { get; internal set; }
        public UInt32 version { get; internal set; }
        public UInt32 folderOffset { get; internal set; }
        public SSEArchiveFlags archiveFlags { get; internal set; }
        public UInt32 folderCount { get; internal set; }
        public UInt32 fileCount { get; internal set; }
        public UInt32 totalFolderNameLength { get; internal set; }
        public UInt32 totalFileNameLength { get; internal set; }
        public SSEFileFlags fileFlags { get; internal set; }

        public static SSEArchiveHeader Read(ArchiveFileSource source) {
            return new SSEArchiveHeader() {
                fileId = source.reader.ReadBytes(4),
                version = source.reader.ReadUInt32(),
                folderOffset = source.reader.ReadUInt32(),
                archiveFlags = SSEArchiveFlags.Read(source),
                folderCount = source.reader.ReadUInt32(),
                fileCount = source.reader.ReadUInt32(),
                totalFolderNameLength = source.reader.ReadUInt32(),
                totalFileNameLength = source.reader.ReadUInt32(),
                fileFlags = SSEFileFlags.Read(source)
            };
        }
    }
}
