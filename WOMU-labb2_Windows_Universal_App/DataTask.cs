using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOMU_labb2_Windows_Universal_App
{
    class DataTask
    {
        public int TaskID { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime DeadlineDateTime { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
    }
}
