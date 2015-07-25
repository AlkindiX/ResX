#if (WIN32)

namespace ResxEditor
{
    using ResxEditor.Properties;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Resources;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Windows.Forms;
    using System.Xml;

    public class MainForm : Form
    {
        private ToolStripMenuItem aboutUsMenuItem;
        private IContainer components;
        private ToolStripMenuItem decreaseTextSizeMenuItem;
        private float defaultTextSize;
        private ToolStripMenuItem defaultTextSizeMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem fileMenu;
        private MenuStrip fileStrip;
        private ToolStripMenuItem helpMenu;
        private ToolStripMenuItem increaseTextSizeMenuItem;
        private bool isDataModified;
        private bool isDocumentOpen;
        private ToolStripMenuItem openMenuItem;
        private ToolStripMenuItem printMenuItem;
        private ResXResourceSet resourceSet;
        private ToolStripMenuItem saveAsMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem showKeysToolStripMenuItem;
        private ToolStripMenuItem textSizeMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem viewMenu;
        private ToolStripMenuItem wordCountMenuItem;
        private XmlDataDocument xmlDocument;
        private string xmlFileName = "";
        private ToolStripMenuItem closeFileToolStripMenuItem;
        private ToolStripContainer toolStripContainer1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem findToolStripMenuItem;
        private ToolStripMenuItem goToToolStripMenuItem;
        private ToolStripMenuItem onStartToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel_is_saved;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem projectPageToolStripMenuItem;
        private DataGridView xmlGridView;

        public MainForm(string[] args)
        {
            this.InitializeComponent();
            this.xmlGridView.CellValueChanged += new DataGridViewCellEventHandler(this.xmlGridView_CellValueChanged);
            this.xmlGridView.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.xmlGridView_CellBeginEdit);
            this.xmlGridView.CurrentCellDirtyStateChanged += new EventHandler(this.xmlGridView_CurrentCellDirtyStateChanged);
            this.xmlGridView.Columns.Add("id", "Id");
            this.Text = Resources.Title;
            if (args.Length > 0)
            {
                this.OpenFile(args[0]);
            }
        }

