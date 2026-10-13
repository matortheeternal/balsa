namespace balsa.archives {
    public class TES4FileRecord : FileRecord {
        public static TES4FileRecord Read(FileRecordBlock block) {
            var source = block.archive.source;
            return new TES4FileRecord() {
                fileRecordBlock = block,
                hash = source.reader.ReadBytes(8),
                size = source.reader.ReadUInt32(),
                offset = source.reader.ReadUInt32()
            };
        }
    }
}
