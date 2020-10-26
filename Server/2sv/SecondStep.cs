using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESproject._2sv {
    class SecondStep {
        private string code;
        private static int codeLength = 6;

        public SecondStep() {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            code = new string(Enumerable.Repeat(chars, codeLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string getCode() {
            return code;
        }

        public bool checkCode(string code) {
            return this.code.Equals(code);
        }
    }
}
