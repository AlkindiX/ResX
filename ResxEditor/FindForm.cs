#if (WIN32)

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
    public partial class FindForm : Form
    {
        public event OnFindPressedHandler OnFindPressed;

        public delegate void OnFindPressedHandler(object sender, FindEventArg e);

        private void RaiseOnFindPressed()
        {
        }

        public FindForm()
        {
            InitializeComponent();
        }

        private void FindForm_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            FindArgument arg = FindArgument.Close;
            FindPattren pat = FindPattren.OnValues;
            if (OnFindPressed != null)
            {
                OnFindPressed(this, new FindEventArg(textBox1.Text, arg, pat));
            }
        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show("Null value in find text box");
                return;
            }
            FindArgument arg = FindArgument.Find;
            FindPattren pat = FindPattren.OnValues;
            if (radioButton_Find_in_comments.Checked)
            {
                pat = FindPattren.OnComments;
            }
            else if (radioButton_Find_in_Keys.Checked)
            {
                pat = FindPattren.OnKeys;
            }
            else if (radioButton_Find_in_values.Checked)
            {
                pat = FindPattren.OnValues;
            }
            if (OnFindPressed != null)
            {
                OnFindPressed(this, new FindEventArg(textBox1.Text, arg, pat));
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
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
                        return;
                    }
                }
                textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            }
        }
    }
}

#endif