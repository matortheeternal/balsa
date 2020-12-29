using System.Collections.Generic;

namespace balsa.archives.TES5 {
    public class TES5FileFlags : Flags {
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

        public static TES5FileFlags Read(ArchiveFileSource source) {
            return new TES5FileFlags() {
                data = source.reader.ReadUInt32()
            };
        }
    }
}
