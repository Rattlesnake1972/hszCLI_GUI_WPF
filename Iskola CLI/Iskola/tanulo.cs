using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola
{
    public class tanulo
    {
        public int KezdesEve { get; private set; } // A nevek.txt beolvasandó file első oszlopa a tanuló iskolában való kezdésének évszámát tartalmazza. Egy szám, ami ezért integer (int) típusú lesz. A private set azt jelenti, hogy az adat módosításának lehetőségét elrejtsük a felhasználó elől. Ezt Encapsulation-nek (kapszulázás) nevezzük.Ezeket a privát változókat csak ugyanazon az osztályon belül lehet elérni (egy külső osztály nem fér hozzá). A { get; private set } a függvény konstruktora.

        public string OsztalyBetujele { get; private set; }
        public string DiakNeve { get; private set; }

        public tanulo (string sor) // A tanulok adatait nyilvánossá (public) kell tenni, hogy a felhasználó is láthassa őket. A string sor-ral beolvasunk egy sort a nevek.txt file-ból. A sor nevű szöveges változóban tárolunk egy sornyi adatot a nevek.txt file-ból, ami egy tanuló adatait (iskolában való kezdésének évszámát, osztályának betűjelét és teljes nevét) tartalmazza.
        {
            string[] darabok = sor.Split(';'); // Nekünk nem csak egy, hanem sok tanulo adatait kell tárolnunk, ezért létre kell hozni egy egyelőre ismeretlen nagyságú, több elemű szöveges tömböt (string[]) és elnevezzük darabok-nak. Ebben a nevek.txt file-ban szereplő összes tanuló adatai majd benne lesznek. Viszont a sor nevű változóban itt már a nevek.txt file összes sora benne lesz, amiket a kettőspontok mentén el kell darabolni (Splittelni).

            this.KezdesEve = Convert.ToInt32(darabok[0]); // A this kulcsszó az aktuális tanulo osztály egy példányára utal. Itt a KezdesEve int, azaz egy egész számos változóként lett megadva, de hogy a fordító ezt értelmezni tudja, át kell konvertálni szöveges (stringes) változóvá. Ez lesz a tömb 0. eleme.

            this.OsztalyBetujele = darabok[1];
            this.DiakNeve = darabok[2];
        }
    }
}
