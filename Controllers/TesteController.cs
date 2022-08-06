
using Microsoft.AspNetCore.Mvc;


namespace TodoList.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}