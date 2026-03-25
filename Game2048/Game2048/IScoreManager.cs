using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public interface IScoreManager
    {
        int CurrentScore { get; }
        void AddScore(int value);
        void ResetScore();
    }
}
