using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoListMvc.Application;
using TodoListMvc.Models;

namespace TodoListMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly TodoService _todoService;

        public HomeController(TodoService todoService)
        {
            _todoService = todoService;
        }

        public IActionResult NewTodo()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> NewTodo(Todo newTodo)
        {
             newTodo.TodoDateTime = DateTime.Now;
             if(ModelState.IsValid)
             {
               await _todoService.CreateAsync(newTodo);
               return RedirectToAction("newTodo");
             }
            return View();
            
        }

    
        public async Task<IActionResult> DeleteTodo(string id)
        {
            
             if(ModelState.IsValid)
             {
               await _todoService.DeleteAsync(id);
               return RedirectToAction("NewTodo");
             }
            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> EditTodo(string id)
        {
            // newTodo.TodoDateTime = DateTime.Now;
       
             
             if(ModelState.IsValid)
             {
               
               var todo =  await _todoService.GetTodoAsync(id);
               todo.IsCompleted = todo.IsCompleted ? false : true;
               await _todoService.UpdateAsync(id, todo);
               
               return RedirectToAction("NewTodo", "Home");
             }
            return View();
            
        }
    }
}
