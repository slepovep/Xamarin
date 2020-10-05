using Xamarin.Forms;

namespace parusapp.Views
{
	public partial class WebClientPage : ContentPage
	{
		public WebClientPage()
		{
			InitializeComponent ();
        }
        void webviewNavigating(object sender, WebNavigatingEventArgs e)
        {
            labelClientLoading.IsVisible = true;
        }

        void webviewNavigated(object sender, WebNavigatedEventArgs e)
        {
            labelClientLoading.IsVisible = false;
        }
    }
}

