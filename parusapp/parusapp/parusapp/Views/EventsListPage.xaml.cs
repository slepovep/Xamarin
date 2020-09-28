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
        private bool _isRefreshing;
        public EventsListPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            if (App.IsUserLoggedIn != true) {
                Navigation.InsertPageBefore(new LoginPage(), this);
                Navigation.PopAsync();
            }
            else {
                eventsList.ItemsSource = App.Database.GetItems();
                eventsList.PullToRefreshCommand = new Command(RefreshEventsList);  //обновление страницы жестом сверху-вниз по экрану
            }
            base.OnAppearing();

                //RefreshCommand = new Command(RefreshEventsList);
            
            //}
            //else this.RefreshEventsList();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           Event selectedEvent = (Event)e.SelectedItem;

            if (selectedEvent != null) {
                eventsList.SelectedItem = null; // Снимаем выделение
                ChatPage chatPage = new ChatPage(selectedEvent.Id);
                //chatPage.BindingContext = selectedEvent.Id;
                await Navigation.PushAsync(chatPage);
            }
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

        // обработка нажатия кнопки удаления
        private async void DeleteEvent(object sender, EventArgs e)
        {
            App.Database.MaxRecord();
            this.RefreshEventsList();
        }

        //обновление страницы событий
        public ICommand RefreshCommand { get; set; }
        public async void RefreshEventsList()
        {
            eventsList.IsRefreshing = true;
            await Task.Delay(1000);
            eventsList.ItemsSource = App.Database.GetItems();
            eventsList.IsRefreshing = false;
        }


        public bool IsRefreshing {
            get {
                return _isRefreshing;
            }
            set {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

    }
}