        private void aboutUsMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private bool ConfirmFileSave(string message)
        {
            switch (MessageBox.Show(message, Resources.UnsavedChangesCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
            {
                case DialogResult.Cancel:
                    return false;

                case DialogResult.No:
                    return true;
            }
            this.SaveFile();
            return true;
        }

        private void decreaseTextSizeMenuItem_Click(object sender, EventArgs e)
        {
            this.xmlGridView.Font = new Font(this.xmlGridView.Font.FontFamily, this.xmlGridView.Font.Size / 1.2f);
            this.xmlGridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        private void defaultTextSizeMenuItem_Click(object sender, EventArgs e)
        {
            this.xmlGridView.Font = new Font(this.xmlGridView.Font.FontFamily, this.defaultTextSize);
            this.xmlGridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void increaseTextSizeMenuItem_Click(object sender, EventArgs e)
        {
            this.xmlGridView.Visible = false;
            this.xmlGridView.Font = new Font(this.xmlGridView.Font.FontFamily, this.xmlGridView.Font.Size * 1.2f);
            this.xmlGridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            this.xmlGridView.Visible = true;
        }

        private void InitGrid()
        {
            this.xmlGridView.AutoGenerateColumns = true;
            this.xmlGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.defaultTextSize = this.xmlGridView.DefaultCellStyle.Font.Size;
            foreach (DataGridViewColumn column in this.xmlGridView.Columns)
            {
                column.Visible = false;
            }
            this.xmlGridView.Columns["id"].Visible = true;
            this.xmlGridView.Columns["id"].DisplayIndex = 1;
            this.xmlGridView.Columns["id"].Width = 25;
            this.xmlGridView.Columns["id"].ReadOnly = true;
            this.xmlGridView.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.xmlGridView.Columns["id"].HeaderText = "Id";
            this.xmlGridView.Columns["id"].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.xmlGridView.Columns["name"].HeaderText = Resources.NameHeader;
            this.xmlGridView.Columns["name"].ReadOnly = true;
            this.xmlGridView.Columns["name"].DisplayIndex = 2;
            this.xmlGridView.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.xmlGridView.Columns["name"].DefaultCellStyle.BackColor = Color.LightGray;
            this.xmlGridView.Columns["name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.xmlGridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            this.xmlGridView.Columns["value"].Visible = true;
            this.xmlGridView.Columns["value"].DisplayIndex = 3;
            this.xmlGridView.Columns["value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.xmlGridView.Columns["value"].HeaderText = Resources.ValueHeader;
            this.xmlGridView.Columns["value"].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.xmlGridView.Columns["comment"].Visible = true;

            this.xmlGridView.Columns["comment"].DisplayIndex = 4;
            this.xmlGridView.Columns["comment"].ReadOnly = true;
            this.xmlGridView.Columns["comment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.xmlGridView.Columns["comment"].HeaderText = Resources.CommentHeader;
            this.xmlGridView.Columns["comment"].DefaultCellStyle.BackColor = Color.LightGray;
            this.xmlGridView.Columns["comment"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fileStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.printMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.textSizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseTextSizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseTextSizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.defaultTextSizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordCountMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.projectPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xmlGridView = new System.Windows.Forms.DataGridView();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_is_saved = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xmlGridView)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileStrip
            // 
            this.fileStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.fileStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editToolStripMenuItem,
            this.viewMenu,
            this.helpMenu});
            this.fileStrip.Location = new System.Drawing.Point(0, 0);
            this.fileStrip.Name = "fileStrip";
            this.fileStrip.Size = new System.Drawing.Size(632, 24);
            this.fileStrip.TabIndex = 0;
            this.fileStrip.Text = "menuStrip1";
            this.fileStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.fileStrip_ItemClicked);
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.closeFileToolStripMenuItem,
            this.toolStripSeparator3,
            this.printMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "&File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(170, 22);
            this.openMenuItem.Text = "&Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Enabled = false;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveMenuItem.Text = "&Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Enabled = false;
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveAsMenuItem.Text = "Save As";
            this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // closeFileToolStripMenuItem
            // 
            this.closeFileToolStripMenuItem.Enabled = false;
            this.closeFileToolStripMenuItem.Name = "closeFileToolStripMenuItem";
            this.closeFileToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F4";
            this.closeFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.closeFileToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.closeFileToolStripMenuItem.Text = "Close File";
            this.closeFileToolStripMenuItem.Click += new System.EventHandler(this.closeFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // printMenuItem
            // 
            this.printMenuItem.Name = "printMenuItem";
            this.printMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printMenuItem.Size = new System.Drawing.Size(170, 22);
            this.printMenuItem.Text = "Print";
            this.printMenuItem.Visible = false;
            this.printMenuItem.Click += new System.EventHandler(this.printMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exitToolStripMenuItem.Text = "&Quit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.goToToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Enabled = false;
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.findToolStripMenuItem.Text = "&Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.Enabled = false;
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.goToToolStripMenuItem.Text = "&Go To";
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textSizeMenuItem,
            this.wordCountMenuItem,
            this.toolStripSeparator4,
            this.showKeysToolStripMenuItem,
            this.onStartToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(44, 20);
            this.viewMenu.Text = "&View";
            this.viewMenu.Click += new System.EventHandler(this.viewMenu_Click);
            // 
            // textSizeMenuItem
            // 
            this.textSizeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.increaseTextSizeMenuItem,
            this.decreaseTextSizeMenuItem,
            this.toolStripSeparator2,
            this.defaultTextSizeMenuItem});
            this.textSizeMenuItem.Enabled = false;
            this.textSizeMenuItem.Name = "textSizeMenuItem";
            this.textSizeMenuItem.Size = new System.Drawing.Size(204, 22);
            this.textSizeMenuItem.Text = "&Text size";
            // 
            // increaseTextSizeMenuItem
            // 
            this.increaseTextSizeMenuItem.Name = "increaseTextSizeMenuItem";
            this.increaseTextSizeMenuItem.ShortcutKeyDisplayString = "Ctrl+Up";
            this.increaseTextSizeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.increaseTextSizeMenuItem.Size = new System.Drawing.Size(186, 22);
            this.increaseTextSizeMenuItem.Text = "&Increase";
            this.increaseTextSizeMenuItem.Click += new System.EventHandler(this.increaseTextSizeMenuItem_Click);
            // 
            // decreaseTextSizeMenuItem
            // 
            this.decreaseTextSizeMenuItem.Name = "decreaseTextSizeMenuItem";
            this.decreaseTextSizeMenuItem.ShortcutKeyDisplayString = "Ctrl+Down";
            this.decreaseTextSizeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.decreaseTextSizeMenuItem.Size = new System.Drawing.Size(186, 22);
            this.decreaseTextSizeMenuItem.Text = "&Decrease";
            this.decreaseTextSizeMenuItem.Click += new System.EventHandler(this.decreaseTextSizeMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // defaultTextSizeMenuItem
            // 
            this.defaultTextSizeMenuItem.Name = "defaultTextSizeMenuItem";
            this.defaultTextSizeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.defaultTextSizeMenuItem.Size = new System.Drawing.Size(186, 22);
            this.defaultTextSizeMenuItem.Text = "Defaul&t";
            this.defaultTextSizeMenuItem.Click += new System.EventHandler(this.defaultTextSizeMenuItem_Click);
            // 
            // wordCountMenuItem
            // 
            this.wordCountMenuItem.Enabled = false;
            this.wordCountMenuItem.Name = "wordCountMenuItem";
            this.wordCountMenuItem.Size = new System.Drawing.Size(204, 22);
            this.wordCountMenuItem.Text = "&Word count";
            this.wordCountMenuItem.Click += new System.EventHandler(this.wordCountMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(201, 6);
            // 
            // showKeysToolStripMenuItem
            // 
            this.showKeysToolStripMenuItem.CheckOnClick = true;
            this.showKeysToolStripMenuItem.Enabled = false;
            this.showKeysToolStripMenuItem.Name = "showKeysToolStripMenuItem";
            this.showKeysToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.showKeysToolStripMenuItem.Text = "View Keys";
            this.showKeysToolStripMenuItem.Click += new System.EventHandler(this.showKeysToolStripMenuItem_Click);
            // 
            // onStartToolStripMenuItem
            // 
            this.onStartToolStripMenuItem.Name = "onStartToolStripMenuItem";
            this.onStartToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.onStartToolStripMenuItem.Text = "&On start welcome screen";
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutUsMenuItem,
            this.toolStripSeparator5,
            this.projectPageToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "&Help";
            // 
            // aboutUsMenuItem
            // 
            this.aboutUsMenuItem.Name = "aboutUsMenuItem";
            this.aboutUsMenuItem.Size = new System.Drawing.Size(140, 22);
            this.aboutUsMenuItem.Text = "&About";
            this.aboutUsMenuItem.Click += new System.EventHandler(this.aboutUsMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(137, 6);
            // 
            // projectPageToolStripMenuItem
            // 
            this.projectPageToolStripMenuItem.Name = "projectPageToolStripMenuItem";
            this.projectPageToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.projectPageToolStripMenuItem.Text = "Project page";
            this.projectPageToolStripMenuItem.Click += new System.EventHandler(this.projectPageToolStripMenuItem_Click);
            // 
            // xmlGridView
            // 
            this.xmlGridView.AllowUserToAddRows = false;
            this.xmlGridView.AllowUserToDeleteRows = false;
            this.xmlGridView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.xmlGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xmlGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.xmlGridView.Location = new System.Drawing.Point(0, 0);
            this.xmlGridView.Name = "xmlGridView";
            this.xmlGridView.Size = new System.Drawing.Size(632, 342);
            this.xmlGridView.TabIndex = 1;
            this.xmlGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.xmlGridView_CellContentClick);
            this.xmlGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.xmlGridView_CellMouseDoubleClick);
            this.xmlGridView.Paint += new System.Windows.Forms.PaintEventHandler(this.xmlGridView_Paint);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.xmlGridView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(632, 342);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(632, 366);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.fileStrip);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_is_saved});
            this.statusStrip1.Location = new System.Drawing.Point(0, 344);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_is_saved
            // 
            this.toolStripStatusLabel_is_saved.Name = "toolStripStatusLabel_is_saved";
            this.toolStripStatusLabel_is_saved.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(632, 366);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.fileStrip;
            this.Name = "MainForm";
            this.Text = "RESX ?????";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.fileStrip.ResumeLayout(false);
            this.fileStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xmlGridView)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.isDataModified && !this.ConfirmFileSave(Resources.UnsavedChangesExit))
            {
                e.Cancel = true;
            }
            else
            {
                base.OnClosing(e);
            }
        }

