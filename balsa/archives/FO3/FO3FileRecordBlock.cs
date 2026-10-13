namespace balsa.archives {
    public class FO3FileRecordBlock : FileRecordBlock {
        internal static FO3FileRecordBlock Read(FolderRecord folderRecord) {
            var block = new FO3FileRecordBlock() { folderRecord = folderRecord };
            if (block.archive.hasDirectoryNames)
                block.name = block.source.ReadString(1);
            block.fileRecords = new FileRecord[folderRecord.fileCount];
            for (int i = 0; i < folderRecord.fileCount; i++)
                block.fileRecords[i] = FO3FileRecord.Read(block);
            return block;
        }
    }
}
