﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class NotepadForm : System.Windows.Forms.Form
    {
        public NotepadForm()
        {
            InitializeComponent();
            Init();
        }

        public string namefile;
        public bool changefile; //изменения в файле

        public void Init() //инициализация изначального файла
        {
            namefile = "";
            changefile = false;
            UpdateName();
        }


    //кнопки меню

        //создать
        public void CreateDocument(object sender, EventArgs arg)
        {
            maintextBox.Text = "";
            namefile = "";
            UpdateName();
            SaveUnSave();
            changefile = false;
        }

        //открыть...
        public void OpenFile(object sender, EventArgs arg) 
        {
            SaveUnSave();
            openFileDialog1.FileName = "";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader stri = new StreamReader(openFileDialog1.FileName);
                    maintextBox.Text = stri.ReadToEnd();
                    stri.Close();
                    namefile = openFileDialog1.FileName;
                    changefile = false;
                }
                catch
                {
                    MessageBox.Show("невозможно открыть данный файл");
                }
            }
            UpdateName();
        }

        public void SaveFile(string _name, Encoding encoding)   //метод для дальнейшего сохранения
        {
            if(_name == "")
            {
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _name = saveFileDialog1.FileName;
                }
            }
            try //запишем весь текст в файл
            {
                StreamWriter strw = new StreamWriter(_name + ".txt", false, encoding); //стандартная UTF-8
                strw.Write(maintextBox.Text);
                strw.Close();
                namefile = _name;
                changefile = false; //не изменен т.к сохранили
            }
            catch
            {
                MessageBox.Show("файл нельзя сохранить");
            }
            UpdateName();
        }
        
        
        //просто сохранить
        public void Save(object sender, EventArgs arg)
        {
            SaveFile(namefile, UTF8Encoding.UTF8);
        }
        
        

        private void OnTextChange(object sender, EventArgs arg) //добавление звездочки
        {
            if (!changefile)
            {
                changefile = true;
                this.Text = this.Text.Replace("*", " ");
                this.Text = "*" + this.Text;
            } 
        }
        

        private void UpdateName()//название в заголовке
        {
            if (namefile != "")
                this.Text = namefile + "-Блокнот";
            else
                this.Text = "Безымянный - Блокнот";
        }
        
        private void SaveUnSave()  //проверка на сохранение
        {
            if (changefile)
            {
                DialogResult res = MessageBox.Show("Сохранить изменения в файле?", "Сохранение файла", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (res == DialogResult.Yes)
                    SaveFile(namefile, UTF8Encoding.UTF8 );
            }
        }

        //сохранить в кодировке...
        private void uTF32ToolStripMenuItem_Click(object sender, EventArgs e)//UTF16 LE
        {
            SaveFile(namefile, UTF32Encoding.UTF32);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveUnSave(); 
            this.Close();
        }

        
    }
}
