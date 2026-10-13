namespace balsa.archives {
    public class SSEFileRecordBlock : FileRecordBlock {
        internal static SSEFileRecordBlock Read(FolderRecord folderRecord) {
            var block = new SSEFileRecordBlock() { folderRecord = folderRecord };
            if (block.archive.hasDirectoryNames)
                block.name = block.source.ReadString(1);
            block.fileRecords = new FileRecord[folderRecord.fileCount];
            for (int i = 0; i < folderRecord.fileCount; i++)
                block.fileRecords[i] = SSEFileRecord.Read(block);
            return block;
        }
    }
}
