using System;

namespace TodoListMvc.Models
{
    public class Todo
    {
        public string Id { get; set; }
        public string TodoWork { get; set; }
        public DateTime TodoDateTime { get; set; }
    }
}