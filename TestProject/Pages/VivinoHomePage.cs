using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Pages
{
    internal class VivinoHomePage
    {
        private ChromeDriver driver;
        internal VivinoHomePage(ChromeDriver driver)
        {
            this.driver = driver;
        }
    }
}
