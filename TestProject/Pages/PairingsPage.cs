using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Pages
{
    internal class PairingsPage
    {
        private ChromeDriver driver;
        internal PairingsPage(ChromeDriver driver)
        {
            this.driver = driver;
        }
    }
}
