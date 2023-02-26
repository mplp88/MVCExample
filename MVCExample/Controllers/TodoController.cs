using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCExample.Data;
using MVCExample.Models;

namespace MVCExample.Controllers
{
    public class TodoController : Controller
    {
        TodoListContext _db;
        public TodoController(TodoListContext db)
        {
            _db = db;
        }

        // GET: TodoController
        public ActionResult Index()
        {
            List<Todo> todos = _db.Todos.ToList();

            return View(todos);
        }

        // GET: TodoController/Details/5
        public ActionResult Details(int id)
        {
            Todo todo = _db.Todos.First(todo => todo.Id == id);

            return View(todo);
        }

        // GET: TodoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Todo todo)
        {
            try
            {
                _db.Todos.Add(todo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(todo);
            }
        }

        // GET: TodoController/Edit/5
        public ActionResult Edit(int id)
        {
            Todo todo = _db.Todos.First(todo => todo.Id == id);
            return View(todo);
        }

        // POST: TodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Todo todoActualizado)
        {
            try
            {
                if(_db.Todos.Any(todo => todo.Id == id))
                {
                    _db.Update(todoActualizado);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                Todo todo = _db.Todos.First(todo => todo.Id == id);
                return View(todo);
            }
        }

        // GET: TodoController/Delete/5
        public ActionResult Delete(int id)
        {
            Todo todo = _db.Todos.First(todo => todo.Id == id);
            return View(todo);
        }

        // POST: TodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DoDelete(int id)
        {
            try
            {
                Todo todo = _db.Todos.First(todo => todo.Id == id);
                _db.Todos.Remove(todo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                Todo todo = _db.Todos.First(todo => todo.Id == id);
                return View(todo);
            }
        }
    }
}
