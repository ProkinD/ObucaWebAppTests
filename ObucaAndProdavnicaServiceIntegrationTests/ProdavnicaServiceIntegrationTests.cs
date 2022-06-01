using NUnit.Framework;
using ObućaWebApp.Models;
using ObućaWebApp.Repositories;
using ObućaWebApp.Services;
using System;
using System.Collections.Generic;

namespace ObucaAndProdavnicaServiceIntegrationTests
{
    [TestFixture]
    class ProdavnicaServiceIntegrationTests
    {
        public ProdavnicaService pService;
        public ObucaWebAppDbModel contextModel;

        [SetUp]
        public void Set()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();

            contextModel = new ObucaWebAppDbModel(connection);

            List<Prodavnica> prodavnice = new List<Prodavnica>
        {
            new Prodavnica { Adresa = "Karađorđeva bb", Grad = "Beograd", Kontakt = "prod@karadjorjeva.com", URLSlike = "//////" },
            new Prodavnica { Adresa = "Markova bb", Grad = "Kikinda", Kontakt = "prod@markova.com", URLSlike = "//////" },
            new Prodavnica { Adresa = "Uroseva bb", Grad = "Beograd", Kontakt = "prod@uroseva.com", URLSlike = "//////" }
    };
           contextModel.Prodavnce.AddRange(prodavnice);
             var result = contextModel.SaveChanges();

            pService = new ProdavnicaService(new ProdavnicaRepository(contextModel));
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
            var result = pService.GetId(1);

            var adresa = "Karađorđeva bb";
            var kontakt = "prod@karadjorjeva.com";

            Assert.That(result.Adresa, Is.EqualTo(adresa));
            Assert.That(result.Kontakt, Is.EqualTo(kontakt));
        }

        [Test]
        public void ProdavnicaService_EditProdavnica()
        {
            pService.Add(new Prodavnica { Adresa = "Miloseva 22", Grad = "Beograd", Kontakt = "prod@bg.com", URLSlike = "///.....///" });

            bool result = pService.Edit(new Prodavnica { ProdavnicaId = 4, Adresa = "Miloseva 22", Grad = "Nis", Kontakt = "prod@nis.com", URLSlike = "///..Nis...///" });

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ProdavnicaService_RemoveProdavnica()
        {
            bool result = pService.Remove(3);       

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ProdavnicaService_GetAllProdavnicas()
        {
            var result = pService.Get();

            var count = 3;

            Assert.That(result.Count, Is.EqualTo(count));
        }
    }
}
