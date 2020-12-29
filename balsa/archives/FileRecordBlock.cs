namespace balsa.archives {
    public class FileRecordBlock {
        public FolderRecord folderRecord;
        internal string name;
        internal FileRecord[] fileRecords;

        internal ArchiveFile archive => folderRecord.archive;
        internal ArchiveFileSource source => folderRecord.source;
    }
}
