using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using parusapp.MasterDetailPageNavigation;
using parusapp.Services;

namespace parusapp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer  
    // by visiting https://aka.ms/xamarinforms-previewer  
    [DesignTimeVisible(false)]
    public partial class EventsListPage : ContentPage
    {
        public EventsListPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
        protected override void OnAppearing()
        {
            eventsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Event selectedEvent = (Event)e.SelectedItem;
            EventPage eventPage = new EventPage();
            eventPage.BindingContext = selectedEvent;
            await Navigation.PushAsync(eventPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreateFriend(object sender, EventArgs e)
        {
            Event friend = new Event();
            EventPage friendPage = new EventPage();
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }

    }
}

