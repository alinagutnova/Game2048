using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048
{
    public partial class MainForm : Form
    {
        Class2048 game;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            game = new Class2048(this);
            Width = Class2048.FieldSize * (70 + 5) + 30;
            Height = Class2048.FieldSize * (70 + 5) + 130;
            tsslBestScore.Text = game.BestScore.ToString();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (new Keys[] { Keys.Down, Keys.Up, Keys.Left, Keys.Right }.Contains(e.KeyCode))
            {
                if (!game.GameOver())
                {
                    game.KeyUp(sender, e);
                    lScore.Text = game.Score.ToString();
                }
                
                if (game.GameOver() || game.reached2048)
                {
                    string msg = (game.reached2048) ? "Вы выиграли! Красавчик!!!" : "Вы проиграли, но вам обязательно повезет в следующий раз.";
                    if (MessageBox.Show(msg+" Не хотите ли сыграть заново?", "Конец игры!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        game.Restart();
                        lScore.Text = game.Score.ToString();
                        tsslBestScore.Text = game.BestScore.ToString();
                    }
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void начатьЗановоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.Restart();
            lScore.Text = "0";
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.Save();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!game.Open()) MessageBox.Show("Не найдено сохраненных игр");
            else lScore.Text = game.Score.ToString();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings frm=new FormSettings();
            frm.ShowDialog();
            game.Restart();
            Width = Class2048.FieldSize * (70 + 5) + 30;
            Height = Class2048.FieldSize * (70 + 5) + 130;
            lScore.Text = "0";
        }
    }
}
