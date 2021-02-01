using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLXparser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Введите название товара, который вас интересует: \n");
            string input = Console.ReadLine();

            Parser parser = new Parser($"https://www.olx.ua/list/q-{input}/");
            HtmlAgilityPack.HtmlDocument htmlDoc = parser.LoadAndGetHtmlDocument();

            parser.SetProductList("fixed offers breakword offers--top redesigned");

            Console.WriteLine("У меня есть всё, если у тебя есть достаточно руппи\n");

            try
            {
                foreach (var ProductListItem in parser.ProductListItems)
                {
                    Console.WriteLine(ProductListItem.Descendants("h3")
                        .Where(node => node.GetAttributeValue("class", "")
                        .Equals("lheight22 margintop5")).FirstOrDefault().InnerText);


                    Console.WriteLine(ProductListItem.Descendants("p")
                        .Where(node => node.GetAttributeValue("class", "")
                        .Equals("price")).FirstOrDefault().InnerText);
                }
            }
            catch (Exception e) { Console.WriteLine("Цена не указана"); }
            parser.SetProductList("fixed offers breakword redesigned");
            try
            {
                foreach (var ProductListItem in parser.ProductListItems)
                {
                    Console.WriteLine(ProductListItem.Descendants("h3")
                        .Where(node => node.GetAttributeValue("class", "")
                        .Equals("lheight22 margintop5")).FirstOrDefault().InnerText);

                    Console.WriteLine(ProductListItem.Descendants("p")
                        .Where(node => node.GetAttributeValue("class", "")
                        .Equals("price")).FirstOrDefault().InnerText);
                }
            }
            catch (Exception e) { Console.WriteLine("Цена не указана"); }
        }
    }
}
