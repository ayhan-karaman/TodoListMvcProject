namespace TodoListMvc.DatabaseSettings
{
    public class TodoListDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TodoListCollectionName { get; set; } = null!;
    }
}