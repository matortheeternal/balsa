namespace balsa.archives {
    public class SSEFileRecord : FileRecord {
        public static SSEFileRecord Read(FileRecordBlock block) {
            var source = block.archive.source;
            return new SSEFileRecord() {
                fileRecordBlock = block,
                hash = source.reader.ReadBytes(8),
                size = source.reader.ReadUInt32(),
                offset = source.reader.ReadUInt32()
            };
        }
    }
}
