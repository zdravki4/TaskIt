using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tasks.Menus;
using Tasks.Workers;
using Tasks.Properties;

namespace Tasks
{
    public partial class TasksForm : Form
    {
        #region Constants

        private string _Path = @"C:\Tasky";
        private string _PathLastTab = @"C:\Tasky\LastTab";
        DirectoryInfo dirInfo;
        List<FileInfo> files = new List<FileInfo>();

        TaskManager taskManager;

        TabPage _rightClickedTabPage;

        Dictionary<string, List<Tasky>> onLoadInfo;

        List<string[]> _completedRows = new List<string[]>();

        string lastActivTabOnClose = string.Empty;

        int _rightClickedRow;
        #endregion

        #region Visual
        List<Control> uiControls = new List<Control>();
        List<Label> lblsColor = new List<Label>();

        static int _onGoingTasks = 0;

        #endregion

        public TasksForm()
        {
            InitializeComponent();

            #region UI controls dynamic
            List<Control> controlsDynBackColor = new List<Control>() { menuStrip1, lblLogo, btnNewTask, btnDeleteTask, btnSetDone, btnClearHistory };
            uiControls.AddRange(controlsDynBackColor);

            List<Label> btnsDynColor = new List<Label>() { label1, label2, lblCompleted, lblRemaining, lblOngoingTasks, lblOngoingTasksTotal };
            lblsColor.AddRange(btnsDynColor);
            #endregion

            this.MinimumSize = new Size(650, 450);

            //Hooks a menu strip to Tab Control
            this.tabControl.MouseClick += new MouseEventHandler(tabControl_MouseClick);
            tabControl.Font = new Font("Verdana", 11);

            this.menuStrip1.ForeColor = Color.FromArgb(255, 255, 255);
            taskManager = new TaskManager(this.contextMenuStrip2, ref onLoadInfo, dgvDoneTasks);

            //Main storage path
            #region Get files or Create directory
            if (!Directory.Exists(_Path))
            {
                //Create initial Taks file
                Directory.CreateDirectory(_Path);
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(_Path);
                dirInfo = dir;
                files = dir.GetFiles().ToList();
            }
            #endregion

            #region Get LastTab on close
            lastActivTabOnClose = (string)Settings.Default["LastActiveTabPageName"];
            #endregion

            #region Loading tasks to tabControl
            if (files.Count > 0)
            {
                tabControl.TabPages.Clear();
                tabControl.Selected += TabControl_Selected;

                onLoadInfo = taskManager.LoadTasks(tabControl, files, ref _completedRows);
                taskManager.UpdateLabels(dgvDoneTasks, tabControl, lblRemaining, lblCompleted);
            }
            else
            {
                tabControl.TabPages.Clear();
            }

            //Restoring active tasks
            var activeTasksCodeString = (string)Settings.Default["CurrentTasks"];
            SetActiveTabs(activeTasksCodeString, this.tabControl);

            //MessageBox.Show($"{activeTasksCodeString}");

            #endregion
        }

        private void SetActiveTabs(string code, Control tabControl)
        {
            var backColorActive = (Color)Settings.Default["ThemeColor"];
            var projs = code.Split(';').TakeWhile(p => String.IsNullOrEmpty(p) == false).ToList();
            var pages = tabControl.Controls.OfType<TabPage>().ToList();

            foreach (var proj in projs)
            {
                var pageName = proj.Substring(0, proj.IndexOf('#'));
                var rowIdxs = proj.Substring(proj.IndexOf('#') + 1).Split(',').TakeWhile(p => String.IsNullOrEmpty(p) == false).ToList();

                var rows = pages.Where(n => n.Text.Equals(pageName)).First().Controls.OfType<DataGridView>().First().Rows;
                for (int i = 0; i < rowIdxs.Count; i++)
                {
                    rows[Convert.ToInt16(rowIdxs[i])].DefaultCellStyle.BackColor = backColorActive;
                }
            }
        }

        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            TabPage currentPage = e.TabPage;
            currentPage.Controls.OfType<DataGridView>().First().ClearSelection();

