using TodoList.Models;

namespace TodoList.ViewModels
{
    public class ListTodoViewModel
    {
        public ICollection<Todo> Todos { get; set; } = new List<Todo>();        
    }
}