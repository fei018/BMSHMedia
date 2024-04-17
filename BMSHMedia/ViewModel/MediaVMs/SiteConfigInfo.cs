using WalkingTec.Mvvm.Core;
using System;

namespace BMSHMedia.ViewModel.MediaVMs
{
    public class SiteConfigInfo
    {
        public const string CustomStaticWebPath = "/fileget";

        public static string MediaRootPath { get; private set; } = "\\\\192.168.0.201\\BMSHFile\\Video\\整理中";

        public static string SiteHostName { get; set; } = "http://localhost:30002";


        public static void SetSiteConfig(WTMContext wtm)
        {
            //var site = wtm.DC.Set<SiteConfigInfo>().ToList().FirstOrDefault();

            //if (site == null)
            //{
            //    throw new ArgumentNullException(nameof(SiteConfigInfo));
            //}

            //if (string.IsNullOrEmpty(site.MediaRootPath))
            //{
            //    throw new ArgumentNullException(nameof(SiteConfigInfo.MediaRootPath));
            //}           

            //MediaRootPath = site.MediaRootPath;

            //SiteHostName = site.SiteHostName;
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

            throw new Exception("路徑 IsNullOrEmpty.");
        }
    }
}