            taskManager.UpdateCompletedOnTabChange(this.dgvDoneTasks, currentPage, onLoadInfo);
            taskManager.UpdateLabels(dgvDoneTasks, tabControl, lblRemaining, lblCompleted);

            dgvDoneTasks.ClearSelection();
        }

        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(this.tabControl, e.Location);

                //Getting the tabpage that was clicked by mouse right click
                for (int i = 0; i < tabControl.TabCount; i++)
                {
                    if (tabControl.GetTabRect(i).Contains(e.Location))
                    {
                        _rightClickedTabPage = (TabPage)tabControl.Controls[i];
                    }
                }
            }
        }

        //Creates new Main task
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskManager.CreateTask(tabControl);

            //Updates list of files
            files = dirInfo.GetFiles().ToList();
        }

        //Delete all Main task from main window and from main location path
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                taskManager.DeleteAllTasks(dirInfo, tabControl);
                files.Clear();
            }
            catch (Exception)
            {

                //throw;
            }
            finally
            {
                lblCompleted.Text = string.Empty;
                lblRemaining.Text = string.Empty;
                dgvDoneTasks.Rows.Clear();
            }
        }

        private void deleteTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (FileInfo f in dirInfo.GetFiles())
            {
                string Task = _rightClickedTabPage.Text;
                if (Path.GetFileNameWithoutExtension(f.Name).Equals(Task))
                {
                    taskManager.DeleteTask(f, tabControl, _rightClickedTabPage);
                }
            }
            files = dirInfo.GetFiles().ToList();
            taskManager.UpdateLabels(dgvDoneTasks, tabControl, lblRemaining, lblCompleted);
        }

        private void deletaAllTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                taskManager.DeleteAllTasks(dirInfo, tabControl);
                files.Clear();
            }
            catch (Exception)
            {

                //throw;
            }
            finally
            {
                dgvDoneTasks.Rows.Clear();
            }

        }

        private void newTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskManager.CreateTask(tabControl);

            //Updates list of files
            files = dirInfo.GetFiles().ToList();
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {
            //Add to grid
            taskManager.AddNewSubtask(tabControl);
            taskManager.UpdateLabels(dgvDoneTasks, tabControl, lblRemaining, lblCompleted);
        }

        //Delete subtask
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            // Delete from grid
            taskManager.DeleteSubTask(tabControl);

            //taskManager.UpdateLabels(dgvDoneTasks, tabControl, lblRemaining, lblCompleted);


        }

        private void TasksForm_Shown(object sender, EventArgs e)
        {
            try
            {
                #region Theme color
                var themeColor = (Color)Settings.Default["ThemeColor"];
                uiControls.ForEach(c => c.BackColor = themeColor);
                lblsColor.ForEach(l => l.ForeColor = themeColor);
                #endregion

                _onGoingTasks = tabControl.Controls.OfType<TabPage>().Count();
                lblOngoingTasksTotal.Text = _onGoingTasks.ToString();

                //Set selected index to open the same tab page, which was active on form closing
                tabControl.SelectedIndex = (int)Settings.Default["LastActiveTabPageIndex"];
                var tab = this.tabControl.SelectedTab.Text;

                var data = onLoadInfo[tab];
                foreach (var tasky in data)
                {
                    if (tasky.Status == false)
                    {
                        var taskyToRowData = tasky.ToString().Split(';');
                        dgvDoneTasks.Rows.Add(taskyToRowData);
                    }
                }

                taskManager.UpdateLabels(dgvDoneTasks, tabControl, lblRemaining, lblCompleted);


            }
            catch (Exception)
            {
            }
        }

        //Set task from progres to done
        private void btnSetDone_Click(object sender, EventArgs e)
        {
            taskManager.SetTaskyDone(this.tabControl, this.dgvDoneTasks, ref onLoadInfo);

            taskManager.UpdateLabels(dgvDoneTasks, tabControl, lblRemaining, lblCompleted);
        }

        private void TasksForm_Load(object sender, EventArgs e)
        {
        }

        private void TasksForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region Saving application settings and status

            Settings.Default["CurrentTasks"] = GetActiveTasksAsString();
            Settings.Default["LastActiveTabPageIndex"] = this.tabControl.SelectedIndex;
            Settings.Default["LastActiveTabPageName"] = this.tabControl.SelectedTab.Name;
            Settings.Default.Save();

            #endregion
        }

        //Shortcuts 
        private void TasksForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Create new subtask
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.N)
            {
                //Add to grid
                taskManager.AddNewSubtask(tabControl);
                taskManager.UpdateLabels(dgvDoneTasks, tabControl, lblRemaining, lblCompleted);
            }

            //Create new Maintask
            if (e.Control && e.Shift && e.KeyCode == Keys.N)
            {
                taskManager.CreateTask(tabControl);

                //Updates list of files
                files = dirInfo.GetFiles().ToList();
            }

            //Delete all Main tasks
            if (e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                try
                {
                    taskManager.DeleteAllTasks(dirInfo, tabControl);
                    files.Clear();
                }
                catch (Exception)
                {

                    //throw;
                }
                finally
                {
                    lblCompleted.Text = string.Empty;
                    lblRemaining.Text = string.Empty;
                    dgvDoneTasks.Rows.Clear();
                }
            }

            if (e.Alt && e.KeyCode == Keys.F4)
            {
                this.Close();
            }
        }

        private void deleteTaskCtrlDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _rightClickedTabPage = (TabPage)tabControl.SelectedTab;
            string Task = tabControl.SelectedTab.Text;

            var file = dirInfo.GetFiles().Where(f => Path.GetFileNameWithoutExtension(f.Name) == Task).First();

            taskManager.DeleteTask(file, tabControl, _rightClickedTabPage);

            files = dirInfo.GetFiles().ToList();
            taskManager.UpdateLabels(dgvDoneTasks, tabControl, lblRemaining, lblCompleted);
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            dgvDoneTasks.Rows.Clear();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            using (AuthorInfo info = new AuthorInfo())
            {
                info.KeyDown += OnEscape_KeyDown;
                //info.
                info.ShowDialog();
            }
        }

        private void OnEscape_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ((AuthorInfo)sender).Close();
            }


        }

        private void colorThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var newThemeColor = colorDialog1.Color;
                Settings.Default["ThemeColor"] = newThemeColor;
                Settings.Default.Save();

                uiControls.ForEach(c => c.BackColor = newThemeColor);
                lblsColor.ForEach(l => l.ForeColor = newThemeColor);

            }
        }

        private void tabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            _onGoingTasks += 1;
            lblOngoingTasksTotal.Text = _onGoingTasks.ToString();

        }

        private void tabControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            _onGoingTasks -= 1;
            lblOngoingTasksTotal.Text = _onGoingTasks.ToString();
        }

        private string GetActiveTasksAsString()
        {
            StringBuilder info = new StringBuilder();
            var pages = tabControl.Controls.OfType<TabPage>().ToList();
            for (int i = 0; i < pages.Count; i++)
            {
                var page = pages[i];
                info.Append(page.Text + "#");
                var rows = page.Controls.OfType<DataGridView>().First().Rows;
                var markedRows = rows.Cast<DataGridViewRow>().Where(r => r.DefaultCellStyle.BackColor == (Color)Settings.Default["ThemeColor"]).ToList();
                for (int j = 0; j <= markedRows.Count - 1; j++)
                {
                    info.Append(markedRows[j].Index.ToString() + ",");
                }

                info.Append(";");
            }

            return info.ToString();
        }

        private void setDoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskManager.SetTaskyDone(tabControl, dgvDoneTasks, ref onLoadInfo);
            taskManager.UpdateLabels(dgvDoneTasks, tabControl, lblRemaining, lblCompleted);
        }
    }
}