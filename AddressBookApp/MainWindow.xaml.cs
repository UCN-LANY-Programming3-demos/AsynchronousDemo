using RestSharp;
using System.Threading.Tasks;
using System.Windows;

namespace AddressBookApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RestClient client = new("https://localhost:44387/");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBoxPostalCode_LostFocus(object sender, RoutedEventArgs e)
        {
            string postalCode = TextBoxPostalCode.Text;
            TextBoxCity.Text = string.Empty;

            if (!string.IsNullOrEmpty(postalCode))
            {
                RestRequest request = new($"/cities/{postalCode}", Method.GET);

                // Calling API synchronously
                //IRestResponse<string> response = client.Get<string>(request);
                //TextBoxCity.Text = response.Data;

                // Calling API using TPL
                GetCityUsingTPL(request);

                // Calling API asynchronously (remember to add async to the method signature)
                //TextBoxCity.Text = await client.GetAsync<string>(request);
            }
        }

        private void GetCityUsingTPL(RestRequest request)
        {
            // Running task in another thread
            Task task = Task.Run(() =>
            {
                IRestResponse<string> response = client.Get<string>(request);
                // TextBoxCity is owned by main thread so it is necessary to use a dispatcher
                Dispatcher.Invoke(() =>
                {
                    TextBoxCity.Text = response?.Data;
                });
            });

        }
    }
}
