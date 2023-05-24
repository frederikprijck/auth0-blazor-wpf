using System.Windows;
using Auth0_Blazor_WPF.Data;
using IdentityModel.OidcClient;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Auth0_Blazor_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddSingleton<WeatherForecastService>();

            serviceCollection.AddSingleton(new OidcClient(new()
            {
                Authority = "{AUTH0_DOMAIN}",
                ClientId = "{AUTH0_CLIENT_ID}",
                Scope = "openid profile",
                RedirectUri = "myapp://callback",
                Browser = new WebView2Browser()
            }));

            serviceCollection.AddAuthorizationCore();
            serviceCollection.AddSingleton<Auth0Client>();
            serviceCollection.AddScoped<AuthenticationStateProvider, Auth0AuthenticationStateProvider>();

            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}
