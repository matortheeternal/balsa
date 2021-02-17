using System;

namespace balsa.archives {
    // https://en.uesp.net/wiki/Skyrim_Mod:Archive_File_Format
    // Are there differences between SSE BSAs and TES5 BSAs?
    // I think there are, I need to check this.
    public class SSEArchiveFile : TES5ArchiveFile {
        public SSEArchiveFile(string fileName) : base(fileName) {
            throw new NotImplementedException();
        }
    }
}
