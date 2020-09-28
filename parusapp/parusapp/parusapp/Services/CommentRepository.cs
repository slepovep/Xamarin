using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;
using parusapp.Models;
using System;

namespace parusapp.Services
{
    public class CommentRepository
    {
        SQLiteConnection database;
        public CommentRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Comment>();
        }
        public IEnumerable<Comment> GetItems()
        {
            //var List = new ObservableCollection<Comment>(database.Table<Comment>().ToList()); 
            //var CommentsList = new ObservableCollection<Comment>(database.Table<Comment>().ToList());
            //var CommentsListView = new ObservableCollection<CommentView>(database.Table<CommentView>().ToList());

            //var CommentsList = database.Table<Comment>().ToList();
            //var CommentsCollection = new ObservableCollection<CommentView>();
            /*
            foreach (var Comment in CommentsList) {
                CommentView eventview = new CommentView(); 
                eventview.Id = Comment.Id;
                eventview.Clnevents_id = Comment.Clnevents_id;
                eventview.Comment_numb = Comment.Comment_numb;
                eventview.Comment_stat = Comment.Comment_stat;
                if (Comment.Reg_date != null)
                    eventview.Reg_date = Comment.Reg_date.Value.ToString("dd.MM.yyyy HH:mm:ss");
                if (Comment.Change_date != null) 
                  eventview.Change_date = Comment.Change_date.Value.ToString("dd.MM.yyyy HH:MM:ss");
                
                eventview.Comment_descr = Comment.Comment_descr;

                CommentsCollection.Add(eventview);
            }
            return CommentsCollection;
            */
            
             //old code
            var CommentsList = new ObservableCollection<Comment>(database.Table<Comment>().ToList());
            var CommentsCollection = new ObservableCollection<Comment>();
            foreach (var Comment in CommentsList) {
                CommentsCollection.Add(Comment); //This is important
            }
            return CommentsCollection;
             
        }
        public Comment GetItem(int id)
        {
            return database.Get<Comment>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Comment>(id);
        }
        public int SaveItem(Comment item)
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
            var eventlist = database.Query<Comment>(
                   "SELECT * FROM Comments WHERE [_id] = (select max([_id]) from Comments)");

            foreach (var eventrec in eventlist) {
                DeleteItem(eventrec.Id);
            }
        }

    }
}