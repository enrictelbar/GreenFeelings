namespace WebBrowserCourseworkForReal
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsHomePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editHomeURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.goHomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBookmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.myBookmarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGO = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBoxHome = new System.Windows.Forms.RichTextBox();
            this.buttonAddTab = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelStatusCode = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.navigateToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1803, 44);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsHomePageToolStripMenuItem,
            this.editHomeURLToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(92, 38);
            this.fileToolStripMenuItem.Text = "Home";
            // 
            // setAsHomePageToolStripMenuItem
            // 
            this.setAsHomePageToolStripMenuItem.Name = "setAsHomePageToolStripMenuItem";
            this.setAsHomePageToolStripMenuItem.Size = new System.Drawing.Size(301, 38);
            this.setAsHomePageToolStripMenuItem.Text = "Set URL As Home";
            this.setAsHomePageToolStripMenuItem.Click += new System.EventHandler(this.setAsHomePageToolStripMenuItem_Click);
            // 
            // editHomeURLToolStripMenuItem
            // 
            this.editHomeURLToolStripMenuItem.Name = "editHomeURLToolStripMenuItem";
            this.editHomeURLToolStripMenuItem.Size = new System.Drawing.Size(301, 38);
            this.editHomeURLToolStripMenuItem.Text = "Edit Home URL";
            this.editHomeURLToolStripMenuItem.Click += new System.EventHandler(this.editHomeURLToolStripMenuItem_Click);
            // 
            // navigateToolStripMenuItem
            // 
            this.navigateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goForwardToolStripMenuItem,
            this.goBackToolStripMenuItem,
            this.toolStripSeparator2,
            this.goHomeToolStripMenuItem,
            this.toolStripSeparator1,
            this.viewHistoryToolStripMenuItem,
            this.toolStripSeparator4,
            this.clearHistoryToolStripMenuItem});
            this.navigateToolStripMenuItem.Name = "navigateToolStripMenuItem";
            this.navigateToolStripMenuItem.Size = new System.Drawing.Size(122, 38);
            this.navigateToolStripMenuItem.Text = "Navigate";
            // 
            // goForwardToolStripMenuItem
            // 
            this.goForwardToolStripMenuItem.Name = "goForwardToolStripMenuItem";
            this.goForwardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.goForwardToolStripMenuItem.Size = new System.Drawing.Size(399, 38);
            this.goForwardToolStripMenuItem.Text = "Go Forward";
            this.goForwardToolStripMenuItem.Click += new System.EventHandler(this.goForwardToolStripMenuItem_Click);
            // 
            // goBackToolStripMenuItem
            // 
            this.goBackToolStripMenuItem.Name = "goBackToolStripMenuItem";
            this.goBackToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.goBackToolStripMenuItem.Size = new System.Drawing.Size(399, 38);
            this.goBackToolStripMenuItem.Text = "Go Back";
            this.goBackToolStripMenuItem.Click += new System.EventHandler(this.goBackToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(396, 6);
            // 
            // goHomeToolStripMenuItem
            // 
            this.goHomeToolStripMenuItem.Name = "goHomeToolStripMenuItem";
            this.goHomeToolStripMenuItem.Size = new System.Drawing.Size(399, 38);
            this.goHomeToolStripMenuItem.Text = "Go Home";
            this.goHomeToolStripMenuItem.Click += new System.EventHandler(this.goHomeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(396, 6);
            // 
            // viewHistoryToolStripMenuItem
            // 
            this.viewHistoryToolStripMenuItem.Name = "viewHistoryToolStripMenuItem";
            this.viewHistoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.viewHistoryToolStripMenuItem.Size = new System.Drawing.Size(399, 38);
            this.viewHistoryToolStripMenuItem.Text = "View History";
            this.viewHistoryToolStripMenuItem.Click += new System.EventHandler(this.viewHistoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(396, 6);
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(399, 38);
            this.clearHistoryToolStripMenuItem.Text = "Clear History";
            this.clearHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearHistoryToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBookmarkToolStripMenuItem,
            this.toolStripSeparator3,
            this.myBookmarksToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(144, 38);
            this.editToolStripMenuItem.Text = "Bookmarks";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // addBookmarkToolStripMenuItem
            // 
            this.addBookmarkToolStripMenuItem.Name = "addBookmarkToolStripMenuItem";
            this.addBookmarkToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.addBookmarkToolStripMenuItem.Size = new System.Drawing.Size(437, 38);
            this.addBookmarkToolStripMenuItem.Text = "Bookmark Current URL";
            this.addBookmarkToolStripMenuItem.Click += new System.EventHandler(this.addBookmarkToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(369, 6);
            // 
            // myBookmarksToolStripMenuItem
            // 
            this.myBookmarksToolStripMenuItem.Name = "myBookmarksToolStripMenuItem";
            this.myBookmarksToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.myBookmarksToolStripMenuItem.Size = new System.Drawing.Size(372, 38);
            this.myBookmarksToolStripMenuItem.Text = "View Bookmarks";
            this.myBookmarksToolStripMenuItem.Click += new System.EventHandler(this.myBookmarksToolStripMenuItem_Click);
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(489, 9);
            this.textBoxURL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(770, 31);
            this.textBoxURL.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(414, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL :";
            // 
            // buttonGO
            // 
            this.buttonGO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonGO.Location = new System.Drawing.Point(1270, 9);
            this.buttonGO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGO.Name = "buttonGO";
            this.buttonGO.Size = new System.Drawing.Size(106, 36);
            this.buttonGO.TabIndex = 3;
            this.buttonGO.Text = "GO";
            this.buttonGO.UseVisualStyleBackColor = true;
            this.buttonGO.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(18, 55);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1767, 1048);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBoxHome);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1751, 1001);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBoxHome
            // 
            this.richTextBoxHome.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxHome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBoxHome.Name = "richTextBoxHome";
            this.richTextBoxHome.Size = new System.Drawing.Size(1766, 1007);
            this.richTextBoxHome.TabIndex = 0;
            this.richTextBoxHome.Text = "";
            // 
            // buttonAddTab
            // 
            this.buttonAddTab.Location = new System.Drawing.Point(1536, 9);
            this.buttonAddTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddTab.Name = "buttonAddTab";
            this.buttonAddTab.Size = new System.Drawing.Size(112, 36);
            this.buttonAddTab.TabIndex = 0;
            this.buttonAddTab.Text = "Add Tab";
            this.buttonAddTab.UseVisualStyleBackColor = true;
            this.buttonAddTab.Click += new System.EventHandler(this.buttonAddTab_click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1658, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "Close Tab";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelStatusCode
            // 
            this.labelStatusCode.AutoSize = true;
            this.labelStatusCode.ForeColor = System.Drawing.Color.Gray;
            this.labelStatusCode.Location = new System.Drawing.Point(1394, 17);
            this.labelStatusCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatusCode.Name = "labelStatusCode";
            this.labelStatusCode.Size = new System.Drawing.Size(33, 25);
            this.labelStatusCode.TabIndex = 6;
            this.labelStatusCode.Text = "---";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1803, 1122);
            this.Controls.Add(this.labelStatusCode);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonAddTab);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonGO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.button1_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goHomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBookmarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myBookmarksToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGO;
        private System.Windows.Forms.ToolStripMenuItem setAsHomePageToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonAddTab;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBoxHome;
        private System.Windows.Forms.Label labelStatusCode;
        private System.Windows.Forms.ToolStripMenuItem clearHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editHomeURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolStripMenuItem viewHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

