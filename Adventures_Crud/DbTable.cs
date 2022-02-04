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
        public bool GetReturn { get; set; }

        public DbTable(string name, bool isReadOnly, bool getReturn = false)
        {
            this.ReadOnly = isReadOnly;
            this.Name = name;
            this.GetReturn = getReturn;
        }

        public string AddtoTableProc(LabelInputPair[] cc)
        {
            string proc = $"EXEC AddTo{this.ToString(true)} ";
            for (int i = 0; i < cc.Length; i++)
            {
                var temp = cc[i];
                if (!string.IsNullOrEmpty(temp.Textbox.Text)){
                    proc += $" @{temp.LabelField.Text} = '{temp.Textbox.Text}',";
                }
            }

            proc = proc.Substring(0, proc.Length - 1);
            return proc;
        }

        public string DeleteFromTableProc(LabelInputPair[] cc)
        {
            string proc = $"EXEC DeleteFrom{this.ToString(true)} ";
            if (!string.IsNullOrEmpty(cc[0].Textbox.Text))
            {
                proc += "@" + cc[0].LabelField.Text + $" = {cc[0].Textbox.Text};";
            }
            
            return proc;
        }

        public string ToString(bool shortened = false)
        {
            return Name.Replace(" " , "");
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
