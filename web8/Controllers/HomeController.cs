using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using web8.Models.Entity;

namespace web8.Controllers
{
    public class HomeController : Controller
    {
        crudMVC212 DB = new crudMVC212();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(crudMVC crud)
        {
            if (crud.ID == 0)
            {
                DB.crudMVCs.Add(crud);
            }
            else
            {
                var updateData = DB.crudMVCs.Find(crud.ID);
                if (updateData == null)
                {
                    return HttpNotFound();
                }
                updateData.ProjectName = crud.ProjectName;
                updateData.Owner = crud.Owner;

            }
            DB.SaveChanges();
            return RedirectToAction("ToDoList", "Home");
        }
        public ActionResult Update(int id)
        {
            var model = DB.crudMVCs.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Create", model);
        }
        public ActionResult Delete(int id)
        {
            var deleteOrder = DB.crudMVCs.Find(id);
            if (deleteOrder == null)
            {
                return HttpNotFound();
            }
            DB.crudMVCs.Remove(deleteOrder);
            DB.SaveChanges();
            return RedirectToAction("ToDoList", "Home");
        }

        public ActionResult ToDoList()
        {
            return View(DB.crudMVCs.ToList());
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
    }
}