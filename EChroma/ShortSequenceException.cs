using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EChroma {
    class ShortSequenceException : Exception{

        private string msg = "Sequence too short";
        public ShortSequenceException(int required, int length) {
            msg += $": required: {required}, length: {length}";
        }

        public override string Message {
            get {
                return msg;
            }
        }
    }
}
