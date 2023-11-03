using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using AngleSharp.Text;
using WeerTest;

class Program
{
    static void Main()
    {
        Weerhalen wh = new Weerhalen();
        
        Console.WriteLine(wh.StadsWeer("Heerlen"));
    }
}

