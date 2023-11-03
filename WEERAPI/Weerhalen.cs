using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

namespace WeerTest
{
    internal class Weerhalen

    {
        public string StadsWeer(string stad)
        {
            

            string baseurl = "https://drimble.nl/weer/";
            string finurl = $"{baseurl}{stad}";
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
                if (er > 19) { zonpan = true; return("zonnenpanelen zijn met dit weer voordelig, " + result2); }
                else { return("De huidige temperatuur :" + result2); }
                //
                //Console.WriteLine(niew);
            }
            else
            {
                // Regular expression pattern to match capital letters or digits
                // Replace using regular expression
                return("verkeerde stad als input");
            }
        }
    }
}



        // Setting up GeckoDriver
        //new DriverManager().SetUpDriver(new FirefoxConfig());
        //IWebDriver driver = new FirefoxDriver();
        // Navigate to the website
        //driver.Navigate().GoToUrl("http://example.com");
        // Example: Find an input element and interact with it
        //var inputElement = driver.FindElement(By.Name("inputName"));
        //inputElement.SendKeys("Some Text");
        // Add any additional actions, form submissions, or data scraping here
        // Scrape data or perform further actions...
        // Close the browser
        //driver.Quit();