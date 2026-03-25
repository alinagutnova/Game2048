using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    internal interface IMovement
    {
        bool MoveLeft();
        bool MoveRight();
        bool MoveUp();
        bool MoveDown();
        bool CanMove();
    }
}
