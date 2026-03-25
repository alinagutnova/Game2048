using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public interface IRenderer
    {
        void Render(IGame2048 game);
        void ShowGameOver();
        void ShowWin();
        void ShowInstructions();
    }
}
