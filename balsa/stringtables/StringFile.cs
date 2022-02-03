using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace balsa.stringtables {
    public class StringFile {
        static readonly Encoding windows1252 = Encoding.GetEncoding(1252);

        internal string filename;
        internal StringFileSource source;
        internal int prefixLength;

        internal virtual Encoding encoding => windows1252;
        public string filePath => source?.filePath;
        public StringFileType stringFileType;

        private Dictionary<UInt32, string> _strings;
        public Dictionary<UInt32, string> strings {
            get {
                if (_strings == null)
                    _strings = GetStrings();
                return _strings;
            }
        }

        public StringFile(string filename) {
            this.filename = filename;
            var ext = Path.GetExtension(filename).ToLower();
            switch (ext) {
                case ".strings":
                    stringFileType = StringFileType.STRINGS;
                    prefixLength = 0;
                    break;
                case ".ilstrings":
                    stringFileType = StringFileType.ILSTRINGS;
                    prefixLength = 4;
                    break;
                case ".dlstrings":
                    stringFileType = StringFileType.DLSTRINGS;
                    prefixLength = 4;
                    break;
                default:
                    throw new Exception("Unknown string file extension");
            }
        }

        internal virtual void ReadHeader() {
            throw new NotImplementedException();
        }

        internal virtual void ReadBody() {
            throw new NotImplementedException();
        }

        internal virtual Dictionary<UInt32, string> GetStrings() {
            throw new NotImplementedException();
        }
    }
}
