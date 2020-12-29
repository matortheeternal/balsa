using System;

namespace balsa.stringtables.TES5 {
    public class TES5StringFile : StringFile {
        internal UInt32 count;
        internal UInt32 dataSize;
        internal TES5DirectoryEntry[] directoryEntries;

        internal override void ReadHeader() {
            count = source.reader.ReadUInt32();
            dataSize = source.reader.ReadUInt32();
        }

        internal override void ReadBody() {
            directoryEntries = new TES5DirectoryEntry[count];
        }
    }
}
