namespace Tasks
{
    using System.Net;

    public static class DownloadSoftUniRSS
    {
        public static void DownloadFile(string url, string filePath)
        {
            var client = new WebClient();
            client.DownloadFile(url, filePath);
        }
    }
}
