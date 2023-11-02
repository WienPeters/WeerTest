using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using AngleSharp.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the location for weather data:");
        string location = Console.ReadLine();

        string baseurl = "https://drimble.nl/weer/";
        string finurl = $"{baseurl}{location}";
        var web = new HtmlWeb();
        var doc = web.Load(finurl);
        var node = doc.DocumentNode.SelectSingleNode("//div[@class='dni top']");
        string txt = node.WriteContentTo();
        //vervangt iets niet moois uitziend
        string replace = "&#176;C";
        //vervangd het met duidelijkheid
        string beter = " graden celcius.";
        if (txt.Contains(replace))
        {
            var weatherData = node.InnerText;
            string niew = weatherData.Replace(replace, beter);
            string input = niew;
            //ruimte invoegen tussen aanelkaargeplakte tekst
            string stringToInsert = " ";

            //patroon om hoofdlettertext wat aanelkaargeplakt is aan te pakken
            string pattern = "(?<=\\p{Lu}|)(?=\\p{Lu}|=d)";
            //patroon om nummers te scheiden van text
            string pattern2 = @"(^|\n)[^\d]*\d";
            string result = Regex.Replace(input, pattern, stringToInsert);
            //boven en onder het samenvoegen v.d. text
            string result2 = Regex.Replace(result, pattern2, m => m.Value.Insert(m.Value.Length - 1, stringToInsert), RegexOptions.Multiline);
            var s = result2[4]; var ss = result2[2]; var sss = result2[3];
            string ses = (((ss.ToString() + (sss.ToString()))));
            string ses2 = (((ses.Replace(',', ' '))));
            int er = Int32.Parse(ses2);
            bool zonpan = false;
            
            //Console.WriteLine(result2);
            if ( er>19) { zonpan = true; Console.WriteLine("zonnenpanelen zijn met dit weer voordelig, "+ result2); }

            else { Console.WriteLine("De huidige temperatuur :" + result2); }

            //
            //Console.WriteLine(niew);
        }
        else
        {
            
            

            // Regular expression pattern to match capital letters or digits
            

            // Replace using regular expression
            

            
            Console.WriteLine("verkeerde stad als input");
        }
    }
}
