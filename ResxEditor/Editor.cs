﻿#if (WIN32)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ResxEditor
{
    public partial class Editor : Form
    {
        public Editor(string text)
        {
            InitializeComponent();
            textBox1.Text = text;
            textBox1_TextChanged(textBox1, null);
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            }
        }

        public string TextEdited
        {
            get
            {
                return textBox1.Text;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && textBox1.Text != "")
            {
                IList<string> arabicAlpha = new List<string>();
                arabicAlpha.Add("ذ");
                arabicAlpha.Add("ض");
                arabicAlpha.Add("ص");
                arabicAlpha.Add("ث");
                arabicAlpha.Add("ق");
                arabicAlpha.Add("ف");
                arabicAlpha.Add("غ");
                arabicAlpha.Add("ع");
                arabicAlpha.Add("ه");
                arabicAlpha.Add("خ");
                arabicAlpha.Add("ح");
                arabicAlpha.Add("ج");
                arabicAlpha.Add("د");
                arabicAlpha.Add("ط");
                arabicAlpha.Add("ك");
                arabicAlpha.Add("م");
                arabicAlpha.Add("ن");
                arabicAlpha.Add("ت");
                arabicAlpha.Add("ا");
                arabicAlpha.Add("ل");
                arabicAlpha.Add("ب");
                arabicAlpha.Add("ي");
                arabicAlpha.Add("س");
                arabicAlpha.Add("ش");
                arabicAlpha.Add("ئ");
                arabicAlpha.Add("ء");
                arabicAlpha.Add("ؤ");
                arabicAlpha.Add("ر");
                arabicAlpha.Add("ى");
                arabicAlpha.Add("ة");
                arabicAlpha.Add("و");
                arabicAlpha.Add("ز");
                arabicAlpha.Add("ظإ");
                arabicAlpha.Add("ـ");
                arabicAlpha.Add("أ");
                arabicAlpha.Add("آ");
                arabicAlpha.Add("’");
                arabicAlpha.Add(",");
                arabicAlpha.Add("‘");
                arabicAlpha.Add("؟");
                arabicAlpha.Add("ْ");
                foreach (var item in arabicAlpha)
                {
                    if (textBox1.Text[0].ToString() == item)
                    {
                        textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                        radioButton1.Checked = true;
                        return;
                    }
                }
                textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
                radioButton2.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}

#endif