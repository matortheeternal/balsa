namespace balsa.archives {
    public class FNVFileRecord : FileRecord {
        public static FNVFileRecord Read(FileRecordBlock block) {
            var source = block.archive.source;
            return new FNVFileRecord() {
                fileRecordBlock = block,
                hash = source.reader.ReadBytes(8),
                size = source.reader.ReadUInt32(),
                offset = source.reader.ReadUInt32()
            };
        }
    }
}
