using System.Collections.Generic;
using SQLite;

namespace parusapp.Services
{
    public class EventRepository
    {
        SQLiteConnection database;
        public EventRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Event>();
        }
        public IEnumerable<Event> GetItems()
        {
            return database.Table<Event>().ToList();
        }
        public Event GetItem(int id)
        {
            return database.Get<Event>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Event>(id);
        }
        public int SaveItem(Event item)
        {
            if (item.Id != 0) {
                database.Update(item);
                return item.Id;
            }
            else {
                return database.Insert(item);
            }
        }
    }
}