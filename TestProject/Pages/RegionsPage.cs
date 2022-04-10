using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Pages
{
    internal class RegionsPage
    {
        private ChromeDriver driver;
        internal RegionsPage(ChromeDriver driver)
        {
            this.driver = driver;
        }
    }
}
