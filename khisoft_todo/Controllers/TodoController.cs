using khisoft_todo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace khisoft_todo.Controllers
{
    public class TodoController : Controller
    {
        TodoDbDataContext db = new TodoDbDataContext(); 

        // GET: Todo
        public ActionResult Index()
        {
            var data = from b in db.todos select b;
            return View(data);
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        public ActionResult Create(todo collection)
        {
            try
            {
                // TODO: Add insert logic here
                collection.status = 0;
                db.todos.InsertOnSubmit(collection);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Todo/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                // TODO: Add update logic here
                todo t = db.todos.Single(x => x.id == id );
                t.status = 1;
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                todo t = db.todos.Single(x => x.id == id);
                db.todos.DeleteOnSubmit(t);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
