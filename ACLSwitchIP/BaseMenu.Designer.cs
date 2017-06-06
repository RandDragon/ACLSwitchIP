namespace ACLSwitchIP
{
    partial class BaseMenu
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tboxPortSwitch = new System.Windows.Forms.TextBox();
            this.tboxSwitch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.internetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPTVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCLDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clientSortBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.workDataBaseBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.btnACL = new System.Windows.Forms.Button();
            this.tboxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientSortBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workDataBaseBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1022, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDBToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadDBToolStripMenuItem
            // 
            this.loadDBToolStripMenuItem.Name = "loadDBToolStripMenuItem";
            this.loadDBToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.loadDBToolStripMenuItem.Text = "LoadDB";
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.saveAllToolStripMenuItem.Text = "Save all";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // tboxPortSwitch
            // 
            this.tboxPortSwitch.Location = new System.Drawing.Point(28, 86);
            this.tboxPortSwitch.Name = "tboxPortSwitch";
            this.tboxPortSwitch.Size = new System.Drawing.Size(357, 20);
            this.tboxPortSwitch.TabIndex = 1;
            // 
            // tboxSwitch
            // 
            this.tboxSwitch.Location = new System.Drawing.Point(28, 125);
            this.tboxSwitch.Name = "tboxSwitch";
            this.tboxSwitch.Size = new System.Drawing.Size(357, 20);
            this.tboxSwitch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите номер порта и коммутатор";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Или просто имя коммутатора";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(31, 264);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Искать";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // grid
            // 
            this.grid.AutoGenerateColumns = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.internetDataGridViewTextBoxColumn,
            this.iPTVDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.aCLDataGridViewCheckBoxColumn});
            this.grid.DataSource = this.clientSortBindingSource;
            this.grid.Location = new System.Drawing.Point(31, 314);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(960, 150);
            this.grid.TabIndex = 6;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 200F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // internetDataGridViewTextBoxColumn
            // 
            this.internetDataGridViewTextBoxColumn.DataPropertyName = "Internet";
            this.internetDataGridViewTextBoxColumn.HeaderText = "Internet";
            this.internetDataGridViewTextBoxColumn.Name = "internetDataGridViewTextBoxColumn";
            // 
            // iPTVDataGridViewTextBoxColumn
            // 
            this.iPTVDataGridViewTextBoxColumn.DataPropertyName = "IPTV";
            this.iPTVDataGridViewTextBoxColumn.HeaderText = "IPTV";
            this.iPTVDataGridViewTextBoxColumn.Name = "iPTVDataGridViewTextBoxColumn";
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            // 
            // aCLDataGridViewCheckBoxColumn
            // 
            this.aCLDataGridViewCheckBoxColumn.DataPropertyName = "ACL";
            this.aCLDataGridViewCheckBoxColumn.HeaderText = "ACL";
            this.aCLDataGridViewCheckBoxColumn.Name = "aCLDataGridViewCheckBoxColumn";
            // 
            // clientSortBindingSource
            // 
            this.clientSortBindingSource.DataMember = "ClientSort";
            this.clientSortBindingSource.DataSource = this.workDataBaseBindingSource2;
            // 
            // workDataBaseBindingSource2
            // 
            this.workDataBaseBindingSource2.DataSource = typeof(ACLSwitchIP.WorkDataBase);
            // 
            // btnACL
            // 
            this.btnACL.Location = new System.Drawing.Point(916, 264);
            this.btnACL.Name = "btnACL";
            this.btnACL.Size = new System.Drawing.Size(75, 23);
            this.btnACL.TabIndex = 7;
            this.btnACL.Text = "Доб. ACL";
            this.btnACL.UseVisualStyleBackColor = true;
            this.btnACL.Click += new System.EventHandler(this.btnACL_Click);
            // 
            // tboxName
            // 
            this.tboxName.Location = new System.Drawing.Point(28, 164);
            this.tboxName.Name = "tboxName";
            this.tboxName.Size = new System.Drawing.Size(357, 20);
            this.tboxName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Или имя клиента";
            // 
            // BaseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 531);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tboxName);
            this.Controls.Add(this.btnACL);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxSwitch);
            this.Controls.Add(this.tboxPortSwitch);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BaseMenu";
            this.Text = "BaseMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientSortBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workDataBaseBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox tboxPortSwitch;
        private System.Windows.Forms.TextBox tboxSwitch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.Button btnACL;
        private System.Windows.Forms.BindingSource clientSortBindingSource;
        private System.Windows.Forms.BindingSource workDataBaseBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn internetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPTVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCLDataGridViewCheckBoxColumn;
        private System.Windows.Forms.TextBox tboxName;
        private System.Windows.Forms.Label label3;
    }
}