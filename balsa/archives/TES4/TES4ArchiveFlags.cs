using System.Collections.Generic;

namespace balsa.archives {
    public class TES4ArchiveFlags : Flags {
        public static List<string> archiveFlags = new List<string>() {
            "Include Directory Names",
            "Include File Names",
            "Compressed",
            "Retain Directory Names",
            "Retain File Names",
            "Retain File Name Offsets",
            "Xbox 360 Archive",
        "Retain Strings During Startup",
        "Unknown 8",
        "Unknown 9",
        "Unknown 10"
        };

        public override List<string> flags => archiveFlags;

        public static TES4ArchiveFlags Read(ArchiveFileSource source) {
            return new TES4ArchiveFlags() {
                data = source.reader.ReadUInt32()
            };
        }
    }
}
