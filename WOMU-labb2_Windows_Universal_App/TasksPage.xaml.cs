using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WOMU_labb2_Windows_Universal_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TasksPage : Page
    {
        private HttpClient httpClient;
        public TasksPage()
        {
            //this.InitializeComponent();
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:4189/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Limit the max buffer size for the response so we don't get overwhelmed
            httpClient.MaxResponseContentBufferSize = 300000;
        }
        public async void getTasks()
        {
            var response = await httpClient.GetAsync("api/Tasks");
            if (response.IsSuccessStatusCode)
            {
                var task = await response.Content.ReadAsStringAsync();
                var tasks = JsonArray.Parse(task);
                var current = from t in tasks
                              select new
                              {
                                  TaskID = t.GetObject()["TaskID"].GetNumber(),
                                  BeginDateTime = t.GetObject()["BeginDateTime"].Stringify(),
                                  DeadlineDateTime = t.GetObject()["DeadlineDateTime"].Stringify(),
                                  Title = t.GetObject()["Title"].GetString(),
                                  Requirements = t.GetObject()["Requirements"].GetString()
                              };
                task_details.DataContext = current;
            }
        }
    }
}
