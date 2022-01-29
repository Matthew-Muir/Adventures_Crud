using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventures_Crud
{
    class LabelInputPair
    {
        public TextBox Textbox { get; set; }
        public Label LabelField { get; set; }
        public LabelInputPair(TextBox tb, Label l)
        {
            this.Textbox = tb;
            this.LabelField = l;
        }
    }
}
