using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewConect4
{
    class Cell
    {
        private int num;
        private string cell;
        public Cell()
        {
            this.num = 0;
            this.cell = "O";
        }
        public int GetNum()
        {
            return this.num;
        }
        public void SetNum(int num)
        {
            this.num = num;
        }
        public string GetCell()
        {
            return this.cell;
        } 
    }
}
