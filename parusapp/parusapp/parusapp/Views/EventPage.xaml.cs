using System;
using Xamarin.Forms;
using parusapp.Models;

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
            var enent = (Event)BindingContext;
            if (!String.IsNullOrEmpty(enent.Event_descr)) {
                enent.Reg_date = DateTime.Now.ToLocalTime();
                enent.Change_date = DateTime.Now.ToLocalTime();
                //enent.Change_date = DateTime.Now.ToString("dd.mm.yyyy HH:MM:SS");
                App.Database.SaveItem(enent);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteEvent(object sender, EventArgs e)
        {
            var enent = (Event)BindingContext;
            App.Database.DeleteItem(enent.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}