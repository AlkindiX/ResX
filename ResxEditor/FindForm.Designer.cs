#if (WIN32)
namespace ResxEditor
{
    partial class FindForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Find_in_Keys = new System.Windows.Forms.RadioButton();
            this.radioButton_Find_in_comments = new System.Windows.Forms.RadioButton();
            this.radioButton_Find_in_values = new System.Windows.Forms.RadioButton();
            this.button_Find = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.radioButton_Find_in_Keys);
            this.groupBox1.Controls.Add(this.radioButton_Find_in_comments);
            this.groupBox1.Controls.Add(this.radioButton_Find_in_values);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 76);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find pattren";
            // 
            // radioButton_Find_in_Keys
            // 
            this.radioButton_Find_in_Keys.AutoSize = true;
            this.radioButton_Find_in_Keys.Location = new System.Drawing.Point(168, 19);
            this.radioButton_Find_in_Keys.Name = "radioButton_Find_in_Keys";
            this.radioButton_Find_in_Keys.Size = new System.Drawing.Size(48, 17);
            this.radioButton_Find_in_Keys.TabIndex = 2;
            this.radioButton_Find_in_Keys.Text = "Keys";
            this.radioButton_Find_in_Keys.UseVisualStyleBackColor = true;
            // 
            // radioButton_Find_in_comments
            // 
            this.radioButton_Find_in_comments.AutoSize = true;
            this.radioButton_Find_in_comments.Location = new System.Drawing.Point(6, 48);
            this.radioButton_Find_in_comments.Name = "radioButton_Find_in_comments";
            this.radioButton_Find_in_comments.Size = new System.Drawing.Size(75, 17);
            this.radioButton_Find_in_comments.TabIndex = 1;
            this.radioButton_Find_in_comments.Text = "Comments";
            this.radioButton_Find_in_comments.UseVisualStyleBackColor = true;
            // 
            // radioButton_Find_in_values
            // 
            this.radioButton_Find_in_values.AutoSize = true;
            this.radioButton_Find_in_values.Checked = true;
            this.radioButton_Find_in_values.Location = new System.Drawing.Point(6, 19);
            this.radioButton_Find_in_values.Name = "radioButton_Find_in_values";
            this.radioButton_Find_in_values.Size = new System.Drawing.Size(56, 17);
            this.radioButton_Find_in_values.TabIndex = 0;
            this.radioButton_Find_in_values.TabStop = true;
            this.radioButton_Find_in_values.Text = "Values";
            this.radioButton_Find_in_values.UseVisualStyleBackColor = true;
            // 
            // button_Find
            // 
            this.button_Find.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Find.Location = new System.Drawing.Point(165, 139);
            this.button_Find.Name = "button_Find";
            this.button_Find.Size = new System.Drawing.Size(94, 23);
            this.button_Find.TabIndex = 3;
            this.button_Find.Text = "&Find";
            this.button_Find.UseVisualStyleBackColor = true;
            this.button_Find.Click += new System.EventHandler(this.button_Find_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(65, 139);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(94, 23);
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "&Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(99, 48);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(148, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Let the application decide";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FindForm
            // 
            this.AcceptButton = this.button_Find;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(271, 174);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Find);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Find";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FindForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_Find_in_comments;
        private System.Windows.Forms.RadioButton radioButton_Find_in_values;
        private System.Windows.Forms.Button button_Find;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.RadioButton radioButton_Find_in_Keys;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
#endif