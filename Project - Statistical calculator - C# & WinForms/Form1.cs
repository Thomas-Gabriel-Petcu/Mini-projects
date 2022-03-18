using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Calcul_statistic___Proiect_Petcu_Thomas_Gabriel
{
    public partial class Form1 : Form
    {
        Form1 form1;
        Form2 form2;
        int posVert = 200;
        int posOriz = 0;
        TextBox[] txtBoxArray;
        Label[] categoryLabels;
        Label[] labels = new Label[7];
        int[] data;
        bool initialized = false;
        DataStruct dataStruct;
        bool created = false;
        public Form1()
        {
            InitializeComponent();
            form1 = this;
            form2 = new Form2();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Label DynamicLabel(string nume, Point locatie, string text)
        {
            Label dynLabel = new Label();
            this.Controls.Add(dynLabel);
            dynLabel.AutoSize = true;
            dynLabel.Name = nume;
            dynLabel.Location = locatie;
            dynLabel.Text = text;
            dynLabel.BackColor = Color.White;
            dynLabel.Font = new Font("Georgia", 12);
            return dynLabel;
        }

        private TextBox CreateDynamicTextbox(string nume, Point locatie, string text)
        {
            TextBox dynTxtBox = new TextBox();
            this.Controls.Add(dynTxtBox);
            dynTxtBox.Name = nume;
            dynTxtBox.Location = locatie;
            dynTxtBox.Text = text;
            dynTxtBox.BackColor = Color.White;
            dynTxtBox.Font = new Font("Georgia", 12);
            return dynTxtBox;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (created == true)
            {
                Random rand = new Random();
                int x;
                for (int i = 0; i < txtBoxArray.Length; i++)
                {
                    x = rand.Next(0, 100);
                    txtBoxArray[i].Text = x.ToString();
                }
            }
            else
            {
                MessageBox.Show("Casetele de date nu exista.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count != 0)
            {
                if (initialized == false)
                {
                    CreateResultLabels();
                    initialized = true;
                }
                InitializingData();
                Calculate();
            }
            else
            {
                MessageBox.Show("Nu exista date de calculat.");
            }
        }
        private void Calculate()
        {
            string s = "";
            int[] array = SortAsc();
            for (int i = 0; i < array.Length; i++)
            {
                s += " " + array[i];
            }
            dataStruct.average = SimpleArithmeticMean().ToString();
            dataStruct.ascOrder = s;
            dataStruct.median = FindMedian(array).ToString();
            dataStruct.mode = Modul().ToString();
            dataStruct.q1 = Q1Value(array).ToString();
            dataStruct.q2 = dataStruct.median;
            dataStruct.q3 = Q3Value(array).ToString();

            labels[0].Text = $"Media aritmetica simpla este: {dataStruct.average}";
            labels[1].Text = $"Colectia ordonata crescator este: {s}";
            labels[2].Text = $"Mediana este: {dataStruct.median}";
            labels[3].Text = $"Modul este: {dataStruct.mode}";
            labels[4].Text = $"valoarea quartilei mici este {dataStruct.q1}";
            labels[5].Text = $"valoarea quartilei mijlocii este {dataStruct.q2}";
            labels[6].Text = $"Valoarea quartilei mari este {dataStruct.q3}";
        }
        private void InitializingData()
        {
            data = new int[txtBoxArray.Length];//vector de tip int unde stocam datele sirului
            for (int i = 0; i < txtBoxArray.Length; i++)
            {
                if (!int.TryParse(txtBoxArray[i].Text, out data[i]))
                {
                    MessageBox.Show($"Valoarea introdusa in caseta {i + 1} nu este un numar intreg. S-a trecut la valoarea implicita 0");
                    data[i] = 0;
                    txtBoxArray[i].Text = "0";
                }
            }
        }
        private void CreateResultLabels()
        {
            labels[0] = DynamicLabel("result1", new Point(50, 300), "");
            labels[1] = DynamicLabel("result2", new Point(50, 320), "");
            labels[2] = DynamicLabel("result3", new Point(50, 340), "");
            labels[3] = DynamicLabel("result4", new Point(50, 360), "");
            labels[4] = DynamicLabel("result5", new Point(50, 380), "");
            labels[5] = DynamicLabel("result6", new Point(50, 400), "");
            labels[6] = DynamicLabel("result7", new Point(50, 420), "");
        }
        private double SimpleArithmeticMean()
        {
            double average = 0;
            for (int i = 0; i < data.Length; i++)
            {
                average += data[i];
            }
            average /= data.Length;
            return average;
        }
        private double FindMedian(int[] dataBuffer)
        {
            if (dataBuffer.Length % 2 == 0)//numar par de date
            {
                double median = (dataBuffer[dataBuffer.Length / 2] + dataBuffer[(dataBuffer.Length / 2) - 1])/2.0;
                return median;
            }
            else//numar impar de date
            {
                double median = dataBuffer[dataBuffer.Length/2];
                return median;
            }
        }
        private int[] SortAsc()
        {
            int[] dataBuffer = new int[data.Length];
            for (int i = 0; i < dataBuffer.Length; i++)
            {
                dataBuffer[i] = data[i];
            }

            for (int i = 0; i < dataBuffer.Length; i++)
            {
                for (int j = i + 1; j < dataBuffer.Length; j++)
                {
                    if (dataBuffer[i]> dataBuffer[j])
                    {
                        int value = dataBuffer[j];
                        dataBuffer[j] = dataBuffer[i];
                        dataBuffer[i] = value;
                    }
                }
            }
            return dataBuffer;
        }
        private int Modul()
        {
            int count = 1;
            int[] array = SortAsc();
            List<int> uniques = new List<int>();
            List<int> values = new List<int>();
            for (int i = 1; i < array.Length + 1; i++)
            {
                Debug.WriteLine($"element at index {i - 1} is {array[i -1]}");
                if (!uniques.Contains(array[i - 1]))
                {
                    uniques.Add(array[i - 1]);
                }
                if (i < array.Length && array[i] == array[i - 1])
                {
                    count++;
                }
                else
                {
                    values.Add(count);
                    count = 1;
                }
            }
            for (int i = 1; i < values.Count + 1; i++)
            {
                if (i < values.Count && values[i] > values[i - 1])
                {
                    //ordering the numbers representing how many times each unique value is present
                    int buffer = values[i - 1];
                    values[i - 1] = values[i];
                    values[i] = buffer;
                    //ordering the unique numbers so that index matching still works
                    int uniquesBuffer = uniques[i - 1];
                    uniques[i - 1] = uniques[i];
                    uniques[i] = uniquesBuffer;
                }
            }
            string s = "";
            for (int i = 0; i < values.Count; i++)
            {
                s += " " + values[i];
            }
            Debug.WriteLine(s);
            string str = "";
            for (int i = 0; i < uniques.Count; i++)
            {
                str += " " + uniques[i];
            }
            Debug.WriteLine(str);
            return uniques[0];
        }
        private double Q1Value(int[] array)
        {
            int index = 0;
            index = ((array.Length + 1) * 1 / 4) - 1;
            Debug.WriteLine(index);
            double q1 = array[index];
            return q1;
        }
        private double Q3Value(int[] array)
        {
            int index = 0;
            if (array.Length % 2 == 0)
            {
                index = (array.Length + 1) * 3 / 4;
            }
            else
            {
                index = ((array.Length + 1) * 3 / 4) - 1;
            }
            Debug.WriteLine(index);
            double q3 = array[index];
            return q3;
        }

        struct DataStruct
        {
            public string average;
            public string ascOrder;
            public string median;
            public string mode;
            public string q1;
            public string q2;
            public string q3;
        }

        static DataStruct GenerateLoadData(string load)
        {
            string[] fileText = load.Split(';');
            for (int i = 0; i < fileText.Length; i++)
            {
                Debug.WriteLine(fileText[i]);
            }
            DataStruct data;
            data.average = fileText[0];
            data.ascOrder = fileText[1];
            data.median = fileText[2];
            data.mode = fileText[3];
            data.q1 = fileText[4];
            data.q2 = fileText[5];
            data.q3 = fileText[6];

            return data;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (initialized == true)
            {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                StreamWriter sw = new StreamWriter(Path.GetFullPath(saveFileDialog1.FileName));
                sw.Write(dataStruct.average + ';' + dataStruct.ascOrder + ';' + dataStruct.median +
                ';' + dataStruct.mode + ';' + dataStruct.q1 + ';' + dataStruct.q2 + ';' + dataStruct.q3);
                sw.Close();
            }
            }
            else
            {
                MessageBox.Show("Nu exista date ce pot fi salvate.");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                DataStruct loadData = GenerateLoadData(File.ReadAllText(Path.GetFullPath(openFileDialog1.FileName)));

                if (initialized == true)
                {
                    labels[0].Text = $"Media aritmetica simpla este: {loadData.average}";
                    labels[1].Text = $"Colectia ordonata crescator este: {loadData.ascOrder}";
                    labels[2].Text = $"Mediana este: {loadData.median}";
                    labels[3].Text = $"Modul este: {loadData.mode}";
                    labels[4].Text = $"valoarea quartilei mici este {loadData.q1}";
                    labels[5].Text = $"valoarea quartilei mijlocii este {loadData.q2}";
                    labels[6].Text = $"Valoarea quartilei mari este {loadData.q3}";
                    dataStruct = loadData;
                }
                else
                {
                    CreateResultLabels();
                    labels[0].Text = $"Media aritmetica simpla este: {loadData.average}";
                    labels[1].Text = $"Colectia ordonata crescator este: {loadData.ascOrder}";
                    labels[2].Text = $"Mediana este: {loadData.median}";
                    labels[3].Text = $"Modul este: {loadData.mode}";
                    labels[4].Text = $"valoarea quartilei mici este {loadData.q1}";
                    labels[5].Text = $"valoarea quartilei mijlocii este {loadData.q2}";
                    labels[6].Text = $"Valoarea quartilei mari este {loadData.q3}";
                    dataStruct = loadData;
                    initialized = true;
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "")
            {
                comboBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Input invalid");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                comboBox1.Items.Remove(comboBox1.SelectedItem);
                comboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Nu ati selectat niciun element pentru stergere.");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "")
            {
                if (comboBox1.SelectedIndex > -1)
                {
                    if ((string)comboBox1.Items[comboBox1.SelectedIndex] != textBox1.Text)
                    {
                        comboBox1.Items[comboBox1.SelectedIndex] = textBox1.Text;
                    }
                    else
                    {
                        MessageBox.Show("Inputul este identic cu selectia.");
                    }
                }
                else
                {
                    MessageBox.Show("Nu ati selectat niciun element pentru a fi modificat.");
                }
            }
            else
            {
                MessageBox.Show("Nu ati introdus nicio valoare in caseta de text.");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "")
            {
                if (label2.Text != textBox1.Text)
                {
                    label2.Text = textBox1.Text;
                }
                else
                {
                    MessageBox.Show("Inputul este identic cu numele actual al colectiei.");
                }
            }
            else
            {
                MessageBox.Show("Nu ati introdus nicio valoare in caseta de text.");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (created == false && comboBox1.Items.Count != 0)
            {
            categoryLabels = new Label[comboBox1.Items.Count];
            txtBoxArray = new TextBox[comboBox1.Items.Count];
            
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                posOriz += 110;
                categoryLabels[i] = DynamicLabel("dynLabel" + i, new Point(posOriz, posVert), (string)comboBox1.Items[i]);
                txtBoxArray[i] = CreateDynamicTextbox("dynTxtBox" + i, new Point(posOriz, posVert + 30), (string)comboBox1.Items[i]);
                Controls.Add(categoryLabels[i]);
                Controls.Add(txtBoxArray[i]);
            }
                created = true;
            }
            else
            {
                MessageBox.Show("Nu exista elemente in lista.");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
                form1.Hide();
                form2.Reset();
        }
    }
}
