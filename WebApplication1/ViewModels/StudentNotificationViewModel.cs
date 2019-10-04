using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class NotificationViewModel
    {

        public string Course { get; set; }
        public string Assignment { get; set; }
        public string PersonName{ get; set; }
        public DateTime IssueDate{ get; set; }
        public bool? Status { get; set; } 
        public string StatusTitle { get; set; } = "Pending";
        public string Title { get; set; }
        public string Id { get;  set; }
    }
}
