using Xamarin.Forms;

namespace parusapp.MasterDetailPageNavigation
{
	public class EventsListPageCS : ContentPage
	{
		public EventsListPageCS()
		{
            Title = "Журнал событий";
			Content = new StackLayout { 
				Children = {
					new Label {
						Text = "Журнал регистрации событий",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}
	}
}
    