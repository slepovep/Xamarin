using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using parusapp.Models;

namespace parusapp.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.listView.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}