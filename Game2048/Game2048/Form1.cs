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
    public partial class Form1 : Form
    {
        public const int maxSize = 4;
        Dictionary<string, Color> cellColors = new Dictionary<string, Color>
        {
            {"", Color.Gray },
            {"2", Color.Green },
            {"4", Color.Gold },
            {"8", Color.Indigo },
            {"16", Color.GreenYellow }
        };
        public Label[,] Field;
        public int Count;
        Random rnd;

        public Form1()
        {
            InitializeComponent();
            Field = new Label[maxSize, maxSize];
            rnd = new Random();
            Count = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitGame();
            StartGame();
        }

        public void InitGame()
        {
            for (int i = 0; i < maxSize; i++)
                for (int j = 0; j < maxSize; j++)
                {
                    Label label = new Label();
                    label.BackColor = cellColors[""];
                    label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    label.Size = new System.Drawing.Size(70, 70);
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    label.Location = new System.Drawing.Point(10 + j * 76, 70 + i * 76);
                    this.Controls.Add(label);
                    Field[i, j] = label;
                }
        }

        public void StartGame()
        {
            PutNumber(2);
            PutNumber((rnd.Next(2)+1)*2);
        }

        public void PutNumber(int number)
        {
            while (true)
            {
                int n = rnd.Next(maxSize * maxSize);
                int i = n / maxSize;
                int j = n % maxSize;
                if (Field[i, j].Text.Length == 0)
                {
                    Field[i, j].Text = number.ToString();
                    Field[i, j].BackColor = cellColors[number.ToString()];
                    break;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < maxSize; i++)
                {
                    for (int j = maxSize - 2; j >= 0; j--)
                    {
                        if (Field[i, j].Text.Length > 0)
                        {
                            int pos = j;
                            while (pos + 1 < maxSize && Field[i, pos + 1].Text.Length == 0)
                                pos++;
                            if (pos != j) 
                            {
                                if (pos+1<maxSize && Field[i, j].Text == Field[i, pos+1].Text)
                                {
                                    pos++;
                                    Field[i, pos].Text = (2 * Convert.ToInt32(Field[i, j].Text)).ToString();
                                } else Field[i, pos].Text = Field[i, j].Text;
                                Field[i, pos].BackColor = cellColors[Field[i, pos].Text];
                                Field[i, j].Text = "";
                                Field[i, j].BackColor = cellColors[Field[i, j].Text];
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Left)
                MessageBox.Show("налево");
            if (e.KeyCode == Keys.Up)
                MessageBox.Show("вверх");
            if (e.KeyCode == Keys.Down)
                MessageBox.Show("вниз");
            PutNumber(2);
        }
    }
}
