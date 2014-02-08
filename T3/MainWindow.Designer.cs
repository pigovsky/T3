namespace T3
{
    partial class MainWindow
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.seminarsAndLectorsTreeView = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSeminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLecturerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lectorsListBox = new System.Windows.Forms.ListBox();
            this.previewPaneWebBrowser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.seminarsAndLectorsTreeView);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(569, 354);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 0;
            // 
            // seminarsAndLectorsTreeView
            // 
            this.seminarsAndLectorsTreeView.AllowDrop = true;
            this.seminarsAndLectorsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seminarsAndLectorsTreeView.Location = new System.Drawing.Point(0, 24);
            this.seminarsAndLectorsTreeView.Name = "seminarsAndLectorsTreeView";
            this.seminarsAndLectorsTreeView.Size = new System.Drawing.Size(188, 330);
            this.seminarsAndLectorsTreeView.TabIndex = 0;
            this.seminarsAndLectorsTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.seminarsAndLectorsTreeView_BeforeExpand);
            this.seminarsAndLectorsTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.seminarsAndLectorsTreeView_ItemDrag);
            this.seminarsAndLectorsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.seminarsAndLectorsTreeView_NodeMouseClick);
            this.seminarsAndLectorsTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.seminarsAndLectorsTreeView_DragDrop);
            this.seminarsAndLectorsTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.seminarsAndLectorsTreeView_DragEnter);
            this.seminarsAndLectorsTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.seminarsAndLectorsTreeView_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(188, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSeminarToolStripMenuItem,
            this.newLecturerToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // newSeminarToolStripMenuItem
            // 
            this.newSeminarToolStripMenuItem.Name = "newSeminarToolStripMenuItem";
            this.newSeminarToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.newSeminarToolStripMenuItem.Text = "New Seminar...";
            this.newSeminarToolStripMenuItem.Click += new System.EventHandler(this.newSeminarToolStripMenuItem_Click);
            // 
            // newLecturerToolStripMenuItem
            // 
            this.newLecturerToolStripMenuItem.Name = "newLecturerToolStripMenuItem";
            this.newLecturerToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.newLecturerToolStripMenuItem.Text = "New Lecturer...";
            this.newLecturerToolStripMenuItem.Click += new System.EventHandler(this.newLecturerToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lectorsListBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.previewPaneWebBrowser);
            this.splitContainer2.Size = new System.Drawing.Size(377, 354);
            this.splitContainer2.SplitterDistance = 82;
            this.splitContainer2.TabIndex = 0;
            // 
            // lectorsListBox
            // 
            this.lectorsListBox.AllowDrop = true;
            this.lectorsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lectorsListBox.FormattingEnabled = true;
            this.lectorsListBox.Location = new System.Drawing.Point(0, 0);
            this.lectorsListBox.Name = "lectorsListBox";
            this.lectorsListBox.Size = new System.Drawing.Size(377, 82);
            this.lectorsListBox.TabIndex = 0;
            this.lectorsListBox.SelectedValueChanged += new System.EventHandler(this.lectorsListBox_SelectedValueChanged);
            this.lectorsListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.lectorsListBox_DragDrop);
            this.lectorsListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.lectorsListBox_DragEnter);
            this.lectorsListBox.DoubleClick += new System.EventHandler(this.lectorsListBox_DoubleClick);
            this.lectorsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lectorsListBox_MouseDown);
            this.lectorsListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lectorsListBox_MouseMove);
            // 
            // previewPaneWebBrowser
            // 
            this.previewPaneWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPaneWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.previewPaneWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.previewPaneWebBrowser.Name = "previewPaneWebBrowser";
            this.previewPaneWebBrowser.Size = new System.Drawing.Size(377, 268);
            this.previewPaneWebBrowser.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 354);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Lecturers-seminars";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView seminarsAndLectorsTreeView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.WebBrowser previewPaneWebBrowser;
        private System.Windows.Forms.ListBox lectorsListBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSeminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLecturerToolStripMenuItem;
    }
}

