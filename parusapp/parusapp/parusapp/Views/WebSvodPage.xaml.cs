using Xamarin.Forms;

namespace parusapp.Views
{
	public partial class WebSvodPage : ContentPage
	{
		public WebSvodPage()
		{
			InitializeComponent ();
        }
        void webviewNavigating(object sender, WebNavigatingEventArgs e)
        {
            labelSvodLoading.IsVisible = true;
        }

        void webviewNavigated(object sender, WebNavigatedEventArgs e)
        {
            labelSvodLoading.IsVisible = false;
        }
    }
}

