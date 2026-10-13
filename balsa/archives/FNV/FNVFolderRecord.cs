namespace balsa.archives {
    public class FNVFolderRecord : FolderRecord {
        public static FNVFolderRecord Read(ArchiveFile archive) {
            var source = archive.source;
            return new FNVFolderRecord() {
                hash = source.reader.ReadBytes(8),
                fileCount = source.reader.ReadUInt32(),
                offset = source.reader.ReadUInt32(),
                archive = archive
            };
        }
    }
}
