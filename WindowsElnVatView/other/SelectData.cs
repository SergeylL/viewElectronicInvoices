using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsElnVatView.other
{
    class SelectData
    {
        public readonly string value;
        public readonly string text;

        public SelectData(string value, string text) {
            this.value = value;
            this.text = text;
        }

        public override string ToString()
        {
            return this.text;
        }
    }
}
