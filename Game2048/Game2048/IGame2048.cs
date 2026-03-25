using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public enum Direction { 
        Up,
        Down,
        Left,
        Right
    }

    internal interface IGame2048
    {
        int Size { get; }
        int[,] Board { get; }
        int Score { get; }
        bool IsGameOver { get; }
        bool isWin { get; }

        void Init();
        void Move(Direction direction);
        void Reset();
    }
}
