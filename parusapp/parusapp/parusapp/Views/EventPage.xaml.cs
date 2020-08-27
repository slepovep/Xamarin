using System;
using Xamarin.Forms;
using parusapp.Services;

namespace parusapp.Views
{
    public partial class EventPage : ContentPage
    {
        public EventPage()
        {
            InitializeComponent();
        }

        private void SaveEvent(object sender, EventArgs e)
        {
            var friend = (Event)BindingContext;
            if (!String.IsNullOrEmpty(friend.Name)) {
                App.Database.SaveItem(friend);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteEvent(object sender, EventArgs e)
        {
            var friend = (Event)BindingContext;
            App.Database.DeleteItem(friend.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}