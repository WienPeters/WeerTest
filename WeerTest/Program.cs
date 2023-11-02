using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

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
        string replace = "&#176;C";
        string beter = " Graden, is momenteel";
        if (txt.Contains(replace))
        {
            var weatherData = node.InnerText;
            string niew = weatherData.Replace(replace, beter);
            string input = niew;
            string stringToInsert = " ";

            string pattern = "(?<=\\p{Lu}|)(?=\\p{Lu}|=d)";
            string pattern2 = @"(^|\n)[^\d]*\d";
            string result = Regex.Replace(input, pattern, stringToInsert);
            string result2 = Regex.Replace(result, pattern2, m => m.Value.Insert(m.Value.Length - 1, stringToInsert), RegexOptions.Multiline);
            //Console.WriteLine("Original String: " + input);
            Console.WriteLine("Modified String: " + result2);
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
