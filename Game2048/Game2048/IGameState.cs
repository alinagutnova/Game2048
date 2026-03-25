using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public enum GameStatus
    { 
        Active,
        Win,
        GameOver
    }

    public interface IGameState
    {
        GameStatus Status { get; }
        bool IsGameActive { get; }

        void CheckWinCondition();
        void CheckLoseCondition();
        void SetStatus(GameStatus status);
    }
}
