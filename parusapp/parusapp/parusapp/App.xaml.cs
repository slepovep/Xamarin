using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using parusapp.Services;
using parusapp.Views;
using parusapp.MasterDetailPageNavigation;

namespace parusapp
{
	public partial class App : Application
	{

		public App()
		{
			Xamarin.Forms.DataGrid.DataGridComponent.Init();
			 InitializeComponent();
			//DependencyService.Register<MockDataStore>();
			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
