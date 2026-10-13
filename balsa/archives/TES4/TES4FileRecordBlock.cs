namespace balsa.archives {
    public class TES4FileRecordBlock : FileRecordBlock {
        internal static TES4FileRecordBlock Read(FolderRecord folderRecord) {
            var block = new TES4FileRecordBlock() { folderRecord = folderRecord };
            if (block.archive.hasDirectoryNames)
                block.name = block.source.ReadString(1);
            block.fileRecords = new FileRecord[folderRecord.fileCount];
            for (int i = 0; i < folderRecord.fileCount; i++)
                block.fileRecords[i] = TES4FileRecord.Read(block);
            return block;
        }
    }
}
