using System;
using System.Collections.Generic;

namespace balsa.stringtables {
    public class TES5StringFile : StringFile {
        internal UInt32 count;
        internal UInt32 dataSize;
        internal long dataOffset;
        internal TES5DirectoryEntry[] directoryEntries;

        public TES5StringFile(string filename) : base(filename) {}

        internal override void ReadHeader() {
            count = source.reader.ReadUInt32();
            dataSize = source.reader.ReadUInt32();
        }

        internal override void ReadBody() {
            directoryEntries = new TES5DirectoryEntry[count];
            for (int i = 0; i < count; i++)
                directoryEntries[i] = TES5DirectoryEntry.Read(this);
            dataOffset = source.stream.Position;
        }

        internal override Dictionary<UInt32, string> GetStrings() {
            var strings = new Dictionary<UInt32, string>();
            for (int i = 0; i < count; i++) {
                var entry = directoryEntries[i];
                strings.Add(entry.id, entry.data);
            }
            return strings;
        }
    }
}
