using HtmlAgilityPack;
using System.Collections.Generic;
using System.Net.Http;


namespace OLXparser
{
    interface IParser
    {
        HttpClient Client { get; }

        List<HtmlNode> ProductListItems { get; set; }
    }
}
