namespace Tasks
{
    partial class TasksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TasksForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.btnNewTask = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletaAllTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetDone = new System.Windows.Forms.Button();
            this.dgvDoneTasks = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteTaskCtrlDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.setDoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblOngoingTasks = new System.Windows.Forms.Label();
            this.lblOngoingTasksTotal = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoneTasks)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(16, 70);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(777, 245);
            this.tabControl.TabIndex = 0;
            this.tabControl.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.tabControl_ControlAdded);
            this.tabControl.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tabControl_ControlRemoved);
            // 
            // btnNewTask
            // 
            this.btnNewTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.btnNewTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTask.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNewTask.ForeColor = System.Drawing.Color.White;
            this.btnNewTask.Location = new System.Drawing.Point(16, 398);
            this.btnNewTask.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewTask.Name = "btnNewTask";
            this.btnNewTask.Padding = new System.Windows.Forms.Padding(1);
            this.btnNewTask.Size = new System.Drawing.Size(100, 41);
            this.btnNewTask.TabIndex = 1;
            this.btnNewTask.Text = "New";
            this.btnNewTask.UseVisualStyleBackColor = false;
            this.btnNewTask.Click += new System.EventHandler(this.btnNewTask_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.btnDeleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTask.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteTask.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTask.Location = new System.Drawing.Point(232, 398);
            this.btnDeleteTask.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Padding = new System.Windows.Forms.Padding(1);
            this.btnDeleteTask.Size = new System.Drawing.Size(100, 41);
            this.btnDeleteTask.TabIndex = 2;
            this.btnDeleteTask.Text = "Delete";
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTaskToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteTaskToolStripMenuItem,
            this.deletaAllTasksToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 82);
            // 
            // newTaskToolStripMenuItem
            // 
            this.newTaskToolStripMenuItem.Name = "newTaskToolStripMenuItem";
            this.newTaskToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.newTaskToolStripMenuItem.Text = "New Task";
            this.newTaskToolStripMenuItem.Click += new System.EventHandler(this.newTaskToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // deleteTaskToolStripMenuItem
            // 
            this.deleteTaskToolStripMenuItem.Name = "deleteTaskToolStripMenuItem";
            this.deleteTaskToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.deleteTaskToolStripMenuItem.Text = "Delete Task";
            this.deleteTaskToolStripMenuItem.Click += new System.EventHandler(this.deleteTaskToolStripMenuItem_Click);
            // 
            // deletaAllTasksToolStripMenuItem
            // 
            this.deletaAllTasksToolStripMenuItem.Name = "deletaAllTasksToolStripMenuItem";
            this.deletaAllTasksToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.deletaAllTasksToolStripMenuItem.Text = "Deleta All Tasks";
            this.deletaAllTasksToolStripMenuItem.Click += new System.EventHandler(this.deletaAllTasksToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.label1.Location = new System.Drawing.Point(12, 453);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Completed:";
            // 
            // btnSetDone
            // 
            this.btnSetDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.btnSetDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetDone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.btnSetDone.ForeColor = System.Drawing.Color.White;
            this.btnSetDone.Location = new System.Drawing.Point(124, 398);
            this.btnSetDone.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetDone.Name = "btnSetDone";
            this.btnSetDone.Size = new System.Drawing.Size(100, 41);
            this.btnSetDone.TabIndex = 5;
            this.btnSetDone.Text = "Done";
            this.btnSetDone.UseVisualStyleBackColor = false;
            this.btnSetDone.Click += new System.EventHandler(this.btnSetDone_Click);
            // 
            // dgvDoneTasks
            // 
            this.dgvDoneTasks.AllowUserToAddRows = false;
            this.dgvDoneTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDoneTasks.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoneTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoneTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Priority,
            this.Status});
            this.dgvDoneTasks.Location = new System.Drawing.Point(16, 481);
            this.dgvDoneTasks.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDoneTasks.Name = "dgvDoneTasks";
            this.dgvDoneTasks.RowHeadersVisible = false;
            this.dgvDoneTasks.Size = new System.Drawing.Size(777, 114);
            this.dgvDoneTasks.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Column2";
            this.Priority.Name = "Priority";
            this.Priority.Visible = false;
            // 
            // Status
            // 
            this.Status.HeaderText = "Column2";
            this.Status.Name = "Status";
            this.Status.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.label2.Location = new System.Drawing.Point(12, 360);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Remaining subtasks:";
            // 
            // lblRemaining
            // 
            this.lblRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblRemaining.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.lblRemaining.Location = new System.Drawing.Point(228, 360);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(0, 20);
            this.lblRemaining.TabIndex = 8;
            // 
            // lblCompleted
            // 
            this.lblCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCompleted.AutoSize = true;
            this.lblCompleted.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCompleted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.lblCompleted.Location = new System.Drawing.Point(129, 453);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(0, 20);
            this.lblCompleted.TabIndex = 9;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteTaskCtrlDToolStripMenuItem,
            this.deleteAllToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.newToolStripMenuItem.Text = "New (Ctrl+Shift+N)";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(299, 6);
            // 
            // deleteTaskCtrlDToolStripMenuItem
            // 
            this.deleteTaskCtrlDToolStripMenuItem.Name = "deleteTaskCtrlDToolStripMenuItem";
            this.deleteTaskCtrlDToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.deleteTaskCtrlDToolStripMenuItem.Text = "Delete Task (Ctrl+D)";
            this.deleteTaskCtrlDToolStripMenuItem.Click += new System.EventHandler(this.deleteTaskCtrlDToolStripMenuItem_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(302, 26);
            this.deleteAllToolStripMenuItem.Text = "Delete All (Ctrl+Shift+D)";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.deleteAllToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(809, 32);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorThemeToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // colorThemeToolStripMenuItem
            // 
            this.colorThemeToolStripMenuItem.Name = "colorThemeToolStripMenuItem";
            this.colorThemeToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.colorThemeToolStripMenuItem.Text = "Color Theme";
            this.colorThemeToolStripMenuItem.Click += new System.EventHandler(this.colorThemeToolStripMenuItem_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogo.AutoSize = true;
            this.lblLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.lblLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(747, 6);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(54, 18);
            this.lblLogo.TabIndex = 10;
            this.lblLogo.Text = " ZGDS";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLogo.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.btnClearHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearHistory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClearHistory.ForeColor = System.Drawing.Color.White;
            this.btnClearHistory.Location = new System.Drawing.Point(645, 398);
            this.btnClearHistory.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Padding = new System.Windows.Forms.Padding(1);
            this.btnClearHistory.Size = new System.Drawing.Size(148, 41);
            this.btnClearHistory.TabIndex = 11;
            this.btnClearHistory.Text = "Clear History";
            this.btnClearHistory.UseVisualStyleBackColor = false;
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator3,
            this.setDoneToolStripMenuItem,
            this.toolStripMenuItem3});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(182, 134);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 24);
            this.toolStripMenuItem1.Text = "Mark as Current";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 24);
            this.toolStripMenuItem2.Text = "Unmark";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // setDoneToolStripMenuItem
            // 
            this.setDoneToolStripMenuItem.Name = "setDoneToolStripMenuItem";
            this.setDoneToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.setDoneToolStripMenuItem.Text = "Set done";
            this.setDoneToolStripMenuItem.Click += new System.EventHandler(this.setDoneToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 24);
            this.toolStripMenuItem3.Text = "Delete Subtask";
            // 
            // lblOngoingTasks
            // 
            this.lblOngoingTasks.AutoSize = true;
            this.lblOngoingTasks.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOngoingTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.lblOngoingTasks.Location = new System.Drawing.Point(12, 42);
            this.lblOngoingTasks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOngoingTasks.Name = "lblOngoingTasks";
            this.lblOngoingTasks.Size = new System.Drawing.Size(152, 20);
            this.lblOngoingTasks.TabIndex = 7;
            this.lblOngoingTasks.Text = "Ongoing tasks:";
            // 
            // lblOngoingTasksTotal
            // 
            this.lblOngoingTasksTotal.AutoSize = true;
            this.lblOngoingTasksTotal.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOngoingTasksTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.lblOngoingTasksTotal.Location = new System.Drawing.Point(162, 42);
            this.lblOngoingTasksTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOngoingTasksTotal.Name = "lblOngoingTasksTotal";
            this.lblOngoingTasksTotal.Size = new System.Drawing.Size(0, 20);
            this.lblOngoingTasksTotal.TabIndex = 7;
            // 
            // TasksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 608);
            this.Controls.Add(this.btnClearHistory);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.lblCompleted);
            this.Controls.Add(this.lblRemaining);
            this.Controls.Add(this.lblOngoingTasksTotal);
            this.Controls.Add(this.lblOngoingTasks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDoneTasks);
            this.Controls.Add(this.btnSetDone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteTask);
            this.Controls.Add(this.btnNewTask);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TasksForm";
            this.Text = "TASKIfy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TasksForm_FormClosing);
            this.Load += new System.EventHandler(this.TasksForm_Load);
            this.Shown += new System.EventHandler(this.TasksForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TasksForm_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoneTasks)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button btnNewTask;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletaAllTasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetDone;
        private System.Windows.Forms.DataGridView dgvDoneTasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.ToolStripMenuItem deleteTaskCtrlDToolStripMenuItem;
        private System.Windows.Forms.Button btnClearHistory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorThemeToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblOngoingTasks;
        private System.Windows.Forms.Label lblOngoingTasksTotal;
        private System.Windows.Forms.ToolStripMenuItem setDoneToolStripMenuItem;
    }
}

