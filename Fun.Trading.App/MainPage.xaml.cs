using Fun.Trading.App.Auth0;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fun.Trading.App
{
    public partial class MainPage : ContentPage
    {
        private readonly Auth0Client auth0Client;
        private readonly ITradingClient tradingClient;

        public MainPage(Auth0Client client, ITradingClient tradingClient)
        {
            InitializeComponent();
            auth0Client = client;
            this.tradingClient = tradingClient;
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var loginResult = await auth0Client.LoginAsync();

            if (!loginResult.IsError)
            {
                UsernameLbl.Text = loginResult.User.Identity.Name;
                UserPictureImg.Source = loginResult.User
                  .Claims.FirstOrDefault(c => c.Type == "picture")?.Value;

                LoginView.IsVisible = false;
                HomeView.IsVisible = true;
            }
            else
            {
                await DisplayAlert("Error", loginResult.ErrorDescription, "OK");
            }
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            var logoutResult = await auth0Client.LogoutAsync();

            if (!logoutResult.IsError)
            {
                HomeView.IsVisible = false;
                LoginView.IsVisible = true;
            }
            else
            {
                await DisplayAlert("Error", logoutResult.ErrorDescription, "OK");
            }
        }

        private async void OnCallClick(object sender, EventArgs e)
        {
            var account = await tradingClient.GetAccountByOwnerId(0);
            LabelOut.Text = JsonSerializer.Serialize(account);
        }
    }

}
