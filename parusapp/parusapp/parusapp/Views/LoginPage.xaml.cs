using System;
using Xamarin.Forms;
using parusapp.Models;

namespace parusapp.Views
{
	public partial class LoginPage : ContentPage
	{
        public LoginPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            if (App.IsUserLoggedIn) {
                Navigation.InsertPageBefore(new ProfilePage(), this);
                Navigation.PopAsync();
            }
            base.OnAppearing();
;
        }

        async void OnSignUpButtonClicked (object sender, EventArgs e)
		{
			await Navigation.PushAsync (new ProfilePage());
		}

		async void OnLoginButtonClicked (object sender, EventArgs e)
		{
			var user = new User {
				Username = usernameEntry.Text,
				Password = passwordEntry.Text
			};

			var isValid = AreCredentialsCorrect (user);
			if (isValid) {
				App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new ProfilePage(), this);
                await Navigation.PopAsync();
            }
            else {
				messageLabel.Text = "Ошибка регистрации";
				passwordEntry.Text = string.Empty;
			}
		}

		bool AreCredentialsCorrect (User user)
		{
			return user.Username == Constants.Username && user.Password == Constants.Password;
		}
	}
}
