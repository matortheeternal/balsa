using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using balsa.shared;

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

        public override List<string> GetFiles() {
            return GetFolderRecords().SelectMany(folderRec => {
                return folderRec.filePaths;
            }).ToList();
        }

        public override List<string> EnumerateEntries(string subPath) {
            var results = new List<string>();
            GetFolderRecords().ForEach(folderRecord => {
                var folderPath = folderRecord.name;
                if (!folderPath.StartsWith(subPath)) return;
                if (folderPath.Length > subPath.Length) {
                    var folderName = folderPath.Substring(subPath.Length);
                    if (folderName.IndexOf(@"\") > -1) return;
                    results.Add(folderPath);
                } else {
                    results.AddRange(folderRecord.filePaths);
                }
            });
            return results;
        }
    }
}
