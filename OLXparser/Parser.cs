using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OLXparser
{
    class Parser : IParser, IEnumerable
    {
        private string url;

        private List<HtmlNode> productList;
        public HttpClient Client { get => new HttpClient(); }
        public List<HtmlNode> ProductListItems { get => productList; set => productList = value; }

        public Parser(string Url)
        {
            url = Url;
        }

        // Getting an html document of page
        public HtmlDocument LoadAndGetHtmlDocument()
        {
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            return htmlDocument;
        }

        // Pushing items from web page to collection
        public void SetProductList(string table_name)
        {
            var ProductListTop = LoadAndGetHtmlDocument().DocumentNode.Descendants("table")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals(table_name)).ToList();

            ProductListItems = ProductListTop[0].Descendants("tr")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("wrap")).ToList();

        }

        // Adding support of foreach looping
        public IEnumerator GetEnumerator()
        {
            return ProductListItems.GetEnumerator();
        }
    }
}
