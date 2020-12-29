using System;
using System.Collections.Generic;

namespace balsa.archives {
    public class Flags {
        public virtual List<string> flags => throw new NotImplementedException();

        internal UInt32 data;

        public int GetFlagIndex(string flag) {
            var index = flags.IndexOf(flag);
            if (index == -1) throw new Exception($"Unknown flag: {flag}");
            return index;
        }

        public bool HasFlag(string flag) {
            var index = GetFlagIndex(flag);
            return (data & (1 << index)) == 1;
        }

        public void SetFlag(string flag) {
            var index = GetFlagIndex(flag);
            data |= (UInt32) (1 << index);
        }
    }
}
