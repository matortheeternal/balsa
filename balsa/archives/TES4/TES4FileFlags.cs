using System.Collections.Generic;

namespace balsa.archives {
    public class TES4FileFlags : Flags {
        public static List<string> fileFlags = new List<string>() {
            "Meshes",
            "Textures",
            "Menus",
            "Sounds",
            "Voices",
            "Shaders",
            "Trees",
            "Fonts",
            "Miscellaneous"
        };

        public override List<string> flags => fileFlags;

        public static TES4FileFlags Read(ArchiveFileSource source) {
            return new TES4FileFlags() {
                data = source.reader.ReadUInt32()
            };
        }
    }
}
