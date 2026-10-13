namespace balsa.archives {
    public class TES4FolderRecord : FolderRecord {
        public static TES4FolderRecord Read(ArchiveFile archive) {
            var source = archive.source;
            return new TES4FolderRecord() {
                hash = source.reader.ReadBytes(8),
                fileCount = source.reader.ReadUInt32(),
                offset = source.reader.ReadUInt32(),
                archive = archive
            };
        }
    }
}
