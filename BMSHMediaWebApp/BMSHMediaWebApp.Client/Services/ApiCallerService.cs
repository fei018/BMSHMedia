using BMSHMedia.Common.Activity;
using System.Net.Http.Json;

namespace BMSHMediaWebApp.Client.Services
{
    public class ApiCallerService
    {
        public HttpClient HttpClient { get; private set; }

        private string _baseUrl;

        public ApiCallerService(HttpClient http)
        {
            HttpClient = http;
            _baseUrl = http.BaseAddress.OriginalString;
        }

        public async Task<ActivityPostApiResult> GetActivityPostApiResult(int pageIndex)
        {
            var response = await HttpClient.GetAsync("/api/activitypost/postlist/" + pageIndex);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ActivityPostApiResult>(JsonSerializerOptionHelper.GetOption());
            return result;
        }

        #region MyRegion
        public string GetFileUrl(string fileId, int? width = null, int? height = null)
        {
            return $"{_baseUrl}/_Framework/GetFile?id={fileId}&stream=true&width={width}&height={height}";
        }
        #endregion
    }
}
