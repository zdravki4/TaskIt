using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Workers
{
    public class Tasky
    {
        public string SubTaskName { get; set; }
        public string Priority { get; set; }
        public bool Status { get; set; }

        public Tasky()
        {

        }

        public Tasky(string[] rowInfo)
        {
            SubTaskName = rowInfo[0];
            Priority = rowInfo[1];
            Status = Convert.ToBoolean(rowInfo[2]);
        }

        public override string ToString()
        {
            return SubTaskName + ";" + Priority + ";" + Status;
        }
    }
}
