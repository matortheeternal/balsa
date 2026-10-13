namespace balsa.archives {
    public class FO3FolderRecord : FolderRecord {
        public static FO3FolderRecord Read(ArchiveFile archive) {
            var source = archive.source;
            return new FO3FolderRecord() {
                hash = source.reader.ReadBytes(8),
                fileCount = source.reader.ReadUInt32(),
                offset = source.reader.ReadUInt32(),
                archive = archive
            };
        }
    }
}
