using Android.Media;
using Camera2Basic.ExtentionMethods;
using RestSharp;
using Plugin.LocalNotifications;

namespace Camera2Basic.Services
{
    public class ImageUploadService
    {
        private readonly string ServiceURL = @"https://epicentertop.azurewebsites.net";

        public void Upload(Image image)
        {
            string base64 = image.ToBase64String();

            RestClient client = new RestClient(ServiceURL);
            RestRequest request = new RestRequest("api", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddBody(base64);
            client.ExecuteAsync(request, response =>
            {
                if (!response.IsSuccessful)
                {
                    CrossLocalNotifications.Current.Show("Found something!", "bla bla bla");
                }
            });
        }
    }
}