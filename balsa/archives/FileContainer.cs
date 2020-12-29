using System;
using System.Collections.Generic;

namespace balsa.archives {
    public class FileContainer {
        public virtual string path => throw new NotImplementedException();

        public virtual List<string> GetFiles() {
            throw new NotImplementedException();
        }
    }
}