        private void OpenFile(string fileName)
        {
            if (!Path.GetExtension(fileName).Contains("resx"))
            {
                this.isDocumentOpen = false;
                this.ReportError("File must be a RESX file");
                return;
            }
            try
            {
                this.xmlDocument = new XmlDataDocument();
                this.xmlDocument.DataSet.ReadXmlSchema(fileName);
                stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                this.xmlDocument.Load(stream);
                stream.Close();
                this.xmlGridView.DataSource = this.xmlDocument.DataSet;
                this.xmlGridView.DataMember = "data";
                stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                this.resourceSet = new ResXResourceSet(stream);
            }
            catch (SecurityException exx)
            {
                Msbox.ShowMessage(this, "Cannot open file name " + fileName + "because\n" + exx.Message, "Error", Msbox.MsBoxIcon.Error, Msbox.MsBoxButtons.Close);
            }
            catch (FileNotFoundException)
            {
                Msbox.ShowMessage(this, "Cannot find file name " + fileName, "Error", Msbox.MsBoxIcon.Error, Msbox.MsBoxButtons.Close);
            }
            catch (UnauthorizedAccessException)
            {
                Msbox.ShowMessage(this, "Cannot access file name " + fileName + " because you are unauthorized to access the file", "Error", Msbox.MsBoxIcon.Error, Msbox.MsBoxButtons.Close);
            }
            catch (Exception exception)
            {
                this.isDocumentOpen = false;
                this.ReportError(exception.Message);
                return;
            }
            this.xmlFileName = fileName;
            this.InitGrid();
            foreach (DictionaryEntry entry in this.resourceSet)
            {
                if (entry.Value.GetType() != new string('a', 1).GetType())
                {
                    foreach (DataGridViewRow row in (IEnumerable)this.xmlGridView.Rows)
                    {
                        if (row.Cells["name"].Value.ToString() == entry.Key.ToString())
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
            int x = 1;
            foreach (DataGridViewRow row in (IEnumerable)this.xmlGridView.Rows)
            {
                row.Cells["id"].Value = x;
                x++;
            }
            this.resourceSet.Close();
            stream.Close();
            this.isDataModified = false;
            this.isDocumentOpen = true;
            this.init();
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.isDataModified || this.ConfirmFileSave(Resources.UnsavedChanges))
            {
                Uninit(false);
                OpenFileDialog dialog = new OpenFileDialog
                {
                    Filter = Resources.ResxFilesFilter + " (*.resx)|*.resx|" + Resources.AllFilesFilter + " (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.OpenFile(dialog.FileName);
                }
            }
        }

        private void printMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ReportError(string message)
        {
            Msbox.ShowMessage(this, message, "Error", Msbox.MsBoxIcon.Error, Msbox.MsBoxButtons.Close);
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = Resources.ResxFilesFilter + " (*.resx)|*.resx|" + Resources.AllFilesFilter + " (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = dialog.OpenFile();
                if (stream != null)
                {
                    stream.Close();
                    this.xmlFileName = dialog.FileName;
                    this.SaveFile();
                }
                this.isDataModified = false;
                this.init();
            }
        }

        private void SaveFile()
        {
            base.Validate();
            this.xmlGridView.EndEdit();
            ((CurrencyManager)this.xmlGridView.BindingContext[this.xmlGridView.DataSource, "data"]).EndCurrentEdit();
            this.xmlDocument.Save(this.xmlFileName);
            this.isDataModified = false;
            this.init();
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveFile();
        }

        private void showKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewColumn column1 = this.xmlGridView.Columns["name"];
            column1.Visible = !column1.Visible;
        }

