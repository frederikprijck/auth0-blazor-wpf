using System.Windows;
using Auth0_Blazor_WPF.Data;
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

            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}
