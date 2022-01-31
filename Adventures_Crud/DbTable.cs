using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventures_Crud
{
    class DbTable
    {
        public bool ReadOnly { get; }
        public string Name { get; }

        public DbTable(string name, bool isReadOnly)
        {
            this.ReadOnly = isReadOnly;
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
