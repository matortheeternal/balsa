using balsa.archives;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace balsa.setup {
    public class ArchiveManager {
        public List<FileContainer> containers;

        public ArchiveFile LoadArchive(string filePath) {
            // TODO: for game
            var archive = new ArchiveFile {
                filename = Path.GetFileName(filePath)
            };
            new ArchiveFileSource(filePath, archive);
            archive.ReadHeader();
            archive.ReadBody();
            containers.Add(archive);
            return archive;
        }

        public List<string> GetLoadedContainers() {
            return containers.Select(fc => fc.path).ToList();
        }

        public void LoadFolder(string path) {
            // ?
        }

        public void BuildArchive(List<string> filePaths) {
            // ?
        }

        public byte[] GetTextureData(string filePath) {
            // ?
            return null;
        }
    }
}
