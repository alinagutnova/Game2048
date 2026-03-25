using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public class Game2048 : IGame2048
    {
        private readonly ICellManager _cellManager;
        private readonly IScoreManager _scoreManager;
        private readonly IGameState _gameState;
        private int[,] _board;

        public int Size => 4;
        public int[,] Board => _board;
        public int Score => _scoreManager.CurrentScore;
        public bool IsGameOver => _gameState.Status == GameStatus.GameOver;
        public bool IsWin => _gameState.Status == GameStatus.Win;

        public Game2048(ICellManager cellManager, IScoreManager scoreManager, IGameState gameState)
        {
            _cellManager = cellManager;
            _scoreManager = scoreManager;
            _gameState = gameState;
            _board = new int[Size, Size];
        }

        public void Init()
        { 
            Array.Clear(_board, 0, Size);
            _scoreManager.ResetScore();
            _gameState.SetStatus(GameStatus.Active);
            _cellManager.AddRandomCell();
            _cellManager.AddRandomCell();
        }

        public void Move(Direction direction)
        {
            if (!_gameState.IsGameActive) return;
            bool moved = false;
            switch (direction)
            { 
                case Direction.Left: moved = MoveLeft(); break;
                case Direction.Right: moved = MoveRight(); break;
                case Direction.Up: moved = MoveUp(); break;
                case Direction.Down: moved = MoveDown(); break;
            }

            if (moved)
            {
                _cellManager.AddRandomCell();
                _gameState.CheckWinCondition();
                _gameState.CheckLoseCondition();
            }
        }

        public void Reset()
        { 
            Init();
        }

        public bool MoveLeft()
        {
            bool moved = false;
            //вставить код из основной программы
            return moved;
        }
        //MoveRight();
        //MoveUp();
        //MoveDown();
    }
}
