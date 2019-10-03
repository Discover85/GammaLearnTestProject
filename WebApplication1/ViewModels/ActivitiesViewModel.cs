using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class ActivitiesViewModel
    {
        public string Course { get; set; }
        public string Assignment { get; set; }
        public int Users{ get; set; }
        public int Accepted{ get; set; }
        public int Rejected{ get; set; }
        public int Pending{ get; set; }
    }
}
