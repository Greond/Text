using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Text__changer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.ContextMenuStrip = contextMenuStrip1;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void open_file_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //Проверяем был ли выбран файл
            {
                richTextBox1.Clear(); //Очищаем richTextBox
                openFileDialog1.Filter = "Text Files (*.txt)|*.txt"; //Указываем что нас интересуюттолько текстовые файлы
              string fileName = openFileDialog1.FileName; //получаем наименование файл и путь кнему.
                richTextBox1.Text = File.ReadAllText(fileName, Encoding.GetEncoding(1251)); //Передаемсодержимое файла в richTextBox
}

        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";//Задаем доступные расширения
            saveFileDialog1.DefaultExt = ".txt"; //Задаем расширение по умолчанию
            
             if (saveFileDialog1.ShowDialog() == DialogResult.OK) //Проверяем подтверждениесохранения информации.
{
                var name = saveFileDialog1.FileName; //Задаем имя файлу
                File.WriteAllText(name, richTextBox1.Text, Encoding.GetEncoding(1251)); //Записываемв файл содержимое textBox с кодировкой 1251
}
            richTextBox1.Clear();

        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void предваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            richTextBox1.SelectedText = "";
            richTextBox1.DeselectAll();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void поЛевомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectedText != "")
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            }
            else
            {
                richTextBox1.SelectAll();
                richTextBox1.SelectionAlignment= HorizontalAlignment.Left;
            }
        }

        private void поПравомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            }
            else
            {
                richTextBox1.SelectAll();
                richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        private void поЦентруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
            else
            {
                richTextBox1.SelectAll();
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font myFont = new Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Pixel);
            string Hello = "Hello World!";
            e.Graphics.DrawString(Hello, myFont, Brushes.Black, 20, 20);
        }

        private void настройкаПринтераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void печатьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK) 
                printDocument1.Print();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutprogram = new AboutBox1();
            aboutprogram.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            
            richTextBox1.Clear();

        }

        private void choose_button_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Color_button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                
                    richTextBox1.SelectionColor = colorDialog1.Color;
                
               
            }

            //test repositoriy
        }

        private void font_button_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }
    }
}
