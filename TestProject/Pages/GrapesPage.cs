using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Pages
{
    internal class GrapesPage
    {
        private ChromeDriver driver;
        internal GrapesPage(ChromeDriver driver)
        {
            this.driver = driver;
        }
    }
}
