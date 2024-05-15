
namespace BMSHMedia.WebClient.Services
{
    public class ApiCallerService
    {
        private readonly HttpClient _http;

        public ApiCallerService(HttpClient http)
        {
            _http = http;
        }


    }
}
