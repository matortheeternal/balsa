using System.Collections.Generic;

namespace balsa.archives {
    public class FO3ArchiveFlags : Flags {
        public static List<string> archiveFlags = new List<string>() {
            "Include Directory Names",
            "Include File Names",
            "Compressed",
            "Retain Directory Names",
            "Retain File Names",
            "Retain File Name Offsets",
            "Xbox 360 Archive",
            "Retain Strings During Startup",
            "Embed File Names",
            "XMem Codec"
        };

        public override List<string> flags => archiveFlags;

        public static FO3ArchiveFlags Read(ArchiveFileSource source) {
            return new FO3ArchiveFlags() {
                data = source.reader.ReadUInt32()
            };
        }
    }
}