        private void init()
        {
            if ((this.xmlFileName == null) || (this.xmlFileName == string.Empty))
            {
                this.Text = Resources.FormTitle;
            }
            else
            {
                string str = this.isDataModified ? "*" : "";
                int startIndex = Math.Max(this.xmlFileName.LastIndexOf('\\') + 1, 0);
                this.Text = this.xmlFileName.Substring(startIndex) + str + " - " + Resources.FormTitle;
            }
            this.textSizeMenuItem.Enabled = this.isDocumentOpen;
            this.saveMenuItem.Enabled = this.isDocumentOpen;
            this.saveAsMenuItem.Enabled = this.isDocumentOpen;
            this.wordCountMenuItem.Enabled = this.isDocumentOpen;
            this.showKeysToolStripMenuItem.Enabled = this.isDocumentOpen;
            this.onstart.Visible = false;
            this.xmlGridView.Visible = true;
            this.closeFileToolStripMenuItem.Enabled = this.isDocumentOpen;
            this.findToolStripMenuItem.Enabled = this.isDocumentOpen;
            this.goToToolStripMenuItem.Enabled = this.isDocumentOpen;
            this.toolStripStatusLabel_is_saved.Text = "Document saved";
        }

        private void wordCountMenuItem_Click(object sender, EventArgs e)
        {
            int num = 0;
            foreach (DataGridViewRow row in (IEnumerable)this.xmlGridView.Rows)
            {
                string str = (string)row.Cells["value"].Value;
                num += str.Split(new char[] { ' ', ',', ';', '.', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
            }
            MessageBox.Show(Resources.WordCountLine + " " + num, Resources.DocumentStatistics, MessageBoxButtons.OK);
        }

        private void xmlGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
        }

        private void xmlGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.init();
        }

