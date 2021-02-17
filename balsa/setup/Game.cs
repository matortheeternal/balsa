namespace balsa {
    public class Game {
        public int xeditId;
        public string name;
        public string baseName;
        public string fullName;
        public string abbreviation;
        public string archiveExtension = ".bsa";

        public Game InitDefaults() {
            if (baseName == null) baseName = name.Replace(" ", string.Empty);
            if (fullName == null) fullName = name;
            return this;
        }
    }
}
