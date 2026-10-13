using System.Collections.Generic;

namespace balsa.archives {
    public class SSEArchiveFlags : Flags {
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

        public static SSEArchiveFlags Read(ArchiveFileSource source) {
            return new SSEArchiveFlags() {
                data = source.reader.ReadUInt32()
            };
        }
    }
}
