using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.TestData;

namespace TestProject.Pages
{
    internal class SearchPage
    {
        private ChromeDriver driver;

        internal SearchPage(ChromeDriver driver)
        {
            this.driver = driver;
        }

        #region Selectors

        public By SearchText = By.XPath("//input[@aria-label='Search any wine']");

        public By WineName = By.XPath("//div[@class='wine-card__content']//span[contains(@class,'wine-card__name')]");        

        public By WineCountry = By.XPath("//div[@class='wine-card__content']//a[@data-item-type='country']");
        
        public By WineRating = By.XPath("//span[contains(text(),'Average rating')]//following-sibling::div[contains(@class,'average__number')]");

        #endregion

        #region PageRelatedMethods

        public void EnterTextInSearchBox(string text)
        {
            driver.FindElement(SearchText).SendKeys(text);
            driver.FindElement(SearchText).SendKeys(Keys.Enter);
        }

        public List<Wine> ParseSearchResults()
        {
            List<Wine> results = new();
            var Name = driver.FindElements(WineName);
            var Country = driver.FindElements(WineCountry);
            var Rating = driver.FindElements(WineRating);

            for (int i = 0; i < Name.Count; i++)
            {
                results.Add(new Wine() { Name = Name[i].Text });                                
            }

            for (int i = 0; i < results.Count; i++)
            {
                results[i].Rating = Rating[i].Text;
            }

            int NoCountry = 0;
            for (int i = 0; i < results.Count; i++)
            {
                if (driver.FindElements(By.XPath("(//div[@class='wine-card__content']//*[contains(@class,'wine-card__region')])[" + (i+1) + "]//*")).Count == 3)
                    results[i].Country = Country[i-NoCountry].Text;
                else
                {
                    results[i].Country = "-";
                    NoCountry++;
                }
                 
            }
            
            return results;
        }

        public void ValidateSearchFunctionality(List<Wine> WineData, string SearchText)
        {
            
            SearchText = SearchText.Trim().ToLower();
            
            //split used simplify the search verification - e.g. red wine can also be as "red (wine)"
            foreach (var search in SearchText.Split(' '))
            {
                foreach (var WineAttribute in WineData)
                {
                    bool CorrectResults = false;
                    if (WineAttribute.Name.ToLower().Trim().Contains(search))
                    {
                        CorrectResults |= true;
                        TestContext.WriteLine("Wine Name : " + WineAttribute.Name + " contains search text - " + search);
                    }
                    if (WineAttribute.Country.ToLower().Contains(search))
                    {
                        CorrectResults |= true;
                        TestContext.WriteLine("Wine Country : " + WineAttribute.Country + " contains search text - " + search);
                    }
                    if (WineAttribute.Rating.ToLower().Contains(search))
                    {
                        CorrectResults |= true;
                        TestContext.WriteLine("Wine Ratings : " + WineAttribute.Rating + " contains search text - " + search);
                    }
                    if (CorrectResults == false)
                    {
                        TestContext.WriteLine("Wine Ratings : " + WineAttribute.Rating + " does not contains search text - " + search);
                        TestContext.WriteLine("Wine Country : " + WineAttribute.Country + " does not contains search text - " + search);
                        TestContext.WriteLine("Wine Name : " + WineAttribute.Name + " does not contains search text - " + search);
                    }
                    Assert.IsTrue(CorrectResults);
                }

            }


        }

        public void ClickOnAnyRandomWineCard(List<Wine> WineList)
        {            
            int CardNumber = new Random().Next(WineList.Count);
            System.Threading.Thread.Sleep(1000);            
            driver.FindElement(By.XPath("(//div[@class='wine-card__content']//span[contains(@class,'wine-card__name')])[" + CardNumber + "]//a")).Click();            
        }

        #endregion

    }
}
