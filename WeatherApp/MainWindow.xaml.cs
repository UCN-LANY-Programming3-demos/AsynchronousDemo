using RestSharp;
using System.Windows;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBoxPostalCode_LostFocus(object sender, RoutedEventArgs e)
        {
            // Calling api synchronously
            RestClient client = new();

            RestRequest request = new("", Method.GET);

            TextBoxCity.Text = client.Get<string>(request).Data;
        }
    }
}
