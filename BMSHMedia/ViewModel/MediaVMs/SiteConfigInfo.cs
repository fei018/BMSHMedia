using WalkingTec.Mvvm.Core;
using System;

namespace BMSHMedia.ViewModel.MediaVMs
{
    public class SiteConfigInfo
    {
        public const string CustomStaticWebPath = "/fileget";

        public static string MediaRootPath { get; private set; }

        //public static string SiteHostName { get; set; } //= "http://localhost:30002";


        public static void SetSiteConfig(string mediarootPath)
        {
            MediaRootPath = mediarootPath;
            //MediaRootPath =  @"\\192.168.0.201\BMSHFile\Video";
            //MediaRootPath = "C:\\CodeProject\\web";
        }

        
    }
}
