using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class StudentAssignmentViewModel
    {

        public string Course { get; set; }
        public string Assignment { get; set; }
        public string Teacher{ get; set; }
        public DateTime IssueDate{ get; set; }
        public bool? Status { get; set; } 
        public string StatusTitle { get; set; } = "Pending";
    }
}
