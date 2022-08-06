using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using TodoList.Contexts;
using TodoList.Models;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var todos = _context.Todos.OrderBy(x => x.Date ).ToList();
            var viewModel = new ListTodoViewModel { Todos = todos };
            ViewData["Title"] = "Lista de Tarefas";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastrar nova Tarefa";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create(FormTodoViewModel data)
        {
            var todo = new Todo(data.Title, data.Date);
            _context.Add(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // todo/edit/id
        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Editar Tarefa";
            var todo = _context.Todos.Find(id);
            if (todo is null) return NotFound();
            var viewModel = new FormTodoViewModel { Title = todo.Title, Date = todo.Date };
            return View("Form",viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, FormTodoViewModel data)
        {
            var todo = _context.Todos.Find(id);
            if (todo is null) return NotFound();
            todo.Title = data.Title;
            todo.Date = data.Date;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Todo/Delete/Id
        public IActionResult Delete(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo is null) return NotFound();
            _context.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // /Todo/ToComplete/1
        public IActionResult ToComplete(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo is null) return NotFound();
            todo.IsCompleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}