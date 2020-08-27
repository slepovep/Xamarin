// 16:48
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using parusapp.Models;
using parusapp.Utils;
using parusapp.Services;
using parusapp.Views;

namespace parusapp.MasterDetailPageNavigation
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private List<Professional> _professionals;
        private Professional _selectedProfessional;
        private bool _isRefreshing;

        public List<Professional> Professionals
        {
            get
            {
                return _professionals;
            }
            set
            {
                _professionals = value;
                OnPropertyChanged(nameof(Professionals));
            }
        }
        public Professional SelectedProfesstional
        {
            get
            {
                return _selectedProfessional;
            }
            set
            {
                _selectedProfessional = value;
                OnPropertyChanged(nameof(SelectedProfesstional));
            }
        }

        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand { get; set; }

        public MainPageViewModel()
        {
            Professionals = DummyProfessionalData.GetProfessionals();
            RefreshCommand = new Command(CmdRefresh);
        }

        private async void CmdRefresh()
        {
            IsRefreshing = true;
            await Task.Delay(3000);
            IsRefreshing = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        //-------------
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
            Event event = new Event();
            EventPage eventPage = new EventPage();
            eventPage.BindingContext = event;
            await Navigation.PushAsync(eventPage);
        }


        //-------------







    }
}
