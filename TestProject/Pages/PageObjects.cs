using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Pages
{

    /// <summary>
    /// This class holds objects of complete pages
    /// </summary>
    internal class PageObjects
    {
        internal PageObjects(ChromeDriver driver)
        {
            this.driver = driver;
        }

        #region objects

        private ChromeDriver driver;
        private AwardsPage? awardsPage;
        private GrapesPage? grapesPage;
        private PairingsPage? pairingsPage;
        private RegionsPage? regionsPage;
        private VivinoHomePage? homePage;
        private WinesPage? winesPage;
        private SearchPage? searchPage;
        private ProductPage? productPage;

        #endregion


        #region

        public AwardsPage Awardspage
        {
            get
            {
                if (awardsPage != null)
                {
                    return awardsPage;
                }
                return new AwardsPage(driver);
            }
        }

        public GrapesPage Grapespage
        {
            get
            {
                if (grapesPage != null)
                {
                    return grapesPage;
                }
                return new GrapesPage(driver);
            }                       
        }

        public PairingsPage Pairingspage
        {
            get
            {
                if (pairingsPage != null)
                {
                    return pairingsPage;
                }
                return new PairingsPage(driver);
            }
        }

        public RegionsPage Regionspage
        {
            get
            {
                if (regionsPage != null)
                {
                    return regionsPage;
                }
                return new RegionsPage(driver);
            }                     
        }

        public VivinoHomePage Vivinohomepage
        {
            get
            {
                if (homePage != null)
                {
                    return homePage;
                }
                return new VivinoHomePage(driver);
            }                      
        }

        public WinesPage Winespage
        {
            get
            {
                if (winesPage != null)
                {
                    return winesPage;
                }
                return new WinesPage(driver);
            }            
        }

        public SearchPage Searchpage
        {
            get
            {
                if (searchPage != null)
                {
                    return searchPage;
                }
                return new SearchPage(driver);
            }                     
        }

        public ProductPage Productpage
        {
            get
            {
                if(productPage != null)
                {
                    return productPage;
                }
                return new ProductPage(driver);
            }
        }

        #endregion



    }
}
