using System.IO;
using System.IO.MemoryMappedFiles;

namespace balsa.shared {
    public class FileSource {
        internal readonly string filePath;

        private readonly MemoryMappedFile file;
        internal readonly MemoryMappedViewStream stream;
        internal readonly BinaryReader reader;
        private readonly FileInfo fileInfo;

        internal long fileSize => fileInfo.Length;

        internal FileSource(string filePath) {
            this.filePath = filePath;
            fileInfo = new FileInfo(filePath);
            var baseStream = new FileStream(
                filePath, FileMode.Open,
                FileAccess.Read, FileShare.ReadWrite
            );
            file = MemoryMappedFile.CreateFromFile(
                baseStream, null, 0, MemoryMappedFileAccess.Read,
                HandleInheritability.None, false
            );
            stream = file.CreateViewStream(
                0, 0, MemoryMappedFileAccess.Read
            );
            reader = new BinaryReader(stream);
        }
    }
}
