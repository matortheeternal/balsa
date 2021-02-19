using System.Collections.Generic;

namespace balsa.archives {
    public class FileRecordBlock {
        internal FolderRecord folderRecord;
        internal string name;
        internal FileRecord[] fileRecords;

        internal ArchiveFile archive => folderRecord.archive;
        internal ArchiveFileSource source => folderRecord.source;

        public List<FileRecord> GetFileRecords() {
            return new List<FileRecord>(fileRecords);
        }
    }
}
