using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using HtmlAgilityPack;

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
        string beter = " Graden, de huidige temperatuur van";
        if (txt.Contains(replace))
        {
            var weatherData = node.InnerText;
            string niew = weatherData.Replace(replace, beter);
            Console.WriteLine(niew);
        }
        else
        {
            Console.WriteLine("verkeerde stad als input");
        }
    }
}
