
namespace BMSHMedia.Common.Services
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
