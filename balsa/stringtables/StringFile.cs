using System;
using System.Text;

namespace balsa.stringtables {
    public class StringFile {
        static readonly Encoding windows1252 = Encoding.GetEncoding(1252);

        internal string filename;
        internal StringFileSource source;

        internal virtual Encoding encoding => windows1252;
        public string filePath => source?.filePath;

        internal virtual void ReadHeader() {
            throw new NotImplementedException();
        }

        internal virtual void ReadBody() {
            throw new NotImplementedException();
        }
    }
}
