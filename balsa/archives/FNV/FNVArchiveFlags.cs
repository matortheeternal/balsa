using System.Collections.Generic;

namespace balsa.archives {
    public class FNVArchiveFlags : Flags {
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

        public static FNVArchiveFlags Read(ArchiveFileSource source) {
            return new FNVArchiveFlags() {
                data = source.reader.ReadUInt32()
            };
        }
    }
}
