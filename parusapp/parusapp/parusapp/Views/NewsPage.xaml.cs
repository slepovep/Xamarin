using Xamarin.Forms;

namespace parusapp.Views
{
	public partial class NewsPage : ContentPage
	{
		public NewsPage()
		{
			InitializeComponent ();
        }
        void webviewNavigating(object sender, WebNavigatingEventArgs e)
        {
            labelLoading.IsVisible = true;
        }

        void webviewNavigated(object sender, WebNavigatedEventArgs e)
        {
            labelLoading.IsVisible = false;
        }
    }
}

