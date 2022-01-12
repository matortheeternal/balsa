using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace balsa.shared {
    public class FolderContainer : FileContainer {
        internal string folderPath;

        public override string path => folderPath;

        public FolderContainer(string path) {
            if (!Directory.Exists(path))
                throw new Exception($"Directory {path} does not exist.");
            folderPath = path;
        }

        public override List<string> GetFiles() {
            return Directory.EnumerateFiles(
                folderPath, "*", SearchOption.AllDirectories
            ).ToList();
        }

        public override List<string> EnumerateEntries(string subPath) {
            string fullPath = Path.Combine(folderPath, subPath);
            return Directory.EnumerateFileSystemEntries(fullPath).ToList();
        }
    }
}
