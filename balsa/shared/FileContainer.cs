using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace balsa.shared {
    public class FileContainer {
        public virtual string path => throw new NotImplementedException();

        public virtual List<string> GetFiles() {
            throw new NotImplementedException();
        }

        public virtual List<string> GetMatchingFiles(Regex expr) {
            return GetFiles().FindAll(filePath => {
                return expr.IsMatch(filePath);
            });
        }

        public virtual List<string> EnumerateEntries(string subPath) {
            throw new NotImplementedException();
        }
    }
}
