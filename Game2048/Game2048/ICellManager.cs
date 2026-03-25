using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public class Cell
    {
        public int Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int value, int x, int y)
        {
            Value = value;
            X = x;
            Y = y;
        }
    }

    internal interface ICellManager
    {
        void AddRandomCell();
        List<Cell> GetAllCells();
        void ClearCells();
        bool HasAvailableMoves();
        bool HasAvailableCells();
    }
}
