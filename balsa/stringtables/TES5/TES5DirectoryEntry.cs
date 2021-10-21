using System;

namespace balsa.stringtables {
    public class TES5DirectoryEntry {
        internal TES5StringFile stringFile;
        internal UInt32 id;
        internal UInt32 offset;

        internal StringFileSource source => stringFile.source;

        public static TES5DirectoryEntry Read(TES5StringFile file) {
            var source = file.source;
            return new TES5DirectoryEntry() {
                stringFile = file,
                id = source.reader.ReadUInt32(),
                offset = source.reader.ReadUInt32()
            };
        }

        public string data {
            get {
                source.stream.Position = stringFile.dataOffset + offset;
                return source.ReadString(stringFile.prefixLength);
            }
        }
    }
}
