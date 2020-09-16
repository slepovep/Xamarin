using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;
using parusapp.Services;
using parusapp.Views;
using System.Reflection;

namespace parusapp
{
	public partial class App : Application
	{
        public static string User = "Rendy";
        public const string DATABASE_NAME = "Events.db";
        public static EventRepository database;
        //public static EventRepository Database {
        //    get {
        //        if (database == null) {
        //            database = new EventRepository(
        //                Path.Combine(
        //                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
        //        }
        //        return database;
        //    }
        //}
        public static EventRepository Database {
            get {
                if (database == null) {
                    // путь, по которому будет находиться база данных
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                    // если база данных не существует (еще не скопирована)
                    if (!File.Exists(dbPath)) {
                        // получаем текущую сборку
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                        // берем из нее ресурс базы данных и создаем из него поток
                        using (Stream stream = assembly.GetManifestResourceStream($"SQLiteApp.{DATABASE_NAME}")) {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate)) {
                                stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                                fs.Flush();
                            }
                        }
                    }
                    database = new EventRepository(dbPath);
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
