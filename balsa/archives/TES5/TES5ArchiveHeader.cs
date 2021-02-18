using System;

namespace balsa.archives {
    public class TES5ArchiveHeader {
        public byte[] fileId { get; internal set; }
        public UInt32 version { get; internal set; }
        public UInt32 folderOffset { get; internal set; }
        public TES5ArchiveFlags archiveFlags { get; internal set; }
        public UInt32 folderCount { get; internal set; }
        public UInt32 fileCount { get; internal set; }
        public UInt32 totalFolderNameLength { get; internal set; }
        public UInt32 totalFileNameLength { get; internal set; }
        public TES5FileFlags fileFlags { get; internal set; }

        public static TES5ArchiveHeader Read(ArchiveFileSource source) {
            return new TES5ArchiveHeader() {
                fileId = source.reader.ReadBytes(4),
                version = source.reader.ReadUInt32(),
                folderOffset = source.reader.ReadUInt32(),
                archiveFlags = TES5ArchiveFlags.Read(source),
                folderCount = source.reader.ReadUInt32(),
                fileCount = source.reader.ReadUInt32(),
                totalFolderNameLength = source.reader.ReadUInt32(),
                totalFileNameLength = source.reader.ReadUInt32(),
                fileFlags = TES5FileFlags.Read(source)
            };
        }
    }
}
