using System;

namespace balsa.stringtables.TES5 {
    public class TES5DirectoryEntry {
        internal TES5StringFile stringFile;
        internal UInt32 id;
        internal UInt32 offset;

        internal StringFileSource source => stringFile.source;

        public string data {
            get {
                source.stream.Position = offset;
                return source.ReadString(stringFile.prefixLength);
            }
        }
    }
}
