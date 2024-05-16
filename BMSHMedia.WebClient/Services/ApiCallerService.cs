
namespace BMSHMedia.WebClient.Services
{
    public class ApiCallerService
    {
        public HttpClient HttpClient { get; private set; }

        public ApiCallerService(HttpClient http)
        {
            HttpClient = http;
        }


    }
}
