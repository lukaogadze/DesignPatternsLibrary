using System;
using System.Net;

namespace PrototypeDemo
{
    public class WebPageScraper : ICloneable
    {
        private string _title;
        private int _headerTagCount;
        private string _firstHeaderTagContents;

        public WebPageScraper(string url)
        {
            var client = new WebClient();
            Scrape(client.DownloadString(url));
        }

        private void Scrape(string page)
        {
            _title = "Fake title";
            _headerTagCount = 3;
            _firstHeaderTagContents = "Fake header text";
        }

        public void PrintPageData()
        {
            Console.WriteLine(
                $"Title: {_title}, Header Count: {_headerTagCount}, First Header: {_firstHeaderTagContents}");
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}