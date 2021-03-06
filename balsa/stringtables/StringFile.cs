﻿using System;
using System.Text;
using System.IO;

namespace balsa.stringtables {
    public class StringFile {
        static readonly Encoding windows1252 = Encoding.GetEncoding(1252);

        internal string filename;
        internal StringFileSource source;
        internal int prefixLength;

        internal virtual Encoding encoding => windows1252;
        public string filePath => source?.filePath;

        public StringFile(string filename) {
            this.filename = filename;
            var ext = Path.GetExtension(filename).ToLower();
            switch (ext) {
                case ".strings":
                    prefixLength = 0;
                    break;
                case ".ilstrings":
                case ".dlstrings":
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
    }
}
