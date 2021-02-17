using balsa.shared;
using System;
using System.Text;

namespace balsa.stringtables {
    public class StringFileSource : FileSource {
        internal readonly StringFile stringFile;

        internal override Encoding stringEncoding => stringFile.encoding;

        internal StringFileSource(string filePath, StringFile stringFile) :
            base(filePath) {
            this.stringFile = stringFile;
            stringFile.source = this;
        }
    }
}
