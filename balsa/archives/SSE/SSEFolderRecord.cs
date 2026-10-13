using System;

namespace balsa.archives {
    public class SSEFolderRecord : FolderRecord {
        public UInt32 unknown { get; internal set; }

        public static SSEFolderRecord Read(ArchiveFile archive) {
            var source = archive.source;
            return new SSEFolderRecord() {
                hash = source.reader.ReadBytes(8),
                fileCount = source.reader.ReadUInt32(),
                unknown = source.reader.ReadUInt32(),
                offset = source.reader.ReadUInt64(),
                archive = archive
            };
        }
    }
}
