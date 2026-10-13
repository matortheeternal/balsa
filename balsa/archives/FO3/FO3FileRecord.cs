namespace balsa.archives {
    public class FO3FileRecord : FileRecord {
        public static FO3FileRecord Read(FileRecordBlock block) {
            var source = block.archive.source;
            return new FO3FileRecord() {
                fileRecordBlock = block,
                hash = source.reader.ReadBytes(8),
                size = source.reader.ReadUInt32(),
                offset = source.reader.ReadUInt32()
            };
        }
    }
}
