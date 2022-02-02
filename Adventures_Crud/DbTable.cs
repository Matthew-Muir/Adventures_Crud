using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventures_Crud
{
    class DbTable
    {
        public bool ReadOnly { get; }
        public string Name { get; }
        public string AddProc { get; set; }

        public DbTable(string name, bool isReadOnly, string addProc = null)
        {
            this.ReadOnly = isReadOnly;
            this.Name = name;
            this.AddProc = addProc;
        }

        public string AddtoTableProc(LabelInputPair[] cc)
        {
            string proc = $"EXECUTE AddTo{this.ToString()} ";
            for (int i = 0; i < cc.Length; i++)
            {
                var temp = cc[i];
                if (!string.IsNullOrEmpty(temp.Textbox.Text)){
                    proc += $" @{temp.LabelField.Text} = '{temp.Textbox.Text}',";
                }
            }
            //LEFT OFF HERE!!! protect against receiving all empty fields.
            proc = proc.Substring(0, proc.Length - 1);
            return proc;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
