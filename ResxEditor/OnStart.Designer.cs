#if (WIN32)
namespace ResxEditor
{
    partial class OnStart
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnStart));
            this.label1 = new System.Windows.Forms.Label();
            this.commandLink_OpenAFile = new Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink();
            this.label2 = new System.Windows.Forms.Label();
            this.commandLink1 = new Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wekcome to RESX file editor";
            // 
            // commandLink_OpenAFile
            // 
            this.commandLink_OpenAFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandLink_OpenAFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.commandLink_OpenAFile.Location = new System.Drawing.Point(17, 144);
            this.commandLink_OpenAFile.Name = "commandLink_OpenAFile";
            this.commandLink_OpenAFile.NoteText = "";
            this.commandLink_OpenAFile.Size = new System.Drawing.Size(513, 51);
            this.commandLink_OpenAFile.TabIndex = 1;
            this.commandLink_OpenAFile.Text = "Open File";
            this.commandLink_OpenAFile.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(151, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(379, 97);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // commandLink1
            // 
            this.commandLink1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandLink1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.commandLink1.Location = new System.Drawing.Point(17, 201);
            this.commandLink1.Name = "commandLink1";
            this.commandLink1.NoteText = "";
            this.commandLink1.Size = new System.Drawing.Size(513, 51);
            this.commandLink1.TabIndex = 3;
            this.commandLink1.Text = "Quit";
            this.commandLink1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Properties.Resources.RESX;
            this.pictureBox1.Location = new System.Drawing.Point(17, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // OnStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.commandLink1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commandLink_OpenAFile);
            this.Controls.Add(this.label1);
            this.Name = "OnStart";
            this.Size = new System.Drawing.Size(547, 266);
            this.Load += new System.EventHandler(this.OnStart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink commandLink_OpenAFile;
        private System.Windows.Forms.Label label2;
        public Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink commandLink1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
#endif