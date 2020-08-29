using System.Collections.Generic;
using SQLite;
using parusapp.Models;

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
            var Item1 = database.Table<Event>().ToList();
            return Item1;
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