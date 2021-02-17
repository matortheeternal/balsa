using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace balsa.archives {
    public class ArchiveFile : FileContainer {
        static readonly Encoding windows1252 = Encoding.GetEncoding(1252);

        internal string fileName;
        internal ArchiveFileSource source;

        internal virtual bool compressed => false;
        internal virtual Encoding encoding => windows1252;

        public ArchiveFile file => this;
        public string filePath => source?.filePath;
        public virtual bool hasDirectoryNames => false;
        public virtual bool hasFileNames => false;
        public virtual bool embedFileNames => false;

        public override string path => filePath;

        public ArchiveFile(string fileName) {
            this.fileName = fileName;
        }

        internal virtual void ReadHeader() {
            throw new NotImplementedException();
        }

        internal virtual void ReadBody() {
            throw new NotImplementedException();
        }

        internal virtual int GetFileRecordIndex(FileRecord fileRecord) {
            throw new NotImplementedException();
        }

        internal virtual int GetFolderRecordIndex(FolderRecord folderRecord) {
            throw new NotImplementedException();
        }

        internal virtual string GetFileName(FileRecord fileRecord) {
            throw new NotImplementedException();
        }

        public void ExtractTo(string outputPath) {
            GetFolderRecords().ForEach(folderRecord => {
                string folderPath = Path.Combine(outputPath, folderRecord.name);
                Directory.CreateDirectory(folderPath);
                folderRecord.ExtractTo(folderPath);
            });
        }

        public virtual FileRecord GetFileRecord(string filePath) {
            throw new NotImplementedException();
        }

        public virtual FolderRecord GetFolderRecord(string folderPath) {
            throw new NotImplementedException();
        }

        public virtual List<FolderRecord> GetFolderRecords() {
            throw new NotImplementedException();
        }
    }
}
