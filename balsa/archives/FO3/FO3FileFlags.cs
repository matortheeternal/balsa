using System.Collections.Generic;

namespace balsa.archives {
    public class FO3FileFlags : Flags {
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

        public static FO3FileFlags Read(ArchiveFileSource source) {
            return new FO3FileFlags() {
                data = source.reader.ReadUInt32()
            };
        }
    }
}
