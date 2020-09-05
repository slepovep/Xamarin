using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;
using parusapp.Services;
using parusapp.Views;

namespace parusapp
{
	public partial class App : Application
	{
        public static string User = "Rendy";
        public const string DATABASE_NAME = "Events.db";
        public static EventRepository database;
        public static EventRepository Database {
            get {
                if (database == null) {
                    database = new EventRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
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
