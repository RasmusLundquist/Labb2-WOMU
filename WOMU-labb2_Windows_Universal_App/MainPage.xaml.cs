using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WOMU_labb2_Windows_Universal_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string WebUrl = "http://localhost:4189/api/NewUsers/";

        private HttpClient httpClient;
        private User activeUser;
        private List<User> AllUsers;

        public MainPage()
        {
            this.InitializeComponent();
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.MaxResponseContentBufferSize = 300000;

            
            GetUsers();

            this.InitializeComponent();

        }

        private async void GetUsers()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(App.BaseUri + "NewUsers");

            AllUsers = JsonConvert.DeserializeObject<List<User>>(json);
        

        }

    private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBlock2_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            //user.FirstName = firstName.Text;
            //user.LastName = lastName.Text;
            //activeUser = user;
        }
    }
}
