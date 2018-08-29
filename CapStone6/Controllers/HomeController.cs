using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapStone6.Models;

namespace CapStone6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CapStone6Entities ORM = new CapStone6Entities();
            ViewBag.Tasks = ORM.Tasks.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddNewTask()
        {
            CapStone6Entities ORM = new CapStone6Entities();
            return View();
        }

        public ActionResult SaveTask(Task newTask)
        {  
            CapStone6Entities ORM = new CapStone6Entities();
            ORM.Tasks.Add(newTask);
            ORM.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SwitchComplete(int taskID)
        {
            CapStone6Entities ORM = new CapStone6Entities();

            Task locateID = ORM.Tasks.Find(taskID);
           
                locateID.complete = !locateID.complete;
            

            ORM.Entry(locateID).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteTask(int taskID)
        {
            CapStone6Entities ORM = new CapStone6Entities();

            Task taskToDelete = ORM.Tasks.Find(taskID);
            ORM.Tasks.Remove(taskToDelete);
            ORM.SaveChanges();


            return RedirectToAction("Index");
        }


    }
}