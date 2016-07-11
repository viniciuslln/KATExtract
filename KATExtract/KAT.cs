using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KATExtract
{
    public static class KAT
    {
        public static async Task<List<SearchResult>> getResult(Params para)
        {
            List<SearchResult> result = new List<SearchResult>();

            Debug.WriteLine(para.ToString());
            try
            {

                
                using (var hc = new HttpClient())
                using (var stream = await hc.GetStreamAsync(para.ToString()))
                using (var gzstream = new GZipStream(stream, CompressionMode.Decompress))
                using (var reader = new StreamReader(gzstream))
                {
                    var html = await reader.ReadToEndAsync();
                    // do what you want with text

                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(html);

                    var rows = doc.DocumentNode.Descendants().Where(a => a.HasAttributes && (a.Attributes["class"] != null) && (a.Attributes["class"].Value.Equals("odd") || a.Attributes["class"].Value.Equals("even")));
                    var resultList = from a in rows
                                     from nome in a.Descendants().Where(b => b.HasAttributes && b.Attributes["class"] != null && b.Attributes["class"].Value != null && b.Attributes["class"].Value.Equals("cellMainLink"))
                                     from page in a.Descendants().Where(b => b.HasAttributes && b.Attributes["class"] != null && b.Attributes["class"].Value != null && b.Attributes["class"].Value.Equals("cellMainLink"))
                                     from torrent in a.Descendants().Where(b => b.HasAttributes && b.Attributes["data-download"] != null)
                                     from magnetic in a.Descendants().Where(b => b.HasAttributes && b.Attributes["data-nop"] != null)
                                     from size in a.Descendants().Where(b => b.HasAttributes && b.Attributes["class"] != null && b.Attributes["class"].Value != null && b.Attributes["class"].Value.Equals("nobr center"))
                                     from files in a.Descendants().Where(b => b.HasAttributes && b.Attributes["class"] != null && b.Attributes["class"].Value != null && b.Attributes["class"].Value.Equals("center") && b.Attributes["title"] == null)
                                     from age in a.Descendants().Where(b => b.HasAttributes && b.Attributes["class"] != null && b.Attributes["class"].Value != null && b.Attributes["class"].Value.Equals("center") && b.Attributes["title"] != null)
                                     from seed in a.Descendants().Where(b => b.HasAttributes && b.Attributes["class"] != null && b.Attributes["class"].Value != null && b.Attributes["class"].Value.Equals("green center"))
                                     from leech in a.Descendants().Where(b => b.HasAttributes && b.Attributes["class"] != null && b.Attributes["class"].Value != null && b.Attributes["class"].Value.Equals("red lasttd center"))
                                     from user in a.Descendants().Where(b => b.HasAttributes && b.Attributes["class"] != null && b.Attributes["class"].Value != null && b.Attributes["class"].Value.Equals("plain") && b.Attributes["href"] != null && b.Attributes["href"].Value.Substring(0, 5).Equals("/user"))
                                     select new SearchResult
                                     {
                                         Nome = nome.InnerText,
                                         PageUrl = page.Attributes["href"].Value,
                                         TorrentUrl = torrent.Attributes["href"].Value,
                                         MagneticUrl = magnetic.Attributes["href"].Value,
                                         Size = size.InnerText,
                                         Files = files.InnerText,
                                         Age = age.Attributes["title"].Value ?? String.Empty,
                                         Seed = seed.InnerText,
                                         Leech = leech.InnerText,
                                         User = user.InnerText
                                     };

                    Debug.WriteLine(JsonConvert.SerializeObject(resultList));
                    result = resultList.ToList();

                }
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee.StackTrace);
                Console.WriteLine("KATExtract: Error retrieving result");
            }

            return result;
        }

    }
}
