using MauiWebApi.Pages;
using MauiWebApi.Services;

namespace MauiWebApi;

public partial class LoginPage : ContentPage
{
	private readonly ILoginRepository _loginRepository = new LoginService();

	public LoginPage()
	{
		InitializeComponent();
	}

	private async void Login_Clicked(object sender, EventArgs e)
	{
		string userName = txtUsername.Text;
		string password = txtPassword.Text;

		if(userName == null || password == null)
		{
			await DisplayAlert("Warning", "Please Input Username & Password", "Ok");
			return;
		}

		var userInfo = await _loginRepository.Login(userName, password);

		if(userInfo != null)
		{
			await Navigation.PushAsync(new HomePage());
		}
		else
		{
            await DisplayAlert("Warning", "Username or Password is incorrect", "Ok");
        }
	}
}