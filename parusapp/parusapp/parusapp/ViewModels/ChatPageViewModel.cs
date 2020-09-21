using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using parusapp.Models;
using Xamarin.Forms;
using SQLite;

namespace parusapp.ViewModels
{
    public class ChatPageViewModel: INotifyPropertyChanged
    {
        //SQLiteConnection database;
        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }

        public Queue<Message> DelayedMessages { get; set; } = new Queue<Message>();
        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();
        public string TextToSend { get; set; }
        public ICommand OnSendCommand { get; set; }
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }

        public ChatPageViewModel(int Event_id)
        {
            //var database = App.database;
            //App.Database.DeleteComments();

            //Comment commentrec = new Comment();
            //commentrec.Event_id = Event_id;
            //commentrec.Comment_text = "IN_COMMENT";
            //commentrec.User = "User1";
            //App.Database.SaveCommentItem(commentrec);

            var CommentsList = App.Database.GetCommentItems(Event_id);

            //database = new SQLiteConnection(databasePath);
            //database.CreateTable<Comment>();

            //var CommentsList = new ObservableCollection<Comment>(database.Table<Comment>().ToList());
            //var CommentsCollection = new ObservableCollection<Comment>();
     //       foreach (var Comment in CommentsList) {
     //           Messages.Insert(0, new Message() { Text = Comment.Comment_text, User = Comment.User, Reg_date = Comment.Reg_date.Value.ToString("dd.MM.yyyy HH:mm") });
     //       }

            //Messages.Insert(0, new Message() { Text = Comment.Comment_text, User = Comment.User });

            //Messages.Insert(0,new Message() { Text = "Hi" });
            //Messages.Insert(0, new Message() { Text = "How are you?", User = App.User});
            //Messages.Insert(0, new Message() { Text = "What's new?" });
            //Messages.Insert(0, new Message() { Text = "How is your family", User = App.User });
            //Messages.Insert(0, new Message() { Text = "How is your dog?", User = App.User });
            //Messages.Insert(0, new Message() { Text = "How is your cat?", User = App.User });
            //Messages.Insert(0, new Message() { Text = "How is your sister?" });
            //Messages.Insert(0, new Message() { Text = "When we are going to meet?" });
            //Messages.Insert(0, new Message() { Text = "I want to buy a laptop" });
            //Messages.Insert(0, new Message() { Text = "Where I can find a good one?" });
            //Messages.Insert(0, new Message() { Text = "Also I'm testing this chat" });
            //Messages.Insert(0, new Message() { Text = "Oh My God!" });
            //Messages.Insert(0, new Message() { Text = " No Problem" , User = App.User});
            //Messages.Insert(0, new Message() { Text = "Hugs and Kisses", User = App.User });
            //Messages.Insert(0, new Message() { Text = "When we are going to meet?" });
            //Messages.Insert(0, new Message() { Text = "I want to buy a laptop" });
            //Messages.Insert(0, new Message() { Text = "Where I can find a good one?" });
            //Messages.Insert(0, new Message() { Text = "Also I'm testing this chat" });
            //Messages.Insert(0, new Message() { Text = "Oh My God!" });
            //Messages.Insert(0, new Message() { Text = " No Problem" });
            //Messages.Insert(0, new Message() { Text = "Hugs and Kisses" });

            MessageAppearingCommand = new Command<Message>(OnMessageAppearing);
            MessageDisappearingCommand = new Command<Message>(OnMessageDisappearing);

            OnSendCommand = new Command(() =>
            {
            if (!string.IsNullOrEmpty(TextToSend)) {
                 //запись в базу
                 Comment commentrec = new Comment();
                 commentrec.Event_id = Event_id;
                 commentrec.Comment_text = TextToSend;
                 commentrec.Reg_date = DateTime.Now.ToLocalTime();
                 //симуляция получения ответа   
                 if (commentrec.Comment_text.Substring(0,1) == "!") 
                 { 
                     commentrec.User = "User1"; 
                     commentrec.Comment_text = TextToSend.Substring(1);
                 }
                 else 
                 { 
                     commentrec.User = App.User;
                 }
                 App.Database.SaveCommentItem(commentrec);

                 Messages.Insert(0, new Message() { Text = commentrec.Comment_text, User = commentrec.User, Reg_date = commentrec.Reg_date.Value.ToString("dd.MM.yyyy HH:mm") });
                 TextToSend = string.Empty;
                }

                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("TextToSend"));
                }

            });

            //Code to simulate reveing a new message procces
            //Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            //{
            //    if (LastMessageVisible)
            //    {
            //        Messages.Insert(0, new Message(){ Text = "New message test" , User="Mario"});
            //    }
            //    else
            //    {
            //        DelayedMessages.Enqueue(new Message() { Text = "New message test" , User = "Mario"});
            //        PendingMessageCount++;
            //    }
            //    return true;
            //});

           
           
        }

        void OnMessageAppearing(Message message)
        {
            var idx = Messages.IndexOf(message);
            if (idx <= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    while (DelayedMessages.Count > 0)
                    {
                        Messages.Insert(0, DelayedMessages.Dequeue());
                    }
                    ShowScrollTap = false;
                    LastMessageVisible = true;
                    PendingMessageCount = 0;
                });
            }
        }

        void OnMessageDisappearing(Message message)
        {
            var idx = Messages.IndexOf(message);
            if (idx >= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ShowScrollTap = true;
                    LastMessageVisible = false;
                });

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
