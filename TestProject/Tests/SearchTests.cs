using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using WebDriverManager.DriverConfigs.Impl;
using TestProject.TestData;
using TestProject.Pages;
using SeleniumExtras.WaitHelpers;
using System;
using OpenQA.Selenium;

namespace TestProject.Tests
{
    internal class SearchTests
    {

        ChromeDriver driver;
        WebDriverWait wait;
        PageObjects pages;
        IJavaScriptExecutor js;


        [SetUp]
        public void Setup()
        {

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, System.TimeSpan.FromMinutes(1));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromMinutes(1);
            driver.Navigate().GoToUrl("https://vivino.com");
            js.ExecuteScript("return document.readyState");
            pages = new PageObjects(driver);
            js = (IJavaScriptExecutor)driver;
        }


        [TestCase("red wine")]
        public void Test1(string SearchText)
        {

            //Enters Text in Search box
            pages.Searchpage.EnterTextInSearchBox(SearchText);            
            js.ExecuteScript("return document.readyState");

            //Gets the list of attributes displayed in the web page e.g. country, wine name, Ratings etc
            List<Wine>  WineList = pages.Searchpage.ParseSearchResults();

            //Asserts the entered text is displayed in any of the wine attributes            
            pages.Searchpage.ValidateSearchFunctionality(WineList, SearchText);

            //Clicks on any random wine
            pages.Searchpage.ClickOnAnyRandomWineCard(WineList);
            

            //Validate the details displayed are matching with the previous page            
            wait.Until(ExpectedConditions.ElementIsVisible(pages.Productpage.Country));
            pages.Productpage.ValidateWineInformation(WineList);

        }


        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

    }



}
