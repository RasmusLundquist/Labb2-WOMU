using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TaskController : Controller
    {
        private DatabasEntities db = new DatabasEntities();

        // GET: Task
        public ActionResult Index()
        {
            List<TaskDetail> tasksList = new List<TaskDetail>();
            List<Tasks> Task = db.Tasks.ToList();


            foreach(var item in Task)
            {
                TaskDetail newTask = new TaskDetail();
                newTask.BeginDateTime = item.BeginDateTime;
                newTask.DeadlineDateTime = item.DeadlineDateTime;
                newTask.Requirements = item.Requirements;
                newTask.TaskID = item.TaskID;
                newTask.Title = item.Title;

                newTask.Staff = item.Users.ToList();
                tasksList.Add(newTask);

            }
            
            return View(tasksList);
        }

      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
