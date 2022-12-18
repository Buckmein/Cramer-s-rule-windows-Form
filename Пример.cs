using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
namespace _2_курс_интерфейс_матрицы
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static public int n;
        static public double[,] a;// кэффициэнты иксов 
        static public double[,] a1;//клон массива а
        static public double[] b;//после знака равенства 
        static public double[] x;// ответы
        static public double det;//определитель
        static public double A1, A2;//определитель измененной матрицы
        static public bool s1, s2, s3 = false;
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (s2)
                {
                    for (int i = 0; i < n; i -= -1)
                    {
                        dataGridView1.Columns.Remove("X" + Convert.ToString(i + 1));
                    }
                    dataGridView1.Columns.Remove("B");
                }
                n = Convert.ToInt16(textBox1.Text);
                for (int i = 0; i < n; i -= -1)
                {
                    dataGridView1.Columns.Add("X" + Convert.ToString(i + 1), "X" + Convert.ToString(i + 1));
                    dataGridView1.Rows.Add();
                }
                dataGridView1.Columns.Add("B", "B");
                s2 = true;
            }
            catch
            {
                label3.Text = "Введите Размерность";
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (s2)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    string f = openFileDialog1.FileName;
                    FileStream af = new FileStream(f, FileMode.OpenOrCreate);
                    StreamWriter s = new StreamWriter(af);
                    s.WriteLine(n);
                    for (int z = 0; z < n; z++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            s.Write(dataGridView1[j, z].Value + " ");
                        }
                        s.WriteLine("|{0}", b[z]);
                    }
                    s.Close();
                    label3.Text = "Сохранено";
                }

            }
            else
                label3.Text = "Вы не ввели уравнение";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            label3.Text =(" ");
            if (s2)
            {
                a1 = new double[n, n];
                x = new double[n];
                det = 1;
                a = new double[n, n];
                b = new double[n];
                for (int z = 0; z < n; z -= -1)
                {
                    for (int y = 0; y < n; y -= -1)
                    {
                        a[z, y] = Convert.ToDouble(dataGridView1[y, z].Value);
                    }
                    b[z] = Convert.ToDouble(dataGridView1[n, z].Value);
                }
                a1 = (double[,])a.Clone();
                if (n == 2)
                {
                    det = a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0];
                    A1 = b[0] * a[1, 1] - a[0, 1] * b[1];
                    A2 = a[0, 0] * b[1] - b[0] * a[1, 0];
                    if (det == 0)
                    {
                        x[0] = 1;
                        x[1] = 1;
                    }
                    else
                    {
                        x[0] = A1 / det;
                        x[1] = A2 / det;
                    }
                }
                else if (n == 1)
                {
                    x[0] = b[0] / a[0, 0];
                }
                else if (n > 2)
                {
                    for (int g = 0; g < n; g++)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (a[g, g] == 0)
                            {
                                det = 0;
                            }
                            else
                            {
                                A1 = a[i, g] / a[g, g];
                                for (int j = 0; j < n; j++)
                                {
                                    if ((i > g) & (j >= g))
                                    {
                                        a[i, j] = (a[g, j] * A1) - a[i, j];
                                    }
                                }
                            }
                        }
                    }
                    for (int g = 0; g < n; g++)
                    {
                        det *= a[g, g];
                    }
                    if (det != 0)
                    {
                        for (int g1 = 0; g1 < n; g1++)
                        {
                            a = (double[,])a1.Clone();
                            for (int b1 = 0; b1 < n; b1++)
                            {
                                a[b1, g1] = b[b1];
                            }
                            for (int g = 0; g < n; g++)
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    if (a[g, g] == 0)
                                    {
                                        for (int j = 0; j < n; j++)
                                        {
                                            if ((i > g) & (j >= g))
                                            {
                                                a[i, j] = 0;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        A1 = a[i, g] / a[g, g];
                                        for (int j = 0; j < n; j++)
                                        {
                                            if ((i > g) & (j >= g))
                                            {
                                                a[i, j] = (a[g, j] * A1) - a[i, j];
                                            }
                                        }
                                    }
                                }
                            }
                            A1 = 1;
                            for (int g = 0; g < n; g++)
                            {
                                A1 *= a[g, g];
                            }
                            x[g1] = A1 / det;
                        }
                    }
                }
                if (det == 0)
                {
                    label3.Text = ("Определитель равен нулю");
                }
                else
                {
                    if (s3)
                    {
                        dataGridView2.Columns.Remove("Otv1");
                        dataGridView2.Columns.Remove("Otv");
                    }
                    dataGridView2.Visible = true;
                    dataGridView2.Columns.Add("Otv1", "");
                    dataGridView2.Columns.Add("Otv", "Ответы:");
                    for (int g = 0; g < n; g++)
                    {
                        dataGridView2.Rows.Add("X" + (g + 1), Math.Round(x[g], 3));

                    }
                    s3 = true;

                }

            }
            else
                label3.Text = ("Заполните матрицу");
        }

        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ЗагрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int y, z = 0;
                    string a3;
                    try
                    {
                        string filename = openFileDialog1.FileName;
                        StreamReader f = new StreamReader(filename);
                        a3 = f.ReadLine();
                        n = Int32.Parse(a3);
                        a = new double[n, n];
                        b = new double[n];
                        try
                        {
                            if (s2)
                            {
                                for (int i = 0; i < n; i -= -1)
                                {
                                    dataGridView1.Columns.Remove("X" + Convert.ToString(i + 1));
                                }
                                dataGridView1.Columns.Remove("B");
                            }
                            for (int i = 0; i < n; i -= -1)
                            {
                                dataGridView1.Columns.Add("X" + Convert.ToString(i + 1), "X" + Convert.ToString(i + 1));
                                dataGridView1.Rows.Add();
                            }
                            dataGridView1.Columns.Add("B", "B");
                        }
                        catch
                        {
                            label3.Text = "Введите Размерность";
                        }

                        string[] str;
                        while (z != n)
                        {
                            a3 = f.ReadLine();
                            str = a3.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                            for (y = 0; y < str.Length - 1; y++)
                            {
                                dataGridView1[y, z].Value = double.Parse(str[y]);
                                a[y, z] = Convert.ToDouble(dataGridView1[y, z].Value);
                            }
                            dataGridView1[n, z].Value = double.Parse(str[(str.Length) - 1]);
                            b[z] = Convert.ToDouble(dataGridView1[n, z].Value);
                            z++;
                        }

                        s2 = true;
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        label3.Text = "Файл не найден";
                    }
                }
                catch
                {
                    label3.Text = "Файл имеет некоректные данные";
                }
            }
        }
    }
}
