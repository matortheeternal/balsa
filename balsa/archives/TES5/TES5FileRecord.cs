namespace balsa.archives {
    public class TES5FileRecord : FileRecord {
        public static TES5FileRecord Read(FileRecordBlock block) {
            var source = block.archive.source;
            return new TES5FileRecord() {
                fileRecordBlock = block,
                hash = source.reader.ReadBytes(8),
                size = source.reader.ReadUInt32(),
                offset = source.reader.ReadUInt32()
            };
        }
    }
}
