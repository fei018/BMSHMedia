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

        [Display(Name = "直播Key")]
        public string LiveKey_View {  get; set; }

        [Display(Name = "RTMPUrl")]
        public string RTMPUrl_View { get; set; }

        //public string PlayUrl_View { get; set; }
        #endregion

        public void SaveApiSecret()
        {
            var entity = DC.Set<SRSStackInfo>().ToList().FirstOrDefault();
            if (entity != null)
            {
                entity.RTMPUrl = Entity.RTMPUrl;
                entity.ApiSecret = Entity.ApiSecret.Trim();
                entity.PublishKeyApiUrl = Entity.PublishKeyApiUrl.Trim();
                entity.PlayUrl = Entity.PlayUrl.Trim();

                DC.UpdateEntity(entity);
            }
            else
            {
                DC.Set<SRSStackInfo>().Add(Entity);
            }

            DC.SaveChanges();
        }

        public void GetLiveKey()
        {
            var entity = DC.Set<SRSStackInfo>().ToList().SingleOrDefault();
            
            RTMPUrl_View = entity.RTMPUrl;

            string posturl = entity.PublishKeyApiUrl;

            var http = new HttpClient();
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", entity.ApiSecret);
            var response =  http.PostAsync(posturl, null).Result;
            response.EnsureSuccessStatusCode();

            var json = response.Content.ReadFromJsonAsync<JsonNode>().Result;
            LiveKey_View = "?secret=" + (string)json["data"]["publish"];
        }

        public string GetPlayUrl()
        {
            var entity = DC.Set<SRSStackInfo>().ToList().SingleOrDefault();
            return entity.PlayUrl;
        }
    }
}
