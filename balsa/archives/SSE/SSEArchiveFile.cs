using System;
using System.Collections.Generic;
using System.IO;

namespace balsa.archives {
    // https://en.uesp.net/wiki/Skyrim_Mod:Archive_File_Format
    public class SSEArchiveFile : ArchiveFile {
        public SSEArchiveHeader header { get; internal set; }
        internal SSEFolderRecord[] folderRecords;
        internal string[] fileNames;
        // TODO: faster implementation via caching?
        internal override bool compressed => header.archiveFlags.HasFlag("Compressed");

        public SSEArchiveFile(string fileName) : base(fileName) { }

        internal override ArchiveFileSource CreateSource(string filePath) {
            return new SSEArchiveFileSource(filePath, this);
        }

        public override bool hasDirectoryNames {
            get => header.archiveFlags.HasFlag("Include Directory Names");
        }

        public override bool hasFileNames {
            get => header.archiveFlags.HasFlag("Include File Names");
        }

        public override bool embedFileNames {
            get => header.archiveFlags.HasFlag("Embed File Names");
        }

        internal override void ReadHeader() {
            header = SSEArchiveHeader.Read(source);
        }

        private void ReadFolderRecords() {
            folderRecords = new SSEFolderRecord[header.folderCount];
            for (int i = 0; i < header.folderCount; i++)
                folderRecords[i] = SSEFolderRecord.Read(this);
        }

        private void ReadFileRecordBlocks() {
            for (int i = 0; i < header.folderCount; i++) {
                var block = SSEFileRecordBlock.Read(folderRecords[i]);
                folderRecords[i].fileRecordBlock = block;
            }
        }

        private void ReadFileNames() {
            fileNames = new string[header.fileCount];
            for (int i = 0; i < header.fileCount; i++)
                fileNames[i] = source.ReadString();
        }

        internal override void ReadBody() {
            ReadFolderRecords();
            ReadFileRecordBlocks();
            if (hasFileNames) ReadFileNames();
        }

        internal override int GetFileRecordIndex(FileRecord fileRecord) {
            var targetBlock = fileRecord.fileRecordBlock;
            int index = 0;
            for (int i = 0; i < folderRecords.Length; i++) {
                var currentBlock = folderRecords[i].fileRecordBlock;
                if (currentBlock == targetBlock)
                    return index + Array.IndexOf(targetBlock.fileRecords, fileRecord);
                index += currentBlock.fileRecords.Length;
            }
            return -1;
        }

        internal override int GetFolderRecordIndex(FolderRecord folderRecord) {
            return Array.IndexOf(folderRecords, folderRecord);
        }

        internal override string GetFileName(FileRecord fileRecord) {
            if (hasFileNames) return fileNames[fileRecord.index];
            if (embedFileNames) return fileRecord.embeddedFileName;
            return null;
        }

        public override FolderRecord GetFolderRecord(string folderPath) {
            var folderRecord = Array.Find(folderRecords, f => {
                return f.name == folderPath;
            });
            if (folderRecord == null)
                throw new Exception($"Could not find folder: {folderPath}");
            return folderRecord;
        }

        public override FileRecord GetFileRecord(string filePath) {
            // Split on either separator explicitly: Path.GetDirectoryName
            // only recognizes the OS separator, so Windows-style archive
            // paths (backslash) fail on Linux.
            var normalizedPath = filePath.Replace('\\', '/');
            var separatorIndex = normalizedPath.LastIndexOf('/');
            var folderName = separatorIndex < 0
                ? ""
                : normalizedPath.Substring(0, separatorIndex);
            var fileName = separatorIndex < 0
                ? normalizedPath
                : normalizedPath.Substring(separatorIndex + 1);
            var folderRecord = GetFolderRecord(folderName);
            return folderRecord.GetFileRecord(fileName);
        }

        public override List<FolderRecord> GetFolderRecords() {
            return new List<FolderRecord>(folderRecords);
        }
    }
}
