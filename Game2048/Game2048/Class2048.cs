using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Game2048
{
    public class Class2048
    {
        public CustomLabel[,] Field;
        public static int FieldSize = 4;
        public static Random random;
        private int filledCells;
        public bool reached2048;
        public int Score;
        private readonly string scoreFilename = "score.txt";
        private readonly string saveFilename = "game.txt";
        private Form parent;
        public int BestScore=0;

        public Class2048(Form parent)
        {
            random = new Random();
            this.parent = parent;
            Restart(true);
            //parent.KeyUp += KeyUp;
        }

        public void Restart(bool start=false)
        {
            Field = new CustomLabel[FieldSize, FieldSize];
            //удалить старые Customlabel и создать новые
            for (int i = 0; i < FieldSize; i++)
                for (int j = 0; j < FieldSize; j++)
                    if (start)
                        Field[i, j] = new CustomLabel(parent, i, j);
                    else 
                        Field[i, j].Text = String.Empty;
            GenerateNewCell();
            filledCells = 1;
            Score = 0;
            reached2048 = false;
            if (File.Exists(scoreFilename))
            {
                StreamReader sr = new StreamReader(scoreFilename);
                BestScore= int.Parse(sr.ReadLine());
                sr.Close();
            }
        }

        public void GenerateNewCell()
        {
            int number = 2;
            int n = random.Next(100);
            if (n >= 70) number = 4;

            int i = random.Next(FieldSize),
                j = random.Next(FieldSize);

            if (Field[i, j].Text == String.Empty)
                Field[i, j].Text = number.ToString();
            else GenerateNewCell();
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < FieldSize; i++)
                    for (int j = 0; j < FieldSize; j++)
                        if (Field[i, j].Text != String.Empty)
                            for (int k = j + 1; k < FieldSize; k++)
                                if (Field[i, k].Text != String.Empty)
                                {
                                    if (Field[i, j].Text == Field[i, k].Text)
                                    {
                                        int number = int.Parse(Field[i, k].Text);
                                        Field[i, j].Text = (number * 2).ToString();
                                        if (number * 2 == 2048) reached2048 = true;
                                        Field[i, k].Text = String.Empty;
                                        filledCells--;
                                        Score += number * 2;
                                    }
                                    break;
                                }
                for (int i = 0; i < FieldSize; i++)
                    for (int j = 0; j < FieldSize; j++)
                        if (Field[i, j].Text == String.Empty)
                            for (int k = j + 1; k < FieldSize; k++)
                                if (Field[i, k].Text != String.Empty)
                                {
                                    Field[i, j].Text = Field[i, k].Text;
                                    Field[i, k].Text = String.Empty;
                                    break;
                                }
            }
            if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < FieldSize; i++)
                    for (int j = FieldSize - 1; j >= 0; j--)
                        if (Field[i, j].Text != String.Empty)
                            for (int k = j - 1; k >= 0; k--)
                                if (Field[i, k].Text != String.Empty)
                                {
                                    if (Field[i, j].Text == Field[i, k].Text)
                                    {
                                        int number = int.Parse(Field[i, k].Text);
                                        Field[i, j].Text = (number * 2).ToString();
                                        if (number * 2 == 2048) reached2048 = true;
                                        Field[i, k].Text = String.Empty;
                                        filledCells--;
                                        Score += number * 2;
                                    }
                                    break;
                                }
                for (int i = 0; i < FieldSize; i++)
                    for (int j = FieldSize - 1; j >= 0; j--)
                        if (Field[i, j].Text == String.Empty)
                            for (int k = j - 1; k >= 0; k--)
                                if (Field[i, k].Text != String.Empty)
                                {
                                    Field[i, j].Text = Field[i, k].Text;
                                    Field[i, k].Text = String.Empty;
                                    break;
                                }
            }
            if (e.KeyCode == Keys.Up)
            {
                for (int j = 0; j < FieldSize; j++)
                    for (int i = 0; i < FieldSize; i++)
                        if (Field[i, j].Text != String.Empty)
                            for (int k = i + 1; k < FieldSize; k++)
                                if (Field[k, j].Text != String.Empty)
                                {
                                    if (Field[i, j].Text == Field[k, j].Text)
                                    {
                                        int number = int.Parse(Field[k, j].Text);
                                        Field[i, j].Text = (number * 2).ToString();
                                        if (number * 2 == 2048) reached2048 = true;
                                        Field[k, j].Text = String.Empty;
                                        filledCells--;
                                        Score += number * 2;
                                    }
                                    break;
                                }
                for (int j = 0; j < FieldSize; j++)
                    for (int i = 0; i < FieldSize; i++)
                        if (Field[i, j].Text == String.Empty)
                            for (int k = i + 1; k < FieldSize; k++)
                                if (Field[k, j].Text != String.Empty)
                                {
                                    Field[i, j].Text = Field[k, j].Text;
                                    Field[k, j].Text = String.Empty;
                                    break;
                                }
            }
            if (e.KeyCode == Keys.Down)
            {
                for (int j = 0; j < FieldSize; j++)
                    for (int i = FieldSize - 1; i >= 0; i--)
                        if (Field[i, j].Text != String.Empty)
                            for (int k = i - 1; k >= 0; k--)
                                if (Field[k, j].Text != String.Empty)
                                {
                                    if (Field[i, j].Text == Field[k, j].Text)
                                    {
                                        int number = int.Parse(Field[k, j].Text);
                                        Field[i, j].Text = (number * 2).ToString();
                                        if (number * 2 == 2048) reached2048 = true;
                                        Field[k, j].Text = String.Empty;
                                        filledCells--;
                                        Score += number * 2;
                                    }
                                    break;
                                }
                for (int j = 0; j < FieldSize; j++)
                    for (int i = FieldSize - 1; i >= 0; i--)
                        if (Field[i, j].Text == String.Empty)
                            for (int k = i - 1; k >= 0; k--)
                                if (Field[k, j].Text != String.Empty)
                                {
                                    Field[i, j].Text = Field[k, j].Text;
                                    Field[k, j].Text = String.Empty;
                                    break;
                                }
            }
            if (new Keys[] { Keys.Down, Keys.Up, Keys.Left, Keys.Right }.Contains(e.KeyCode))
            {
                if (filledCells<FieldSize*FieldSize)
                {
                    GenerateNewCell();
                    filledCells++;
                }
            }
        }

        public bool GameOver()
        {
            if (reached2048) {
                saveScore();
                return true;
            }
            if (filledCells < FieldSize * FieldSize) return false;
            //left
            for (int i = 0; i < FieldSize; i++)
                for (int j = 0; j < FieldSize; j++)
                    if (Field[i, j].Text != String.Empty)
                        for (int k = j + 1; k < FieldSize; k++)
                            if (Field[i, k].Text != String.Empty)
                            {
                                if (Field[i, j].Text == Field[i, k].Text)
                                    return false;
                                break;
                            }
            //right
            for (int i = 0; i < FieldSize; i++)
                for (int j = FieldSize - 1; j >= 0; j--)
                    if (Field[i, j].Text != String.Empty)
                        for (int k = j - 1; k >= 0; k--)
                            if (Field[i, k].Text != String.Empty)
                            {
                                if (Field[i, j].Text == Field[i, k].Text)
                                    return false;
                                break;
                            }
            //up
            for (int j = 0; j < FieldSize; j++)
                for (int i = 0; i < FieldSize; i++)
                    if (Field[i, j].Text != String.Empty)
                        for (int k = i + 1; k < FieldSize; k++)
                            if (Field[k, j].Text != String.Empty)
                            {
                                if (Field[i, j].Text == Field[k, j].Text)
                                    return false;
                                break;
                            }
            //down
            for (int j = 0; j < FieldSize; j++)
                for (int i = FieldSize - 1; i >= 0; i--)
                    if (Field[i, j].Text != String.Empty)
                        for (int k = i - 1; k >= 0; k--)
                            if (Field[k, j].Text != String.Empty)
                            {
                                if (Field[i, j].Text == Field[k, j].Text)
                                    return false;
                                break;
                            }
            saveScore();
            return true;
        }

        private void saveScore()
        {
            if (Score > BestScore)
            {
                StreamWriter sw = new StreamWriter(scoreFilename);
                sw.WriteLine(Score);
                sw.Close();
            }
        }

        public void Save()
        {
            StreamWriter sw = new StreamWriter(saveFilename);
            sw.WriteLine(FieldSize+" "+Score);
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                    sw.Write(Field[i, j].Text+" ");
                sw.WriteLine();
            }
            sw.Close();
        }

        public bool Open()
        {
            if (!File.Exists(saveFilename)) return false;
            StreamReader sr = new StreamReader(saveFilename);
            string[] row = sr.ReadLine().Split();
            FieldSize = int.Parse(row[0]);
            Score = int.Parse(row[1]);
            filledCells = 0;
            reached2048 = false;
            for (int i = 0; i < FieldSize; i++)
            {
                row = sr.ReadLine().Split();
                for (int j = 0; j < FieldSize; j++)
                {
                    Field[i, j].Text = row[j];
                    if (row[j] != String.Empty) filledCells++;
                    if (row[j] == "2048") reached2048 = true;
                }
            }
            sr.Close();
            return true;
        }
    }
}
