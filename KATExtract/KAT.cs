using HtmlAgilityPack;
using System;
using System.Collections.Generic;
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

            Console.WriteLine(para.ToString());
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

                    //string json = JsonConvert.SerializeObject(resultList);
                    result = resultList.ToList();



                    //  /------------------------------------------ para teste *-----------------------------------
                    // Console.WriteLine(json);

                    //  foreach (var x in resultList)
                    //  {
                    //      Console.WriteLine(x.Seed + " " + x.TorrentUrl);
                    //  }

                    //            }
                    ////----------------------------------------------------------------------------------------------------------------
                    //            string teste = @"<select name=""category"">  "+
                    //@"        < option value = ""0"" > Any </ option >                                                                                                                     "+
                    //@"                                                                                                                                                                   "+
                    //@"                                                                                                                                                                   "+
                    //@"         < optgroup label = ""ANIME"" >                                                                                                                              "+
                    //@"  < option value = ""anime"" > All Anime Category</ option >                                                                                                         "+
                    //@"       < option value = ""amv"" > Anime Music Video</ option >                                                                                                       "+
                    //@"            < option value = ""english-translated"" > English-translated </ option >                                                                               "+
                    //@"             < option value = ""anime-movie"" > Movie </ option >                                                                                                    "+
                    //@"              < option value = ""other-anime"" > Other Anime </ option >                                                                                             "+
                    //@"                   </ optgroup >                                                                                                                                   "+
                    //@"                   < optgroup label = ""APPLICATIONS"" >                                                                                                             "+
                    //@"                    < option value = ""applications"" > All Applications Category</ option >                                                                         "+
                    //@"                         < option value = ""windows"" > Windows </ option >                                                                                          "+
                    //@"                          < option value = ""mac-software"" > Mac </ option >                                                                                        "+
                    //@"                           < option value = ""unix"" > UNIX </ option >                                                                                              "+
                    //@"     < option value = ""linux"" > Linux </ option >                                                                                                                  "+
                    //@"      < option value = ""ios"" > iOS </ option >                                                                                                                     "+
                    //@"       < option value = ""android"" > Android </ option >                                                                                                            "+
                    //@"        < option value = ""handheld-applications"" > Handheld </ option >                                                                                            "+
                    //@"         < option value = ""other-applications"" > Other Applications </ option >                                                                                    "+
                    //@"              </ optgroup >                                                                                                                                        "+
                    //@"              < optgroup label = ""BOOKS"" >                                                                                                                         "+
                    //@"               < option value = ""books"" > All Books Category</ option >                                                                                            "+
                    //@"                    < option value = ""ebooks"" > Ebooks </ option >                                                                                                 "+
                    //@"                     < option value = ""comics"" > Comics </ option >                                                                                                "+
                    //@"                      < option value = ""manga"" > Manga </ option >                                                                                                 "+
                    //@"                       < option value = ""magazines"" > Magazines </ option >                                                                                        "+
                    //@"                        < option value = ""textbooks"" > Textbooks </ option >                                                                                       "+
                    //@"                         < option value = ""fiction"" > Fiction </ option >                                                                                          "+
                    //@"             < option value = ""non-fiction"" > Non-fiction </ option >                                                                                            "+
                    //@"              < option value = ""audio-books"" > Audio books </ option >                                                                                             "+
                    //@"                   < option value = ""academic"" > Academic </ option >                                                                                              "+
                    //@"                    < option value = ""poetry"" > Poetry </ option >                                                                                                 "+
                    //@"                     < option value = ""newspapers"" > Newspapers </ option >                                                                                        "+
                    //@"                      < option value = ""programming"" > Programming </ option >                                                                                     "+
                    //@"                       < option value = ""medical"" > Medical </ option >                                                                                            "+
                    //@"                        < option value = ""cooking"" > Cooking </ option >                                                                                           "+
                    //@"                         < option value = ""sport-books"" > Sport </ option >                                                                                        "+
                    //@"                          < option value = ""other-books"" > Other Books </ option >                                                                                 "+
                    //@"                               </ optgroup >                                                                                                                       "+
                    //@"                               < optgroup label = ""GAMES"" >                                                                                                        "+
                    //@"                                < option value = ""games"" > All Games Category</ option >                                                                           "+
                    //@"                                     < option value = ""windows-games"" > Windows </ option >                                                                        "+
                    //@"                                      < option value = ""mac-games"" > Mac </ option >                                                                               "+
                    //@"                                       < option value = ""linux-games"" > Linux </ option >                                                                          "+
                    //@"                                        < option value = ""ps2"" > PS2 </ option >                                                                                   "+
                    //@"                                                                < option value = ""xbox360"" > XBOX360 </ option >                                                   "+
                    //@"                                                                 < option value = ""xbox-one"" > Xbox ONE </ option >                                                "+
                    //@"               < option value = ""wii"" > Wii </ option >                                                                                                            "+
                    //@"                < option value = ""handheld-games"" > Handheld </ option >                                                                                           "+
                    //@"                 < option value = ""nds"" > NDS </ option >                                                                                                          "+
                    //@"                  < option value = ""psp"" > PSP </ option >                                                                                                         "+
                    //@"                   < option value = ""ps3"" > PS3 </ option >                                                                                                        "+
                    //@"                    < option value = ""ps4"" > PS4 </ option >                                                                                                       "+
                    //@"                     < option value = ""ps-vita"" > PS Vita </ option >                                                                                              "+
                    //@"                          < option value = ""ios-games"" > iOS </ option >                                                                                           "+
                    //@"                           < option value = ""android-games"" > Android </ option >                                                                                  "+
                    //@"                            < option value = ""cheats"" > Cheats </ option >                                                                                         "+
                    //@"                             < option value = ""other-games"" > Other Games </ option >                                                                              "+
                    //@"                                  </ optgroup >                                                                                                                    "+
                    //@"                                  < optgroup label = ""MOVIES"" >                                                                                                    "+
                    //@"                                   < option value = ""movies"" > All Movies Category</ option >                                                                      "+
                    //@"                                        < option value = ""3d-movies"" > 3D Movies </ option >                                                                       "+
                    //@"                                                                                                    < option value = ""music-videos"" > Music videos </ option >     "+
                    //@"                                   < option value = ""movie-clips"" > Movie clips </ option >                                                                        "+
                    //@"                                        < option value = ""handheld-movies"" > Handheld </ option >                                                                  "+
                    //@"                                         < option value = ""ipad-movies"" > iPad </ option >                                                                         "+
                    //@"                                          < option value = ""highres-movies"" > Highres Movies </ option >                                                           "+
                    //@"                                               < option value = ""ultrahd"" > UltraHD </ option >                                                                    "+
                    //@"                                                < option value = ""bollywood"" > Bollywood </ option >                                                               "+
                    //@"                                                 < option value = ""concerts"" > Concerts </ option >                                                                "+
                    //@"                                                  < option value = ""dubbed-movies"" > Dubbed Movies </ option >                                                     "+
                    //@"                                                       < option value = ""asian"" > Asian </ option >                                                                "+
                    //@"                                                        < option value = ""animation"" > Animation </ option >                                                       "+
                    //@"                                                         < option value = ""documentary"" > Documentary </ option >                                                  "+
                    //@"                                                          < option value = ""academic-movies"" > Academic Movies </ option >                                         "+
                    //@"                                                               < option value = ""sport-videos"" > Sport </ option >                                                 "+
                    //@"                                                                < option value = ""trailer"" > Trailer </ option >                                                   "+
                    //@"                 < option value = ""other-movies"" > Other Movies </ option >                                                                                        "+
                    //@"                      </ optgroup >                                                                                                                                "+
                    //@"                      < optgroup label = ""MUSIC"" >                                                                                                                 "+
                    //@"                       < option value = ""music"" > All Music Category</ option >                                                                                    "+
                    //@"                            < option value = ""mp3"" > Mp3 </ option >                                                                                               "+
                    //@"                             < option value = ""aac"" > AAC </ option >                                                                                              "+
                    //@"                              < option value = ""lossless"" > Lossless </ option >                                                                                   "+
                    //@"                       < option value = ""transcode"" > Transcode </ option >                                                                                        "+
                    //@"                        < option value = ""soundtrack"" > Soundtrack </ option >                                                                                     "+
                    //@"                         < option value = ""radio-shows"" > Radio Shows </ option >                                                                                  "+
                    //@"                              < option value = ""karaoke"" > Karaoke </ option >                                                                                     "+
                    //@"           < option value = ""classic"" > Classic </ option >                                                                                                        "+
                    //@"            < option value = ""other-music"" > Other Music </ option >                                                                                               "+
                    //@"                 </ optgroup >                                                                                                                                     "+
                    //@"                 < optgroup label = ""OTHER"" >                                                                                                                      "+
                    //@"                  < option value = ""other"" > All Other Category</ option >                                                                                         "+
                    //@"                       < option value = ""pictures"" > Pictures </ option >                                                                                          "+
                    //@"                                            < option value = ""sound-clips"" > Sound clips </ option >                                                               "+
                    //@"                                                 < option value = ""covers"" > Covers </ option >                                                                    "+
                    //@"         < option value = ""wallpapers"" > Wallpapers </ option >                                                                                                    "+
                    //@"          < option value = ""tutorials"" > Tutorials </ option >                                                                                                     "+
                    //@"           < option value = ""subtitles"" > Subtitles </ option >                                                                                                    "+
                    //@"            < option value = ""fonts"" > Fonts </ option >                                                                                                           "+
                    //@"             < option value = ""unsorted"" > Unsorted </ option >                                                                                                    "+
                    //@"              </ optgroup >                                                                                                                                        "+
                    //@"              < optgroup label = ""TV"" >                                                                                                                            "+
                    //@"               < option value = ""tv"" > All TV Category</ option >                                                                                                  "+
                    //@"                    < option value = ""other-tv"" > Other TV </ option >                                                                                             "+
                    //@"                         </ optgroup >                                                                                                                             "+
                    //@"                         < optgroup label = ""XXX"" >                                                                                                                "+
                    //@"                          < option value = ""xxx"" > All XXX Category</ option >                                                                                     "+
                    //@"                               < option value = ""xxx-video"" > Video </ option >                                                                                    "+
                    //@"                                                                         < option value = ""xxx-hd-video"" > HD Video </ option >                                    "+
                    //@"     < option value = ""xxx-ultrahd"" > UltraHD </ option >                                                                                                          "+
                    //@"      < option value = ""xxx-pictures"" > Pictures </ option >                                                                                                       "+
                    //@"       < option value = ""xxx-magazines"" > Magazines </ option >                                                                                                    "+
                    //@"        < option value = ""xxx-books"" > Books </ option >                                                                                                           "+
                    //@"         < option value = ""hentai"" > Hentai </ option >                                                                                                            "+
                    //@"          < option value = ""xxx-games"" > XXX Games </ option >                                                                                                     "+
                    //@"               < option value = ""other-xxx"" > Other XXX </ option >                                                                                                "+
                    //@"      </ optgroup >  </ select > " 
                    //;



                    //            HtmlNode.ElementsFlags["option"] = HtmlElementFlag.Closed;
                    //            HtmlNode.ElementsFlags["optgroup"] = HtmlElementFlag.Closed;
                    //            HtmlDocument testedoc = new HtmlDocument();
                    //            testedoc.LoadHtml(teste);
                    //            var catego = testedoc.DocumentNode.Descendants().Where(a => a.Attributes["label"] != null);

                    //            foreach (HtmlNode city in catego)
                    //            {
                    //                if (city.NextSibling != null)
                    //                {
                    //                    string key = city.NextSibling.InnerHtml;
                    //                    string value = city.Attributes["label"].Value;
                    //                    Console.WriteLine("class " + value + " \n{\n\n}");

                    //                }
                    //            }


                    //            string games = @"<select name=""platform_id""> <option>Any</option> <option value=""4"">Android</option> <option value=""7"">BlackBerry</option> <option value=""15"">GameCube</option> <option value=""18"">iPad</option> <option value=""19"">iPhone</option> <option value=""20"">iPod</option> <option value=""22"">Java</option> <option value=""24"">Linux</option> <option value=""25"">MAC</option> <option value=""31"">Nintendo 3DS</option> <option value=""33"">Nintendo DS</option> <option value=""35"">NUON/DVD</option> <option value=""65"">Other</option> <option value=""37"">Palm OS</option> <option value=""38"">PC</option> <option value=""43"">PlayStation 2</option> <option value=""44"">PlayStation 3</option> <option value=""66"">PlayStation 4</option> <option value=""45"">PSP</option> <option value=""52"">Symbian</option> <option value=""56"">Wii</option> <option value=""68"">Wii U</option> <option value=""57"">Windows CE</option> <option value=""58"">Windows Mobile</option> <option value=""59"">Windows Phone</option> <option value=""61"">Xbox</option> <option value=""62"">Xbox 360</option> <option value=""67"">Xbox One</option></ select > ";
                    //            string lang = @"<select name=""lang_sel""> <option>Any</option> <option value=""2"">English</option> <option value=""42"">Albanian</option> <option value=""7"">Arabic</option> <option value=""44"">Basque</option> <option value=""46"">Bengali</option> <option value=""39"">Brazilian</option> <option value=""37"">Bulgarian</option> <option value=""45"">Cantonese</option> <option value=""47"">Catalan</option> <option value=""10"">Chinese</option> <option value=""34"">Croatian</option> <option value=""32"">Czech</option> <option value=""26"">Danish</option> <option value=""8"">Dutch</option> <option value=""11"">Filipino</option> <option value=""31"">Finnish</option> <option value=""5"">French</option> <option value=""4"">German</option> <option value=""30"">Greek</option> <option value=""25"">Hebrew</option> <option value=""6"">Hindi</option> <option value=""27"">Hungarian</option> <option value=""3"">Italian</option> <option value=""15"">Japanese</option> <option value=""49"">Kannada</option> <option value=""16"">Korean</option> <option value=""43"">Lithuanian</option> <option value=""21"">Malayalam</option> <option value=""23"">Mandarin</option> <option value=""48"">Nepali</option> <option value=""19"">Norwegian</option> <option value=""33"">Persian</option> <option value=""9"">Polish</option> <option value=""17"">Portuguese</option> <option value=""35"">Punjabi</option> <option value=""18"">Romanian</option> <option value=""12"">Russian</option> <option value=""28"">Serbian</option> <option value=""36"">Slovenian</option> <option value=""41"">Spanish (Latin America)</option> <option value=""14"">Spanish (Spain)</option> <option value=""20"">Swedish</option> <option value=""13"">Tamil</option> <option value=""22"">Telugu</option> <option value=""24"">Thai</option> <option value=""29"">Turkish</option> <option value=""40"">Ukrainian</option> <option value=""50"">Urdu</option> <option value=""38"">Vietnamese</option></ select >";
                    //            string aad = @"<select name=""age""> <option>Any time</option> <option value=""hour"">Last hour</option> <option value=""24h"">Last 24 hours</option> <option value=""week"">Last week</option> <option value=""month"">Last month</option> <option value=""year"">Last year</option> </select>";
                    //            HtmlDocument langdoc = new HtmlDocument();
                    //            langdoc.LoadHtml(aad);
                    //            catego = langdoc.DocumentNode.Descendants().Where(a => a.Attributes["value"] != null);

                    //            foreach (HtmlNode city in catego)
                    //            {
                    //                if (city.NextSibling != null)
                    //                {
                    //                    string key = city.InnerText;
                    //                    string value = city.Attributes["value"].Value;
                    //                    Console.WriteLine("public static readonly string {0} = \"{1}\";",key,value);

                    //                }
                    //            }



                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.StackTrace);
            }

            return result;
        }

    }
}