        private void xmlGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            this.isDataModified = true;
            this.toolStripStatusLabel_is_saved.Text = "You have unsaved data";
        }

        private void xmlGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ChangeOnStartPosition();
        }

        private void ChangeOnStartPosition()
        {
            onstart.Location = new Point((this.toolStripContainer1.ContentPanel.Bounds.Width / 2) - onstart.Width / 2, (this.toolStripContainer1.ContentPanel.Bounds.Height / 2) - onstart.Height / 2);
        }

        private OnStart onstart = new OnStart();

        private void MainForm_Load(object sender, EventArgs e)
        {
            toolStripContainer1.ContentPanel.Resize += ContentPanel_Resize;
            toolStripContainer1.ContentPanel.Controls.Add(onstart);
            onstart.Name = "Control_OnStart";
            onstart.Top = 0;
            onstart.commandLink_OpenAFile.Click += commandLink_OpenAFile_Click;
            onstart.commandLink1.Click += commandLink1_Click;
            this.xmlGridView.Visible = false;
            SetWindowTheme(this.xmlGridView.Handle, "explorer", null);
            SendMessage(this.xmlGridView.Handle, 4150, 65536, 65536);
        }

        private void ContentPanel_Resize(object sender, EventArgs e)
        {
            ChangeOnStartPosition();
        }

        private void commandLink1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void commandLink_OpenAFile_Click(object sender, EventArgs e)
        {
            openMenuItem_Click(null, null);
        }

        private void Uninit(bool ShowOnStart = true)
        {
            if (ShowOnStart)
            {
                this.xmlGridView.Visible = false;
                this.onstart.Visible = true;
            }
            this.isDataModified = false;
            this.isDocumentOpen = false;
            this.xmlFileName = "";
            this.xmlDocument = null;
            this.Text = Resources.FormTitle;
            this.textSizeMenuItem.Enabled = this.isDocumentOpen;
            this.saveMenuItem.Enabled = this.isDocumentOpen;
            this.saveAsMenuItem.Enabled = this.isDocumentOpen;
            this.wordCountMenuItem.Enabled = this.isDocumentOpen;
            this.showKeysToolStripMenuItem.Enabled = this.isDocumentOpen;
            this.findToolStripMenuItem.Enabled = this.isDocumentOpen;
            this.goToToolStripMenuItem.Enabled = this.isDocumentOpen;
            this.toolStripStatusLabel_is_saved.Text = "";
        }

        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.isDataModified || this.ConfirmFileSave(Resources.UnsavedChangesExit) == true)
            {
                Uninit();
            }
        }

        private void fileStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private FindForm findform = new FindForm();

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findform = new ResxEditor.FindForm();
            findform.OnFindPressed += f_OnFindPressed;
            findform.Show(this);
        }

        private void f_OnFindPressed(object sender, FindEventArg e)
        {
            if (e.Arguments == FindArgument.Close)
            {
                findform.OnFindPressed -= f_OnFindPressed;
                return;
            }
            string col = "";
            if (e.Pattren == FindPattren.OnValues)
            {
                col = "value";
            }
            else if (e.Pattren == FindPattren.OnKeys)
            {
                col = "name";
            }
            else if (e.Pattren == FindPattren.OnComments)
            {
                col = "comment";
            }
            foreach (DataGridViewRow row in (IEnumerable)this.xmlGridView.Rows)
            {
                string val = (string)row.Cells[col].Value;
                var txt = e.FindText;
                try
                {
                    val = val.ToLower();
                    txt = e.FindText.ToLower();
                }
                catch (Exception)
                {
                }

                if (val.Contains(txt))
                {
                    row.Selected = true;
                    xmlGridView.HorizontalScrollingOffset = row.Height - 20;

                    return;
                }
            }
            MessageBox.Show("Cannot find " + e.FindText);
        }

        private void viewMenu_Click(object sender, EventArgs e)
        {
        }

        private void xmlGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Editor ed = new Editor((string)xmlGridView.Rows[e.RowIndex].Cells["value"].Value);
            if (ed.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                xmlGridView.Rows[e.RowIndex].Cells["value"].Value = ed.TextEdited;
                xmlGridView_CurrentCellDirtyStateChanged(sender, e);
            }
        }

        public FileStream stream { get; set; }

        [DllImport("uxtheme", CharSet = CharSet.Auto)]
        public static extern int SetWindowTheme(IntPtr hWnd, string textSubAppName, string textSubIdList);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        private void xmlGridView_Paint(object sender, PaintEventArgs e)
        {
            SetWindowTheme(this.xmlGridView.Handle, "explorer", null);
            SendMessage(this.xmlGridView.Handle, 4150, 65536, 65536);
        }

        private void projectPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("url:https://resourcex.codeplex.com/");
        }
    }
}

#endif