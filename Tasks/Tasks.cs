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
using Tasks.Workers;

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

        public TasksForm()
        {
            InitializeComponent();

            this.MinimumSize = new Size(650, 450);
            
            //Hooks a menu strip to Tab Control
            this.tabControl.MouseClick += new MouseEventHandler(tabControl_MouseClick);
            tabControl.Font = new Font("Verdana", 11);

            this.menuStrip1.ForeColor = Color.FromArgb(255, 255, 255);
            taskManager = new TaskManager(this.contextMenuStrip2);

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
            if (!Directory.Exists(_PathLastTab))
            {
                //Create folder that will hold info about last active tab
                Directory.CreateDirectory(_PathLastTab);

                var f = File.Create(_PathLastTab + @"\lastActiveTab.txt");
                f.Close();
                lastActivTabOnClose = string.Empty;
            }
            else
            {
                var lastTab = Directory.GetFiles(_PathLastTab);
                var data = File.ReadAllLines(lastTab[0]);
                lastActivTabOnClose = data[0];
            }
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
            #endregion
        }
       
        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            TabPage currentPage = e.TabPage;
            currentPage.Controls.OfType<DataGridView>().First().ClearSelection();

            taskManager.UpdateCompletedOnTabChange(this.dgvDoneTasks, currentPage, onLoadInfo);
            taskManager.UpdateLabels(dgvDoneTasks, tabControl, lblRemaining, lblCompleted);
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

            taskManager.UpdateLabels(dgvDoneTasks, tabControl, lblRemaining, lblCompleted);
            //TODO delete from txt file

        }

        private void TasksForm_Shown(object sender, EventArgs e)
        {
            try
            {
                //Set selected index to open the same tab page, which was active on form closing
                tabControl.SelectedIndex = taskManager.GetLastActiveTabOnClose(files, lastActivTabOnClose);

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
            string last = this.tabControl.SelectedTab.Text;
            string[] lastTab = new string[1] { last.ToString() };

            File.WriteAllLines(_PathLastTab + @"\lastActiveTab.txt", lastTab);
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

        
    }
}