using System;
using System.IO;

namespace balsa.archives {
    public class FolderRecord {
        internal byte[] hash;
        internal UInt32 fileCount;
        internal UInt32 offset;
        internal ArchiveFile archive;
        internal FileRecordBlock fileRecordBlock;
        
        public string name => fileRecordBlock.name;
        internal ArchiveFileSource source => archive.source;
        internal int index => archive.GetFolderRecordIndex(this);

        internal void ExtractTo(string outputPath) {
            Directory.CreateDirectory(outputPath);
            Array.ForEach(fileRecordBlock.fileRecords, fileRecord => {
                fileRecord.ExtractTo(outputPath);
            });
        }

        internal FileRecord GetFileRecord(string fileName) {
            var fileRceord = Array.Find(fileRecordBlock.fileRecords, f => {
                return f.fileName == fileName;
            });
            if (fileRceord == null)
                throw new Exception($"Could not find file record: {fileName}");
            return fileRceord;
        }
    }
}
