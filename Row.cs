using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewConect4
{
    class Row
    {
        private Cell[] row;

        public Row()
        {
            this.row = new Cell[7];
            for (int i = 0; i < this.row.Length; i++)
            {
                row[i] = new Cell();
            }
        }
        public Cell[] GetRow()
        {
            return this.row;
        }      
    }
}
