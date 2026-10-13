using System.Collections.Generic;

namespace balsa.archives {
    public class FNVFileFlags : Flags {
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

        public static FNVFileFlags Read(ArchiveFileSource source) {
            return new FNVFileFlags() {
                data = source.reader.ReadUInt32()
            };
        }
    }
}
