namespace balsa.archives.TES5 {
    public class TES5FileRecord : FileRecord {
        public static TES5FileRecord Read(ArchiveFileSource source) {
            return new TES5FileRecord() {
                hash = source.reader.ReadBytes(8),
                size = source.reader.ReadUInt32(),
                offset = source.reader.ReadUInt32()
            };
        }
    }
}
