using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks.Workers
{
    public class TaskManager
    {
        static int _rowIndex;
        Point dgvMouseDown;
        static DataGridView _activeGrid = new DataGridView();
        private ContextMenuStrip _contextMenu2;

        public TaskManager(ContextMenuStrip contextMenu2)
        {
            _contextMenu2 = contextMenu2;
            _contextMenu2.ItemClicked += ToolStripMenu2_ItemClicked;
        }

        //Delete all Tasks
        public void DeleteAllTasks(DirectoryInfo dir, TabControl tabControl)
        {
            var filesToDelete = dir.GetFiles();
            foreach ( FileInfo file in filesToDelete )
            {
                file.Delete();

                tabControl.TabPages.Clear();
            }
        }

        //Delete specific task
        public void DeleteTask(FileInfo file, TabControl tabControl, TabPage page)
        {
            file.Delete();
            tabControl.TabPages.Remove(page);
        }

        //Create task
        public void CreateTask(TabControl tabControl)
        {                
            bool isCreatedToPath;
            string task;

            using ( CreateMainTask newTaskProject = new CreateMainTask() )
            {
                newTaskProject.StartPosition = FormStartPosition.CenterScreen;
                newTaskProject.CancelButton = newTaskProject.btnCancel;
                newTaskProject.AcceptButton = newTaskProject.btnCreate;
                newTaskProject.Width = 320;
                newTaskProject.Height = 130;
                newTaskProject.ShowDialog();

                isCreatedToPath = newTaskProject.isTaskCreated;
                task = newTaskProject.TaskName;

                if ( isCreatedToPath )
                {
                    string tabPageName = Path.GetFileNameWithoutExtension(task);

                    TabPage newPage = new TabPage(tabPageName);

                    tabControl.TabPages.Insert(0, newPage);

                    var grid = MakeGrid();
                    grid.MouseDown += DataGridView_MouseDownClick;
                    
                    newPage.Controls.Add(grid);

                    tabControl.SelectedIndex = 0;

                    grid.ClearSelection();
                }
            }
        }
        
        private void DataGridView_MouseDownClick(object sender, MouseEventArgs e)
        {
            dgvMouseDown = e.Location;
            DataGridView dgv = (DataGridView)sender;
            _activeGrid = dgv;
            var hit = dgv.HitTest(e.X, e.Y);

            _rowIndex = hit.RowIndex;            
        }

        //Loads existing task to the program on startup
        public Dictionary<string, List<Tasky>> LoadTasks(TabControl tabControl, List<FileInfo> files, ref List<string[]> completedRows)
        {
            //_contextMenu2.ItemClicked += ToolStripMenu2_ItemClicked;
            Dictionary<string, List<Tasky>> loadInfo = new Dictionary<string, List<Tasky>>();

            for ( int i = 0; i < files.Count; i++ )
            {
                List<Tasky> taskyies = new List<Tasky>();

                string tabPageName = Path.GetFileNameWithoutExtension(files[i].Name);
                tabControl.TabPages.Add(Path.GetFileNameWithoutExtension(files[i].Name));

                var grid = MakeGrid();
                grid.MouseDown += DataGridView_MouseDownClick;

                tabControl.TabPages[i].Controls.Add(grid);

                //Load subtask to grid from path
                var lines = File.ReadAllLines(files[i].FullName);
                foreach ( var line in lines )
                {
                    var rowInfo = line.Split(';');

                    Workers.Tasky restoreTasky = new Tasky(rowInfo);
                    taskyies.Add(restoreTasky);

                    string[] row = new string[3] { restoreTasky.SubTaskName, restoreTasky.Priority, restoreTasky.Status == true ? "In progres" : "Done" };
                    #region Odl
                    //row.Cells[0].Value = restoreTasky.SubTaskName;
                    //row.Cells[1].Value = new DataGridViewComboBoxCell().Value = restoreTasky.Priority;
                    //row.Cells[2].Value = new DataGridViewComboBoxCell().Value = restoreTasky.Status == true ? "In progres" : "Done";

                    //grid.Rows[rowIndex].Cells[0].Value = restoreTasky.SubTaskName;
                    //grid.Rows[rowIndex].Cells[1].Value = new DataGridViewComboBoxCell().Value = restoreTasky.Priority;
                    //grid.Rows[rowIndex].Cells[2].Value = new DataGridViewComboBoxCell().Value = restoreTasky.Status == true ? "In progres" : "Done";
                    #endregion

                    if ( Convert.ToBoolean(restoreTasky.Status) )
                    {
                        grid.Rows.Add(row);
                    }
                    else
                    {
                        completedRows.Add(row);
                    }

                    foreach (DataGridViewRow dgvRow in grid.Rows)
                    {
                        dgvRow.ContextMenuStrip = _contextMenu2;
                    }

                }

                grid.ClearSelection();
                
                if ( loadInfo.Keys.Contains(tabPageName) == false )
                {
                    loadInfo.Add(tabPageName, taskyies);
                }
            }

            return loadInfo;
        }

        private void ToolStripMenu2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var strip = ((ToolStrip)sender).Parent;
            ToolStripItem choice = e.ClickedItem;

            DataGridViewRow hittedRow = _activeGrid.Rows[_rowIndex];
            switch (choice.Name)
            {
                case "toolStripMenuItem1":
                    {
                        hittedRow.DefaultCellStyle.BackColor = Color.Red;
                        _activeGrid.ClearSelection();
                    }
                    break;

                case "toolStripMenuItem2":
                    {
                        hittedRow.DefaultCellStyle.BackColor = Color.White;
                        _activeGrid.ClearSelection();
                    }
                    break;
                default:
                    break;
            }
        }

        //Creates datagridview
        private DataGridView MakeGrid()
        {
            DataGridView grid = new DataGridView();
            
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoResizeRows();

            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;

            var columnInt = grid.Columns.Add("subTaskName", "TODO");
            grid.Columns[columnInt].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var priIndxColumn = grid.Columns.Add("priority", "Priority");
            grid.Columns[priIndxColumn].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grid.Columns[priIndxColumn].SortMode = DataGridViewColumnSortMode.Automatic;

            var statusIndxColumn = grid.Columns.Add("status", "Status");
            grid.Columns[statusIndxColumn].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grid.Columns[statusIndxColumn].Visible = false;
            
            grid.ColumnHeadersHeight = 35;
            grid.Dock = DockStyle.Fill;
            grid.AllowUserToAddRows = false;
            grid.BackgroundColor = Color.FromArgb(255, 255, 255);

            return grid;
        }      
        
        //Create and load sub task to the grid
        public void AddNewSubtask(TabControl tabControl)
        {
            TabPage tab = tabControl.TabPages[tabControl.SelectedIndex];

            var pathToTask = @"C:\Tasky" + @"\" + tab.Text + ".txt";
            var grid = GetActiveGrid(tabControl);

            using ( SubTask subTask = new SubTask() )
            {
                Workers.Tasky newTasky;

                subTask.StartPosition = FormStartPosition.CenterScreen;
                subTask.CancelButton = subTask.btnCancel;
                subTask.AcceptButton = subTask.btnOK;

                DialogResult result = subTask.ShowDialog();

                //Get task object from dialog
                newTasky = subTask.Tasky;

                if ( newTasky != null )
                {
                    newTasky.Status = true; /*default value*/

                    DataGridViewRow row = new DataGridViewRow();
                    row.ContextMenuStrip = _contextMenu2;
                    int rowIndex = grid.Rows.Add(row);

                    grid.Rows[rowIndex].Cells[0].Value = newTasky.SubTaskName;
                    grid.Rows[rowIndex].Cells[1].Value =  String.IsNullOrEmpty(newTasky.Priority) ? "Low" : newTasky.Priority;
                    grid.Rows[rowIndex].Cells[2].Value =  newTasky.Status ;

                    //Save to file
                    var taskyRecord = newTasky.ToString();
                    using ( TextWriter tw = new StreamWriter(pathToTask, true) )
                    {
                        tw.WriteLine(taskyRecord);
                    }
                }
            }
        }

        //Get active grid view
        public DataGridView GetActiveGrid(TabControl tabControl)
        {
            var tab = tabControl.SelectedTab;
            DataGridView grid = (DataGridView) tab.Controls[0];

            return grid;
        }

        public void DeleteSubTask(TabControl tabControl)
        {
            TabPage tab = tabControl.TabPages[tabControl.SelectedIndex];
            var pathToTask = PathToTaskProject(tab);
            //var pathToTask = @"C:\Tasky" + @"\" + tab.Text + ".txt";

            var grid = GetActiveGrid(tabControl);

            List<string> lines = File.ReadAllLines(pathToTask).ToList();
            string search = string.Empty;

            var cells = grid.SelectedCells;
            int indx = cells[0].RowIndex;

            search = grid.Rows[indx].Cells[0].Value.ToString();
            grid.Rows.RemoveAt(indx);

            grid.Update();

            //Remove subtask from file
            int indexToDelete;
            for ( int i = 0; i < lines.Count; i++ )
            {
                if ( lines[i].Contains(search) )
                {
                    indexToDelete = i;
                    lines.RemoveAt(indexToDelete);
                }
            }

            File.WriteAllLines(pathToTask, lines.ToArray());
        }

        public void SetTaskyDone(TabControl tabControl, DataGridView completed, ref Dictionary<string, List<Tasky>> loadInfo)
        {
            try
            {
                TabPage tab = tabControl.TabPages[tabControl.SelectedIndex];
                var pathToTask = PathToTaskProject(tab);

                var grid = GetActiveGrid(tabControl);

                var indx = grid.SelectedCells[0].RowIndex;
                var row = grid.Rows[indx];
                row.Cells[2].Value = false.ToString();

                //Update grid ongoing tasks
                grid.Rows.Remove(row);

                //Send to Completed
                completed.Rows.Add(row);
                completed.ClearSelection();

                //set to done in txt file and in dictionary or reload dictionary (new method)

                UpdateSubTaskToFile(row, pathToTask);

                //Update state of onLoadInfo Dictionary
                foreach ( var key in loadInfo.Keys )
                {
                    if ( tab.Text == key )
                    {
                        List<Tasky> subtasks = loadInfo[key];
                        foreach ( Tasky subTask in subtasks )
                        {
                            if ( subTask.SubTaskName == row.Cells[0].Value.ToString() )
                            {
                                subTask.Status = false;
                            }
                        }
                    }
                }
            }
            catch ( Exception )
            {

                //throw;
            }

        }

        public string PathToTaskProject(TabPage tab)
        {
            string pathToTask;
            return pathToTask = @"C:\Tasky" + @"\" + tab.Text + ".txt";
        }

        public void UpdateSubTaskToFile(DataGridViewRow row, string pathToTask)
        {
            List<string> lines = File.ReadAllLines(pathToTask).ToList();
            string search = row.Cells[0].Value.ToString();

            List<string> rowData = new List<string>() { row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString() };
            string updateState = String.Join(";", rowData);

            int indexToUpdate;
            for ( int i = 0; i < lines.Count; i++ )
            {
                if ( lines[i].Contains(search) )
                {
                    indexToUpdate = i;
                    lines.RemoveAt(indexToUpdate);
                }
            }

            lines.Add(updateState);

            File.WriteAllLines(pathToTask, lines);
        }

        public void UpdateCompletedOnTabChange(DataGridView completed, TabPage tab, Dictionary<string, List<Tasky>> onLoadInfo)
        {
            try
            {
                completed.Rows.Clear();
                foreach ( string key in onLoadInfo.Keys )
                {
                    if ( key == tab.Text )
                    {
                        List<Tasky> tasks = onLoadInfo[key];

                        var convertedToRows = ConvertTaskysToRowData(tasks);

                        foreach ( var row in convertedToRows )
                        {
                            completed.Rows.Add(row);
                        }
                    }
                }

            }
            catch ( Exception )
            {

            }
        }

        public List<string[]> ConvertTaskysToRowData(List<Tasky> tasks)
        {
            List<string[]> converted = new List<string[]>();

            foreach ( Tasky subTasky in tasks )
            {
                if ( subTasky.Status == false )
                {
                    converted.Add(subTasky.ToString().Split(';'));
                }
            }

            return converted;
        }

        public void UpdateLabels(DataGridView completed, TabControl tabControl, Label remaining, Label done)
        {
            try
            {
                done.Text = completed.Rows.Count.ToString();
                remaining.Text = GetActiveGrid(tabControl).Rows.Count.ToString();
            }
            catch ( Exception )
            {

                //throw;
            }
        }

        public void ClearDGVCompleted(TabControl tabControl, DataGridView completed)
        {
            var grid = GetActiveGrid(tabControl);
            if ( grid.Rows.Count == 0 )
            {
                completed.Rows.Clear();
            }
        }

        //Calculates the index of the last active tab that were selected before program starts closing
        public int GetLastActiveTabOnClose(List<FileInfo> files, string lastActivTabOnClose)
        {
            int counter = 0;
            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].Name.Contains(lastActivTabOnClose))
                {
                    counter = i;
                }
            }

            return counter;
        }
    }
}
