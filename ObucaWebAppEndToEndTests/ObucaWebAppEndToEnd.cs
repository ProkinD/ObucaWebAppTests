using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObucaWebAppEndToEndTests
{
    [TestFixture]
    public class ObucaWebAppEndToEnd
    {
        private IWebDriver driver;

        [SetUp]
        public void Set()
        {
            driver = new ChromeDriver(@"B:\VS projects\chromedriver_win32");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        [Test, Order(1)]
        public void OpenObucaIndexPage()
        {
            driver.Navigate().GoToUrl("http://localhost:65529");
            IWebElement addObuca = driver.FindElement(By.CssSelector("[href*='/Obuca']"));
            addObuca.Click();
            Assert.That("http://localhost:65529/Obuca", Is.EqualTo(driver.Url));
        }

        [Test, Order(2)]
        public void OpenCreateObucaPage()
        {
            driver.Navigate().GoToUrl("http://localhost:65529/Obuca");
            IWebElement addObuca = driver.FindElement(By.CssSelector("[href*='/Obuca/Create']"));
            addObuca.Click();
            Assert.That("http://localhost:65529/Obuca/Create", Is.EqualTo(driver.Url));
        }

        [Test, Order(3)]
        public void OpenProdavnicaIndexPage()
        {
            driver.Navigate().GoToUrl("http://localhost:65529");
            IWebElement addProdavnica = driver.FindElement(By.CssSelector("[href*='/Prodavnica']"));
            addProdavnica.Click();
            Assert.That("http://localhost:65529/Prodavnica", Is.EqualTo(driver.Url));
        }

        [Test, Order(4)]
        public void OpenCreateProdavnicaPage()
        {
            driver.Navigate().GoToUrl("http://localhost:65529/Prodavnica");
            IWebElement addProdavnica = driver.FindElement(By.CssSelector("[href*='/Prodavnica/Create']"));
            addProdavnica.Click();
            Assert.That("http://localhost:65529/Prodavnica/Create", Is.EqualTo(driver.Url));
        }

        [Test, Order(5)]
        public void AddObuca_OpensObucaIndex()
        {
            driver.Navigate().GoToUrl("http://localhost:65529/Obuca/Create");

            IWebElement inputUrlSlike = driver.FindElement(By.Id("UrlSlike"));
            IWebElement inputNaziv = driver.FindElement(By.Id("Naziv"));
            IWebElement inputVelicina = driver.FindElement(By.Id("Velicina"));
            IWebElement inputCena = driver.FindElement(By.Id("Cena"));
            IWebElement inputKolicina = driver.FindElement(By.Id("Kolicina"));


            inputUrlSlike.SendKeys("https://images.stockx.com/images/adidas-Iniki-Runner-Grey-One-Gum-W.jpg?fit=fill&bg=FFFFFF&w=700&h=500&auto=format,compress&q=90&dpr=2&trim=color&updated_at=1606937065");
            inputNaziv.SendKeys("Iniki");
            inputVelicina.SendKeys("41");
            inputCena.SendKeys("10000");
            inputKolicina.SendKeys("10");

            IWebElement btnSave = driver.FindElement(By.ClassName("btn-primary"));

            btnSave.Click();

            IWebElement tabela = driver.FindElement(By.TagName("table"));

            var tableElement = new TableElement();
            tableElement.ProcitajCelijeTabele(tabela);

            var naziv = tableElement.VrednostCelije("Naziv", 4);
            var brojRedova = tableElement.BrojCelijaTabele(tabela);

            Assert.That(naziv, Is.EqualTo("Iniki"));
            Assert.That(driver.Url, Is.EqualTo("http://localhost:65529/Obuca"));
            Assert.That(brojRedova, Is.EqualTo(5));
        }

        [Test, Order(6)]
        public void AddProdavnica_OpenProdavnicaIndex()
        {
            driver.Navigate().GoToUrl("http://localhost:65529/");
            IWebElement prodavnica = driver.FindElement(By.CssSelector("[href*='/Prodavnica']"));

            prodavnica.Click();

            IWebElement addProdavnica = driver.FindElement(By.CssSelector("[href*='/Prodavnica/Create']"));
            addProdavnica.Click();
            IWebElement adresa = driver.FindElement(By.Id("Adresa"));
            IWebElement grad = driver.FindElement(By.Id("Grad"));
            IWebElement kontakt = driver.FindElement(By.Id("Kontakt"));
            IWebElement urlSlike = driver.FindElement(By.Id("URLSlike"));

            adresa.SendKeys("Cara Dusana 100");
            grad.SendKeys("Zrenjanin");
            urlSlike.SendKeys("https://www.sportvision.rs/files/images/2019/10/21/Slika%204.jpg");
            kontakt.SendKeys("062434500");

            IWebElement btnSave = driver.FindElement(By.ClassName("btn-primary"));

            btnSave.Click();
            IWebElement tabela = driver.FindElement(By.TagName("table"));

            var tableElement = new TableElement();
            tableElement.ProcitajCelijeTabele(tabela);

            var brojRedova = tableElement.BrojCelijaTabele(tabela);

            var adresaP = tableElement.VrednostCelije("Adresa", 3);
            var gradP = tableElement.VrednostCelije("Grad", 3);
            var kontaktP = tableElement.VrednostCelije("Kontakt", 3);
            var slikaP = tableElement.VrednostCelije("URLSlike", 3);

            Assert.That(adresaP, Is.EqualTo("Cara Dusana 100"));
            Assert.That(gradP, Is.EqualTo("Zrenjanin"));
            Assert.That(brojRedova, Is.EqualTo(4));
        }

        [Test, Order(7)]
        public void EditObuca_OpenObucaIndex()
        {
            driver.Navigate().GoToUrl("http://localhost:65529/");
            IWebElement obuca = driver.FindElement(By.CssSelector("[href*='/Obuca']"));
            obuca.Click();
            IWebElement editObuca = driver.FindElement(By.CssSelector("[href*='/Obuca/Edit/16']"));
            editObuca.Click();
            IWebElement naziv = driver.FindElement(By.Id("Naziv"));
            naziv.Clear();
            naziv.SendKeys("NOVI NAZIV");
            IWebElement btnSave = driver.FindElement(By.ClassName("btn-primary"));
            btnSave.Click();
            IWebElement tabela = driver.FindElement(By.TagName("table"));
            var tableElement = new TableElement();
            tableElement.ProcitajCelijeTabele(tabela);
            var nazivO = tableElement.VrednostCelije("Naziv", 4);


            Assert.That(nazivO, Is.EqualTo("NOVI NAZIV"));
            Assert.That(driver.Url, Is.EqualTo("http://localhost:65529/Obuca"));
        }

        [Test, Order(8)]
        public void EditProdavnica_OpenProdavnicaIndex()
        {
            driver.Navigate().GoToUrl("http://localhost:65529/");
            IWebElement obuca = driver.FindElement(By.CssSelector("[href*='/Prodavnica']"));
            obuca.Click();
            IWebElement editObuca = driver.FindElement(By.CssSelector("[href*='/Prodavnica/Edit/14']"));
            editObuca.Click();
            IWebElement adresa = driver.FindElement(By.Id("Adresa"));
            adresa.Clear();
            adresa.SendKeys("NOVA ADRESA");
            IWebElement btnSave = driver.FindElement(By.ClassName("btn-primary"));
            btnSave.Click();
            IWebElement tabela = driver.FindElement(By.TagName("table"));
            var tableElement = new TableElement();
            tableElement.ProcitajCelijeTabele(tabela);
            var adresaP = tableElement.VrednostCelije("Adresa", 3);


            Assert.That(adresaP, Is.EqualTo("NOVA ADRESA"));
            Assert.That(driver.Url, Is.EqualTo("http://localhost:65529/Prodavnica"));
        }

        [Test, Order(9)]
        public void DeleteObuca()
        {
            driver.Navigate().GoToUrl("http://localhost:65529/");
            IWebElement obuca = driver.FindElement(By.CssSelector("[href*='/Obuca']"));
            obuca.Click();
            IWebElement editObuca = driver.FindElement(By.CssSelector("[href*='/Obuca/Delete/16']"));
            editObuca.Click();
            IWebElement btnDelete = driver.FindElement(By.ClassName("btn-danger"));
            btnDelete.Click();
            IWebElement tabela = driver.FindElement(By.TagName("table"));
            var tableElement = new TableElement();
            int brojRedova = tableElement.BrojCelijaTabele(tabela);
            Assert.That(brojRedova, Is.EqualTo(4));
        }

        [Test, Order(10)]
        public void DeleteProdavnica()
        {
            driver.Navigate().GoToUrl("http://localhost:65529/");
            IWebElement obuca = driver.FindElement(By.CssSelector("[href*='/Prodavnica']"));
            obuca.Click();
            IWebElement editObuca = driver.FindElement(By.CssSelector("[href*='/Prodavnica/Delete/14']"));
            editObuca.Click();
            IWebElement btnDelete = driver.FindElement(By.ClassName("btn-danger"));
            btnDelete.Click();
            IWebElement tabela = driver.FindElement(By.TagName("table"));
            var tableElement = new TableElement();
            int brojRedova = tableElement.BrojCelijaTabele(tabela);

            Assert.That(brojRedova, Is.EqualTo(3));
        }
    }
}
