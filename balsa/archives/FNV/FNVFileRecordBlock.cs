namespace balsa.archives {
    public class FNVFileRecordBlock : FileRecordBlock {
        internal static FNVFileRecordBlock Read(FolderRecord folderRecord) {
            var block = new FNVFileRecordBlock() { folderRecord = folderRecord };
            if (block.archive.hasDirectoryNames)
                block.name = block.source.ReadString(1);
            block.fileRecords = new FileRecord[folderRecord.fileCount];
            for (int i = 0; i < folderRecord.fileCount; i++)
                block.fileRecords[i] = FNVFileRecord.Read(block);
            return block;
        }
    }
}
