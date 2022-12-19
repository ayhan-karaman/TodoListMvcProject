using System.Collections.Generic;

namespace TodoListMvc.Models
{
    public class TodoListViewModel
    {
        public List<Todo> Todos { get; set; }
        public string CurrentTodo { get; set; }
    }
}