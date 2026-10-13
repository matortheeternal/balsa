using System.Collections.Generic;

namespace balsa.archives {
    public class SSEFileFlags : Flags {
        public static List<string> fileFlags = new List<string>() {
            "Meshes",
            "Textures",
            "Menus",
            "Sounds",
            "Voices",
            "Shaders",
            "Trees",
            "Fonts"
        };

        public override List<string> flags => fileFlags;

        public static SSEFileFlags Read(ArchiveFileSource source) {
            return new SSEFileFlags() {
                data = source.reader.ReadUInt32()
            };
        }
    }
}
