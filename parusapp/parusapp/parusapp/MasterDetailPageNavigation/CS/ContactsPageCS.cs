using Xamarin.Forms;

namespace parusapp.MasterDetailPageNavigation
{
	public class ContactsPageCS : ContentPage
	{
		public ContactsPageCS ()
		{
			Title = "Южный Парус";
			Content = new StackLayout { 
				Children = {
					new Label {
						Text = "страница CS",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}
	}
}
