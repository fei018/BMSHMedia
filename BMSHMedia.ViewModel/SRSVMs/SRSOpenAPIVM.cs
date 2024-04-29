using BMSHMedia.Model.Manage.SRS;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using WalkingTec.Mvvm.Core;

namespace BMSHMedia.ViewModel.SRSVMs
{
    public class SRSOpenAPIVM : BaseVM
    {
        #region post form
        public SRSStackInfo Entity { get; set; }

        [Display(Name = "直播發佈Url")]
        public string PublishUrl_View {  get; set; }

        #endregion

        public void SaveApiSecret()
        {
            var entity = DC.Set<SRSStackInfo>().ToList().FirstOrDefault();
            if (entity != null)
            {
                entity.RTMPUrl = Entity.RTMPUrl;
                entity.ApiSecret = Entity.ApiSecret.Trim();
                entity.ApiUrl_PublishKey = Entity.ApiUrl_PublishKey.Trim();
                entity.PlayUrl = Entity.PlayUrl.Trim();

                DC.UpdateEntity(entity);
            }
            else
            {
                DC.Set<SRSStackInfo>().Add(Entity);
            }

            DC.SaveChanges();
        }

        public void GetPublishUrl()
        {
            var entity = DC.Set<SRSStackInfo>().ToList().SingleOrDefault();

            string posturl = entity.ApiUrl_PublishKey;

            var http = new HttpClient();
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", entity.ApiSecret);
            var response =  http.PostAsync(posturl, null).Result;

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception("SRS call OpenAPI return : " + ex.Message);
            }

            var json = response.Content.ReadFromJsonAsync<JsonNode>().Result;
            string secret = "?secret=" + (string)json["data"]["publish"];

            PublishUrl_View = entity.RTMPUrl + secret;
        }

        public string GetPlayUrl()
        {
            var entity = DC.Set<SRSStackInfo>().ToList().SingleOrDefault();
            return entity.PlayUrl;
        }

        public string GetHLSUrl()
        {
            var entity = DC.Set<SRSStackInfo>().ToList().SingleOrDefault();
            string url = entity.PlayUrl.Replace("flv", "m3u8", StringComparison.OrdinalIgnoreCase);
            return url;
        }
    }
}
