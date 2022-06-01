using NUnit.Framework;
using ObućaWebApp.Models;
using ObućaWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObućaUnitTests
{
    [TestFixture]
    class ProdavnicaServiceUnitTests
    {
        ProdavnicaService pService;


        [SetUp]
        public void Set()
        {
            pService = new ProdavnicaService(new ProdavnicaFakeRepository());
        }

        [Test]
        public void ProdavnicaService_GetAllProdavnicas()
        {
            var result = pService.Get();

            var count = 3;

            Assert.That(result.Count, Is.EqualTo(count));

        }

        [Test]
        public void ProdavnicaService_CreateProdavnica()
        {


            bool result = pService.Add(new Prodavnica { Adresa = "Miloseva 22", Grad = "Beograd", Kontakt = "prod@bg.com", URLSlike = "///.....///" });

            bool state = true;


            Assert.That(result, Is.EqualTo(state));

        }

        [Test]
        public void ProdavnicaService_GetId()
        {
            var result = pService.GetId(4);

            var adresa = "Karađorđeva bb";


            Assert.That(result.Adresa, Is.EqualTo(adresa));

        }

        [Test]
        public void ProdavnicaService_EditProdavnica()
        {
            bool result = pService.Edit(new Prodavnica { Adresa = "Miloseva 22", Grad = "Nis", Kontakt = "prod@nis.com", URLSlike = "///..Nis...///" });
            bool state = true;

            Assert.That(result, Is.EqualTo(state));

        }


        [Test]
        public void ProdavnicaService_RemoveProdavnica()
        {
            bool result = pService.Remove(new Prodavnica { ProdavnicaId = 6, Adresa = "Uroseva bb", Grad = "Beograd", Kontakt = "prod@uroseva.com", URLSlike = "//////" });

            bool state = true;

            Assert.That(result, Is.EqualTo(state));

        }
    }
}
