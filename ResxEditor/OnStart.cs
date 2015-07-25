#if (WIN32)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ResxEditor
{
    public partial class OnStart : UserControl
    {
        public OnStart()
        {
            InitializeComponent();
        }

        private void OnStart_Load(object sender, EventArgs e)
        {
            commandLink_OpenAFile.Select();
        }
    }
}

#endif