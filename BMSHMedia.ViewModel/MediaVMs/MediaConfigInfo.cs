namespace BMSHMedia.ViewModel.MediaVMs
{
    public class MediaConfigInfo
    {
        public static string CustomStaticWebPath { get; } = "/mediaroot";

        public static string MediaRootPath { get; private set; }

        public static void SetSiteConfig(string mediarootPath)
        {
            MediaRootPath = mediarootPath;
        }


    }
}
