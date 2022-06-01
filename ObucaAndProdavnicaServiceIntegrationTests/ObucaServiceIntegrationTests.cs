using NUnit.Framework;
using ObućaWebApp.Models;
using ObućaWebApp.Repositories;
using ObućaWebApp.Services;
using System;
using System.Collections.Generic;

namespace ObucaAndProdavnicaServiceIntegrationTests
{
        [TestFixture]
        public class ObucaServiceIntegrationTests
        {

            public ObucaService oService;
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

            List<Obuca> obuce = new List<Obuca>
            {
            new Obuca { Naziv = "Puma", UrlSlike = "///", Velicina = 43, Cena = 9000.99, Kolicina = 4, ProdavnicaId = 1 },
            new Obuca { Naziv = "Nike", UrlSlike = "///", Velicina = 44, Cena = 19000.99, Kolicina = 2, ProdavnicaId = 2 },
            new Obuca { Naziv = "Reebok", UrlSlike = "///", Velicina = 45, Cena = 7000, Kolicina = 6, ProdavnicaId = 1 }
        };

            contextModel.Obuce.AddRange(obuce);
            contextModel.SaveChanges();

            oService = new ObucaService(new ObucaRepository(contextModel));
            }

            [TearDown]
            public void TearDown()
            {
                contextModel.Dispose();
            }

            [Test]
            public void ObucaService_CreateObuca()
            {
                bool result = oService.Add(new Obuca { Naziv = "AirForce", UrlSlike = "/../../", Velicina = 43, Cena = 9000.99, Kolicina = 4, ProdavnicaId =  2});
                bool state = true;

                Assert.That(result, Is.EqualTo(state));
            }

            [Test]
            public void ObucaService_GetId()
            {
                var result = oService.GetId(3);

                var naziv = "Reebok";
                var urlSlike = "///";

                Assert.That(result.Naziv, Is.EqualTo(naziv));
                Assert.That(result.UrlSlike, Is.EqualTo(urlSlike));
            }

            [Test]
            public void ObucaService_EditObuca()
            {
                bool result = oService.Edit(new Obuca { ObucaId = 1, Naziv = "Puma", UrlSlike = "data:image/jpeg;base64,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", Velicina = 43, Cena = 9000.99, Kolicina = 4, ProdavnicaId = 2 });

                bool state = true;

                Assert.That(result, Is.EqualTo(state));
            }

            [Test]
            public void ObucaService_RemoveObuca()
            {
                bool result = oService.Remove(1);

                bool state = true;

                Assert.That(result, Is.EqualTo(state));
            }

            [Test]
            public void ObucaService_GetAllObucas()
            {
                var result = oService.Get();

                var count = 3;

                Assert.That(result.Count, Is.EqualTo(count));
            }
        }
}
