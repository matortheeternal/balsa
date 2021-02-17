namespace balsa {
    public static class Games {
        public static Game TES4 = new Game {
            xeditId = 1,
            name = "Oblivion",
            fullName = "The Elder Scrolls IV: Oblivion",
            abbreviation = "TES4"
        }.InitDefaults();

        public static Game FO3 = new Game {
            xeditId = 2,
            name = "Fallout 3",
            abbreviation = "FO3"
        }.InitDefaults();

        public static Game FNV = new Game {
            xeditId = 2,
            name = "Fallout NV",
            fullName = "Fallout: New Vegas",
            abbreviation = "FNV"
        }.InitDefaults();

        public static Game TES5 = new Game {
            xeditId = 4,
            name = "Skyrim",
            fullName = "The Elder Scrolls V: Skyrim",
            abbreviation = "TES5"
        }.InitDefaults();

        public static Game FO4 = new Game {
            xeditId = 6,
            name = "Fallout 4",
            abbreviation = "FO4",
            archiveExtension = ".ba2"
        }.InitDefaults();

        public static Game SSE = new Game {
            xeditId = 7,
            name = "Skyrim SE",
            fullName = "Skyrim: Special Edition",
            abbreviation = "SSE"
        }.InitDefaults();
    }
}
