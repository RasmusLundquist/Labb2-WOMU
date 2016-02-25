using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class TaskDetail
    {
        public int TaskID { get; set; }
        public System.DateTime BeginDateTime { get; set; }
        public System.DateTime DeadlineDateTime { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }

        public List<Users> Staff { get; set; }
    }
}