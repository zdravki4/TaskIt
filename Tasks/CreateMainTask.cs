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

namespace Tasks
{
    public partial class CreateMainTask : Form
    {
        private string _Path = @"C:\Tasky";

        public bool isTaskCreated { get; set; }
        public string TaskName { get; set; }

        public CreateMainTask()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string taskNameShort = txtBoxName.Text;

            string fullName = _Path + @"\" + taskNameShort + ".txt";
            if ( File.Exists(fullName) )
            {
                MessageBox.Show("The already exists!");
                return;
            }
            else
            {
                try
                {
                    var fs = File.Create(fullName);
                    fs.Close();
                    TaskName = fullName;

                    this.Close();

                    isTaskCreated = true;
                }
                catch ( Exception )
                {
                    isTaskCreated = false;
                    throw;
                }
            }
        }
    }
}
