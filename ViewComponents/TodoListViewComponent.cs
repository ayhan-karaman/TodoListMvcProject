using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using TodoListMvc.Application;
using TodoListMvc.Models;

namespace TodoListMvc.ViewComponents
{
    public class TodoListViewComponent:ViewComponent
    {
        private readonly TodoService _todoService;
        public TodoListViewComponent(TodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var todos = await _todoService.GetTaskAsync();
            var model = new TodoListViewModel()
            {
              Todos =  todos,
              CurrentTodo = HttpContext.Request.Query["todo"]
            };

            return View(model);
        }
    }
}