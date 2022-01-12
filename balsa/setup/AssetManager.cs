using balsa.archives;
using balsa.stringtables;
using balsa.shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace balsa.setup {
    public class AssetManager {
        public List<FileContainer> containers;
        public readonly Game game;
        internal Type archiveFileType;
        internal Type stringFileType;

        private static readonly string[] stringTableExtensions = {
            ".strings", ".ilstrings", ".dlstrings"
        };

        public AssetManager(Game game) {
            this.game = game;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var prefix = $"balsa.archives.{game.abbreviation}";
            archiveFileType = Type.GetType($"{prefix}ArchiveFile");
            prefix = $"balsa.stringtables.{game.abbreviation}";
            stringFileType = Type.GetType($"{prefix}StringFile");
            containers = new List<FileContainer>();
        }

        public ArchiveFile LoadArchive(string filePath) {
            var fileName = Path.GetFileName(filePath);
            ArchiveFile archive = (ArchiveFile) Activator.CreateInstance(
                archiveFileType, new object[1] { fileName }
            );
            new ArchiveFileSource(filePath, archive);
            archive.ReadHeader();
            archive.ReadBody();
            containers.Add(archive);
            return archive;
        }

        public StringFile LoadStrings(string filePath) {
            var fileName = Path.GetFileName(filePath);
            StringFile stringFile = (StringFile)Activator.CreateInstance(
                stringFileType, new object[1] { fileName }
            );
            new StringFileSource(filePath, stringFile);
            stringFile.ReadHeader();
            stringFile.ReadBody();
            return stringFile;
        }

        public List<string> GetLoadedContainers() {
            return containers.Select(fc => fc.path).ToList();
        }

        public FolderContainer LoadFolder(string path) {
            FolderContainer folder = new FolderContainer(path);
            containers.Add(folder);
            return folder;
        }

        public List<string> EnumerateEntries(string folderPath) {
            return containers.SelectMany(container => {
                return container.EnumerateEntries(folderPath);
            }).ToList();
        }

        public Dictionary<string, List<string>> GetStringTables() {
            var m = new Dictionary<string, List<string>>();
            EnumerateEntries(@"strings\").ForEach(filePath => {
                var ext = Path.GetExtension(filePath);
                if (!stringTableExtensions.Contains(ext)) return;
                var key = Path.GetFileNameWithoutExtension(filePath);
                if (!m.ContainsKey(key)) m.Add(key, new List<string>());
                m[key].Add(filePath);
            });
            return m;
        }

        public void BuildArchive(string outputPath, List<string> filePaths) {
            // ?
        }

        public byte[] GetTextureData(string filePath) {
            // ?
            return null;
        }
    }
}
