using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;
using System.Threading.Tasks;
using parusapp.Models;

namespace parusapp.Services
{
    public class EventRepository
    {
        SQLiteAsyncConnection database;
        public EventRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            //database.CreateTable<Event>();
            //database.CreateTable<Comment>();
            database.CreateTableAsync<Event>().Wait();
            database.CreateTableAsync<Comment>().Wait();
        }



        public async Task CreateTable()
        {
            await database.CreateTableAsync<Event>();
            await database.CreateTableAsync<Comment>();
        }

        public async Task<IEnumerable<Event>> GetItems()
        {
            //return await database.Table<Event>().ToListAsync();

            var EventsList = new ObservableCollection<Event>(await database.Table<Event>().ToListAsync());
            var EventsCollection = new ObservableCollection<Event>();
            foreach (var Event in EventsList) {
                EventsCollection.Add(Event); //This is important
            }
            return EventsCollection;

        }


        public async Task<IEnumerable<Comment>> GetCommentItems(int Event_id)
        {
            var CommentsList = new ObservableCollection<Comment>(await database.QueryAsync<Comment>(
                "SELECT * FROM Comments WHERE [Event_id] = ?", Event_id));

            var CommentsCollection = new ObservableCollection<Comment>();
            foreach (var Comment in CommentsList) {
                CommentsCollection.Add(Comment); //This is important
            }
            return CommentsCollection;

        }


        /*
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
        /*           var EventsList = new ObservableCollection<Event>(database.Table<Event>().ToList());
                   var EventsCollection = new ObservableCollection<Event>();
                   foreach (var Event in EventsList) {
                       EventsCollection.Add(Event); //This is important
                   }
                   return EventsCollection;

               }
       */
        /*       public IEnumerable<Comment> GetCommentItems(int Event_id)
               {
                   var CommentsList = new ObservableCollection<Comment>(database.Query<Comment>(
                       "SELECT * FROM Comments WHERE [Event_id] = ?", Event_id));

                   var CommentsCollection = new ObservableCollection<Comment>();
                   foreach (var Comment in CommentsList) {
                       CommentsCollection.Add(Comment); //This is important
                   }
                   return CommentsCollection;

               }*/
        public async Task<Event> GetItem(int id)
        {
            return await database.GetAsync<Event>(id);
        }
        public async Task<int> DeleteItem(int id)
        {
            return await database.DeleteAsync<Event>(id);
        }
        public async Task<int> SaveItem(Event item)
        {
            if (item.Id != 0) {
                await database.UpdateAsync(item);
                return item.Id;
            }
            else {
                return await database.InsertAsync(item);
            }
        }
        public async void MaxRecord()
        {
            var eventlist = await database.QueryAsync<Event>(
                   "SELECT * FROM Events WHERE [_id] = (select max([_id]) from Events)");

            foreach (var eventrec in eventlist) {
                await DeleteItem(eventrec.Id);
            }
        }

        public async Task<Comment> GetCommentItem(int id)
        {
            return await database.GetAsync<Comment>(id);
        }

        public async Task<int> SaveCommentItem(Comment item)
        {
            if (item.Id != 0) {
                await database.UpdateAsync(item);
                return item.Id;
            }
            else {
                return await database.InsertAsync(item);
            }
        }

        public async void DeleteComments()
        {
            var commentlist = await database.QueryAsync<Comment>(
                   "select * FROM Comments");

            foreach (var commentrec in commentlist) {
                //DeleteItem(commentrec.Id);
                await database.DeleteAsync<Comment>(commentrec.Id);
            }
        }

    }
}