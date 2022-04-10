using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using TestProject.TestData;

namespace TestProject.Pages
{
    internal class ProductPage
    {
        private ChromeDriver driver;

        internal ProductPage(ChromeDriver driver)
        {
            this.driver = driver;
        }

        #region Selectors

        public By Country = By.XPath("//a[@data-cy='breadcrumb-country']");

        public By Rating = By.XPath("//div[contains(text(),'ratings')]//parent::div//preceding-sibling::div[not(@role) and @class]");

        public By Name = By.XPath("//div[@class='row header breadCrumbs']//h1");

        #endregion


        #region PageRelatedMethods

        /// <summary>
        /// This method validates the product information displayed in the Product page with search page
        /// </summary>
        /// <param name="wines"></param>
        public void ValidateWineInformation(List<Wine> wines)
        {
            string WineCountry = driver.FindElement(Country).Text;
            string WineName = driver.FindElement(Name).Text;
            string WineRating = driver.FindElement(Rating).Text;

            if (WineName.Contains(Environment.NewLine))
            {
                WineName = WineName.Replace(Environment.NewLine, " ");
            }

            var WineInfoSearchPage = wines.First(x => x.Name.ToLower().Equals(WineName.ToLower()));
            Assert.IsTrue(WineInfoSearchPage.Country == WineCountry);
            Assert.IsTrue(WineInfoSearchPage.Name == WineName);
            Assert.IsTrue(WineInfoSearchPage.Rating == WineRating);
            
        }

        #endregion

    }

}
