using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    public partial class SubTask : Form
    {

        public string _subTask { get; set; }
        public string Priority { get; set; }
        public Workers.Tasky Tasky { get; set; }

        public SubTask()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Workers.Tasky tasky = new Workers.Tasky();
            tasky.SubTaskName = subTaskName.Text;
            tasky.Priority = comboBoxPriority.Text;

            Tasky = tasky;

            //_subTask = subTaskName.Text;
            //Priority = comboBoxPriority.Text;
            this.Close();
        }
    }
}
