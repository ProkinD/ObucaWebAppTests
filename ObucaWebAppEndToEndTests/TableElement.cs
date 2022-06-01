using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObucaWebAppEndToEndTests
{
    class TableElement
    {
        List<TableData> CelijeTabele = new List<TableData>();

        public void ProcitajCelijeTabele(IWebElement tabela)
        {
            var redovi = tabela.FindElements(By.TagName("tr"));
            var kolone = tabela.FindElements(By.TagName("th"));

            var brojReda = 0;

            foreach (var red in redovi)
            {
                int brojKolone = 0;
                var celije = red.FindElements(By.TagName("td"));

                foreach (var celija in celije)
                {
                    CelijeTabele.Add(new TableData
                    {
                        BrojReda = brojReda,
                        NazivKolone = kolone[brojKolone].Text != "" ? kolone[brojKolone].Text : brojKolone.ToString(),
                        Vrednost = celija.Text,
                        ElementiCelije = kolone[brojKolone].Text != "" ? null : celija.FindElements(By.TagName("a"))
                    });
                    brojKolone++;
                }
                brojReda++;
            }
        }

        public int BrojCelijaTabele(IWebElement tabela)
        {
            var redovi = tabela.FindElements(By.TagName("tr"));
            
            var brojRedova = 0;

            foreach (var red in redovi)
            {                 
                brojRedova++;
            }
            return brojRedova;
        }

        public string VrednostCelije(string nazivKolone, int brojReda)
        {
            return CelijeTabele
                .SingleOrDefault(celija => celija.NazivKolone.Equals(nazivKolone) && celija.BrojReda == brojReda)?
                .Vrednost;
        }

        public IWebElement ElemetCelije(string nazivKolone, int brojReda, string tekst)
        {
            var celija = CelijeTabele
                .SingleOrDefault(c => c.NazivKolone.Equals(nazivKolone) && c.BrojReda == brojReda);

            return celija?.ElementiCelije.SingleOrDefault(e => e.Text == tekst);
        }
    }

    public class TableData
    {
        public int BrojReda { get; set; }
        public string NazivKolone { get; set; }
        public string Vrednost { get; set; }
        public IEnumerable<IWebElement> ElementiCelije { get; set; }
    }
}

