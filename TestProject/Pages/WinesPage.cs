using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Pages
{
    internal class WinesPage
    {
        private ChromeDriver driver;
        internal WinesPage(ChromeDriver driver)
        {
            this.driver = driver;
        }
    }
}
