using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;
using parusapp.Models;
using System;

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
            //var List = new ObservableCollection<Event>(database.Table<Event>().ToList()); 
            //var EventsList = new ObservableCollection<Event>(database.Table<Event>().ToList());
            //var EventsListView = new ObservableCollection<EventView>(database.Table<EventView>().ToList());

            //var EventsList = database.Table<Event>().ToList();
            //var EventsCollection = new ObservableCollection<EventView>();
            /*
            foreach (var Event in EventsList) {
                EventView eventview = new EventView(); 
                eventview.Id = Event.Id;
                eventview.Clnevents_id = Event.Clnevents_id;
                eventview.Event_numb = Event.Event_numb;
                eventview.Event_stat = Event.Event_stat;
                if (Event.Reg_date != null)
                    eventview.Reg_date = Event.Reg_date.Value.ToString("dd.MM.yyyy HH:mm:ss");
                if (Event.Change_date != null) 
                  eventview.Change_date = Event.Change_date.Value.ToString("dd.MM.yyyy HH:MM:ss");
                
                eventview.Event_descr = Event.Event_descr;

                EventsCollection.Add(eventview);
            }
            return EventsCollection;
            */
            
             //old code
            var EventsList = new ObservableCollection<Event>(database.Table<Event>().ToList());
            var EventsCollection = new ObservableCollection<Event>();
            foreach (var Event in EventsList) {
                EventsCollection.Add(Event); //This is important
            }
            return EventsCollection;
             
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
        public void MaxRecord()
        {
            var eventlist = database.Query<Event>(
                   "SELECT * FROM Events WHERE [_id] = (select max([_id]) from Events)");

            foreach (var eventrec in eventlist) {
                DeleteItem(eventrec.Id);
            }
        }

    }
}