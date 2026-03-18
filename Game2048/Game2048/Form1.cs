using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048
{
    public partial class Form1 : Form
    {
        public const int maxSize = 4;
        public int steps = 0;
        public int count = 0;
        Dictionary<string, Color> cellColors = new Dictionary<string, Color>
        {
            {"", Color.Gray },
            {"2", Color.Beige },
            {"4", Color.Orchid },
            {"8", Color.Orange },
            {"16", Color.DarkOrange },
            {"32", Color.OrangeRed },
            {"64", Color.Red },
            {"128", Color.Yellow },
            {"256", Color.Salmon },
            {"512", Color.DarkSalmon },
            {"1024", Color.LightGoldenrodYellow },
            {"2048", Color.Gold }
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
            count = 0;
            steps = 0;
            lSteps.Text = $"Ходов: {steps}";
            lCount.Text = $"Очков: {count}";
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
                    SetNumber(i, j, number.ToString());
                    break;
                }
            }
        }

        public int isGameOver()
        {
            /*
            return: 0 - игра не окончена
                    1 - мы выиграли
                    2 - мы проиграли
            */
            bool fl = false;
            for (int i = 0; i < maxSize; i++)
                for (int j = 0; j < maxSize; j++)
                {
                    if (Field[i, j].Text == string.Empty) fl=true;
                    if (Field[i, j].Text == "32") return 1;
                }
            if (fl) return 0;
            return 2;
        }

        public void SetNumber(int i, int j, string number)
        {
            Field[i, j].Text = number;
            Field[i, j].BackColor = cellColors[number];
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            List<Keys> keySet = new List<Keys>{ Keys.Right, Keys.Left, Keys.Up, Keys.Down };
            if (e.KeyCode == Keys.Right)
                Right();
            if (e.KeyCode == Keys.Left)
                Left();
            if (e.KeyCode == Keys.Up)
                Up();
            if (e.KeyCode == Keys.Down)
                Down();
            if (keySet.Contains(e.KeyCode))
            {
                steps++;
                lSteps.Text = $"Ходов: {steps}";
                int n = isGameOver();
                if (n == 1)
                {
                    if (MessageBox.Show("Вы выиграли. Хотите ли сыграть заново?",
                                    "Игра окончена",
                                    MessageBoxButtons.YesNo) == DialogResult.No)
                        Close();
                    else Restart();
                }
                else if (n == 2)
                {
                    if (MessageBox.Show("Вы проиграли. Хотите ли сыграть заново?",
                                    "Игра окончена",
                                    MessageBoxButtons.YesNo) == DialogResult.No)
                        Close();
                    else Restart();
                } else
                    PutNumber(2);
            }
        }

        public void Restart()
        {
            for (int i = 0; i < maxSize; i++)
                for (int j = 0; j < maxSize; j++)
                    SetNumber(i, j, "");
            StartGame();
        }

        public void Down()
        {
            for (int j = 0; j < maxSize; j++)
            {
                for (int i = maxSize - 1; i >= 0; i--)
                {
                    if (Field[i, j].Text != string.Empty)
                    {
                        for (int k = i - 1; k >= 0; k--)
                            if (Field[k, j].Text != string.Empty)
                            {
                                if (Field[i, j].Text == Field[k, j].Text)
                                {
                                    int number = Convert.ToInt32(Field[i, j].Text);
                                    SetNumber(i, j, (number * 2).ToString());
                                    SetNumber(k, j, "");
                                    count+=2*number;
                                    lCount.Text = $"Очков: {count}";
                                }
                                break;
                            }
                    }
                }
            }

            for (int j = 0; j < maxSize; j++)
            {
                for (int i = maxSize-1; i>=0; i--)
                {
                    if (Field[i, j].Text == string.Empty)
                    {
                        for (int k = i - 1; k >=0; k--)
                            if (Field[k, j].Text != string.Empty)
                            {
                                SetNumber(i, j, Field[k, j].Text);
                                SetNumber(k, j, "");
                                break;
                            }
                    }
                }
            }

        }

        public void Up()
        {
            for (int j = 0; j < maxSize; j++)
            { 
                for (int i = 0; i < maxSize; i++)
                {
                    if (Field[i, j].Text != string.Empty)
                    {
                        for (int k = i + 1; k < maxSize; k++)
                            if (Field[k, j].Text != string.Empty)
                            {
                                if (Field[i, j].Text == Field[k, j].Text)
                                {
                                    int number = Convert.ToInt32(Field[i, j].Text);
                                    SetNumber(i, j, (number * 2).ToString());
                                    SetNumber(k, j, "");
                                    count += 2*number;
                                    lCount.Text = $"Очков: {count}";
                                }
                                break;
                            }
                    }
                }
            }

            for (int j = 0; j < maxSize; j++)
            {
                for (int i = 0; i < maxSize; i++)
                {
                    if (Field[i, j].Text == string.Empty)
                    {
                        for (int k = i + 1; k < maxSize; k++)
                            if (Field[k, j].Text != string.Empty)
                            {
                                SetNumber(i, j, Field[k, j].Text);
                                SetNumber(k, j, "");
                                break;
                            }
                    }
                }
            }

        }

        public void Left()
        {
            for (int i = 0; i < maxSize; i++)
            {
                for (int j = 0; j < maxSize; j++)
                {
                    if (Field[i, j].Text != string.Empty)
                    {
                        for (int k = j + 1; k < maxSize; k++)
                            if (Field[i, k].Text != string.Empty)
                            {
                                if (Field[i, j].Text == Field[i, k].Text)
                                {
                                    int number = Convert.ToInt32(Field[i, j].Text);
                                    SetNumber(i, j, (number * 2).ToString());
                                    SetNumber(i, k, "");
                                    count += 2*number;
                                    lCount.Text = $"Очков: {count}";
                                }
                                break;
                            }
                    }
                }
            }

            for (int i = 0; i < maxSize; i++)
            {
                for (int j = 0; j < maxSize; j++)
                {
                    if (Field[i, j].Text == string.Empty)
                    {
                        for (int k = j + 1; k < maxSize; k++)
                            if (Field[i, k].Text != string.Empty)
                            {
                                SetNumber(i, j, Field[i, k].Text);
                                SetNumber(i, k, "");
                                break;
                            }
                    }
                }
            }
        }

        public void Right()
        {
            for (int i = 0; i < maxSize; i++)
            {
                for (int j = maxSize - 1; j >= 0; j--)
                {
                    if (Field[i, j].Text != string.Empty)
                    {
                        for (int k = j - 1; k >= 0; k--)
                            if (Field[i, k].Text != string.Empty)
                            {
                                if (Field[i, j].Text == Field[i, k].Text)
                                {
                                    int number = Convert.ToInt32(Field[i, j].Text);
                                    SetNumber(i, j, (number * 2).ToString());
                                    SetNumber(i, k, "");
                                    count += 2*number;
                                    lCount.Text = $"Очков: {count}";
                                }
                                break;
                            }
                    }
                }
            }

            for (int i = 0; i < maxSize; i++)
            {
                for (int j = maxSize - 1; j >= 0; j--)
                {
                    if (Field[i, j].Text == string.Empty)
                    {
                        for (int k = j - 1; k >= 0; k--)
                            if (Field[i, k].Text != string.Empty)
                            {
                                SetNumber(i, j, Field[i, k].Text);
                                SetNumber(i, k, "");
                                break;
                            }
                    }
                }
            }
        }
    }
}
