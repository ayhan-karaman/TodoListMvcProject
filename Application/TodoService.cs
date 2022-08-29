using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TodoListMvc.DatabaseSettings;
using TodoListMvc.Models;

namespace TodoListMvc.Application
{
    public class TodoService
    {
        private readonly IMongoCollection<Todo> _todosCollection;
        public TodoService(IOptions<TodoListDatabaseSettings> todoListDatabaseSettings)
        {
            var mongoClient = new MongoClient(todoListDatabaseSettings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(todoListDatabaseSettings.Value.DatabaseName);
            _todosCollection = database.GetCollection<Todo>(todoListDatabaseSettings.Value.TodoListCollectionName);

        }

        public async Task<List<Todo>> GetTaskAsync() => await _todosCollection.Find(_=> true).ToListAsync();
        public async Task<Todo> GetTodoAsync(string id) => await _todosCollection.Find(x => x.Id == id).SingleOrDefaultAsync();
        public async Task CreateAsync(Todo newTodo) => await _todosCollection.InsertOneAsync(newTodo);
        public async Task UpdateAsync(string id, Todo updateTodo) => await _todosCollection.ReplaceOneAsync(x => x.Id == id,updateTodo);
        public async Task DeleteAsync(string id) => await _todosCollection.DeleteOneAsync(x=>x.Id == id);
    }
}