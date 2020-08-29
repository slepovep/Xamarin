using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using parusapp.Models;

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
        private async void CreateEvent(object sender, EventArgs e)
        {
            Event eventrec = new Event();
            EventPage eventPage = new EventPage();
            eventPage.BindingContext = eventrec;
            await Navigation.PushAsync(eventPage);

            this.RefreshEventsList();
        }
        //обновление страницы событий
        public ICommand RefreshCommand { get; set; }
        private async void RefreshEventsList()
        {
            eventsList.IsRefreshing = true;
            await Task.Delay(3000);
            eventsList.IsRefreshing = false;
        }

    }
}

