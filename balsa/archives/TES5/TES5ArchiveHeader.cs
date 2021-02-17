using System;

namespace balsa.archives {
    public class TES5ArchiveHeader {
        internal byte[] fileId;
        internal UInt32 version;
        internal UInt32 folderOffset;
        internal TES5ArchiveFlags archiveFlags;
        internal UInt32 folderCount;
        internal UInt32 fileCount;
        internal UInt32 totalFolderNameLength;
        internal UInt32 totalFileNameLength;
        internal UInt32 fileFlags;

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
                fileFlags = source.reader.ReadUInt32()
            };
        }
    }
}
