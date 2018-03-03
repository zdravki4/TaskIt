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
                    newPage.Controls.Add(grid);

                    tabControl.SelectedIndex = 0;
                }
            }
        }

        //Loads existing task to the program on startup
        public Dictionary<string, List<Tasky>> LoadTasks(TabControl tabControl, List<FileInfo> files, ref List<string[]> completedRows)
        {
            Dictionary<string, List<Tasky>> loadInfo = new Dictionary<string, List<Tasky>>();

            for ( int i = 0; i < files.Count; i++ )
            {
                List<Tasky> taskyies = new List<Tasky>();

                string tabPageName = Path.GetFileNameWithoutExtension(files[i].Name);
                tabControl.TabPages.Add(Path.GetFileNameWithoutExtension(files[i].Name));

                var grid = MakeGrid();

                tabControl.TabPages[i].Controls.Add(grid);

                //Load subtask to grid from path
                var lines = File.ReadAllLines(files[i].FullName);
                foreach ( var line in lines )
                {
                    var rowInfo = line.Split(';');

                    Workers.Tasky restoreTasky = new Tasky(rowInfo);
                    taskyies.Add(restoreTasky);

                    //DataGridViewRow row = new DataGridViewRow();

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

                }
                

                if ( loadInfo.Keys.Contains(tabPageName) == false )
                {
                    loadInfo.Add(tabPageName, taskyies);
                }
            }

            return loadInfo;
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

            #region Old code
            //DataGridViewTextBoxCell comboPriority = new DataGridViewTextBoxCell();
            //comboPriority.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //comboPriority.Name = "Priority";
            ////comboPriority.Items.Add("High");
            ////comboPriority.Items.Add("Medium");
            ////comboPriority.Items.Add("Low");
            //grid.Columns.Add(comboPriority);

            //DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
            //comboColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //comboColumn.Name = "Status";
            //comboColumn.Items.Add("In progres");
            //comboColumn.Items.Add("done");
            //grid.Columns.Add(comboColumn);
            #endregion

            grid.ColumnHeadersHeight = 35;
            grid.Dock = DockStyle.Fill;
            grid.AllowUserToAddRows = false;
            grid.BackgroundColor = Color.FromArgb(255, 255, 255);

            //Addig event handler to capture combobox values changed
            //grid.EditingControlShowing += Grid_EditingControlShowing;

            //grid.CellValueChanged += Grid_CellValueChanged;

            return grid;
        }

        #region OldCode2
        //private void Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    //throw new NotImplementedException();

        //    DataGridView grid = (DataGridView) sender;
        //    var cells = grid.SelectedCells;

        //    //switch ( cellContent )
        //    //{
        //    //    case "In progres":
        //    //    case "done":
        //    //        {
        //    //            int rowIndex = cell.RowIndex;

        //    //            MessageBox.Show($"{rowIndex}");
        //    //            break;
        //    //        }
        //    //    default:
        //    //        break;
        //    //}

        //}

        //Part that should handle combobox value change
        //private void Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{

        //    ComboBox cmbBox = e.Control as ComboBox;
        //    if ( cmbBox != null )
        //    {
        //        //Hook event that tracks change
        //        cmbBox.SelectionChangeCommitted -= new EventHandler(ComboBox_SelectionChangeCommitted);
        //        cmbBox.SelectionChangeCommitted += new EventHandler(ComboBox_SelectionChangeCommitted);
        //    }
        //}

        //Modify txt file to change the task state
        //private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    DataGridViewComboBoxEditingControl ctrlBox = (DataGridViewComboBoxEditingControl) sender;
        //    Point point =
        //    var text = ctrlBox.Text;
        //    //var row = sender as DataGridViewRow;
        //    //var index = row.Selected;
        //    //ComboBox box = sender as ComboBox;

        //    switch ( text )
        //    {
        //        case "In progres":
        //        case "done":
        //            {
        //                ComboBox box = (ComboBox) sender;
        //                var test = box.Name;

        //                MessageBox.Show($"{test}");
        //                break;
        //            }
        //        default:
        //            break;
        //    }
        //}

        //private void ComboBox_SelectedIndexChange(object sender, EventArgs e)
        //{
        //    //ComboBox box = sender as ComboBox;
        //    //MessageBox.Show($"{box.Text}");
        //}
        #endregion

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
                    int rowIndex = grid.Rows.Add(row);

                    grid.Rows[rowIndex].Cells[0].Value = newTasky.SubTaskName;
                    grid.Rows[rowIndex].Cells[1].Value = /*new DataGridViewComboBoxCell().Value =*/ newTasky.Priority;
                    grid.Rows[rowIndex].Cells[2].Value = /*new DataGridViewComboBoxCell().Value =*/ newTasky.Status /*== true ? "In progres" : "Done"*/;

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
    }
}
