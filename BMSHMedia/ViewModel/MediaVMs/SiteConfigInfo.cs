using WalkingTec.Mvvm.Core;
using System;

namespace BMSHMedia.ViewModel.MediaVMs
{
    public class SiteConfigInfo
    {
        public const string CustomStaticWebPath = "/fileget";

        public static string MediaRootPath { get; private set; }  //@"\\192.168.0.201\BMSHFile\Video";

        //public static string SiteHostName { get; set; } //= "http://localhost:30002";


        public static void SetSiteConfig(string mediarootPath)
        {
            MediaRootPath = mediarootPath;
        }

        public static bool IsMediaRootPath(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                string root = SiteConfigInfo.MediaRootPath.Trim().TrimEnd('\\').ToLower();
                string current = path.Trim()?.TrimEnd('\\')?.ToLower();

                if (root == current)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            throw new Exception(nameof(MediaRootPath) + " 路徑 IsNullOrEmpty.");
        }
    }
}
