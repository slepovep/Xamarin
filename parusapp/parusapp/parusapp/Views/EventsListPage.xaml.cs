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
        bool loaded = false;
        public EventsListPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            if (loaded == false) {
                eventsList.ItemsSource = App.Database.GetItems();
                base.OnAppearing();
                loaded = true;
            }
            else this.RefreshEventsList();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Event selectedEvent = (Event)e.SelectedItem;
            ChatPage eventPage = new ChatPage();
            eventPage.BindingContext = selectedEvent;
            await Navigation.PushAsync(eventPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreateEvent(object sender, EventArgs e)
        {
            Event eventrec = new Event();
            EventAdd eventAdd = new EventAdd();
            eventAdd.BindingContext = eventrec;
            await Navigation.PushAsync(eventAdd);

            this.RefreshEventsList();
        }
        //обновление страницы событий
        public ICommand RefreshCommand { get; set; }
        public async void RefreshEventsList()
        {
            //eventsList.IsRefreshing = true;
            await Task.Delay(1000);
            //eventsList.ItemsSource = App.Database.GetItems();
            
            //eventsList.IsRefreshing = false;
        }

    }
}

