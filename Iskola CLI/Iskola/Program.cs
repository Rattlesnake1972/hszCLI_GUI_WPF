using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  // Legelső dolog, hogy ezt a névteret felvesszük, mert ez kell az adatokkal való munkához!!!

namespace Iskola
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<tanulo> tanulolista = new List<tanulo>(); // Ennél a pontnál létre kell hoznunk egy tanulo osztályt külön tanulo.cs file-ban a Solution Explorerben, mert enélkül piros szaggatott vonallal alá fogja húzni, hibát jelez. A tanulo.cs file-nak tartalmaznia kell azt, amit a nevek.txt file tartalmaz, mert ez lesz a beolvasandó file, ami a tanulók adatait tartalmazza. Pontosabban a tanulo kezdési évét az iskolában, az osztálya betűjelét, illetve a nevét. A tanulok.cs file létrehozása: Solution Explorerben jobb klikk Iskola --> Add --> Class. A Class-t, azaz az osztályt elnevezzük tanulo.cs-nek és OK. Innentől kezdve a List után nem jelez hibát.

            StreamReader sr = new StreamReader("nevek.txt"); // Beolvassuk a nevek.txt file tartalmát.

            while (!sr.EndOfStream) // Amíg a beolvasás nem ér a végére a nevek.txt file-nak, míg be nem olvasta az összes adatot belőle, addig
            {
                tanulolista.Add(new tanulo(sr.ReadLine())); // adja hozzá a tanulolista nevű listához a nevek.txt file-ban található összes tanulót és írja ki az sr nevű beolvasás eredményét külön sorokban és jelenítse is meg azokat!
            }
            sr.Close(); // Ha a beolvasás a végére ért zárja be az sr nevű beolvasást.

            // Tanulók minden adata és darabszáma

            Console.WriteLine("3. feladat: A tanulók száma és minden adatuk.");
            Console.WriteLine();

            foreach (var item in tanulolista)
            {
                Console.WriteLine("A tanuló neve: " + item.DiakNeve);
                Console.WriteLine("A tanuló kezdési éve: " + item.KezdesEve);
                Console.WriteLine("A tanuló osztálya: " + item.OsztalyBetujele);
                Console.WriteLine();
            }
            Console.WriteLine("A tanulók száma: " + tanulolista.Count + " fő.");

            // 4. feladat: a névsorban az első és az utolsó tanuló azonosítójának létrehozása. Az azonosítók felépítése: első karaktere a kezdés évének utolsó számjegye, második karakter a tanuló vezetéknevének első három betűje, harmadik karaktere keresztnevének első három karaktere.

            Console.WriteLine();
            Console.WriteLine("4. feladat: a névsorban első és utolsó tanuló egyedi azonosítója:");
            Console.WriteLine();

            Console.WriteLine(tanulolista[0].DiakNeve);  // Ezzel a sorral határozzuk meg a névsorban az első tanuló nevét.
            Console.WriteLine(createazonosito(tanulolista[0]));

            Console.WriteLine(tanulolista[tanulolista.Count-1].DiakNeve); // Ezzel a sorral kapjuk meg a névsorban az utolsó tanuló nevét.
            Console.WriteLine(createazonosito(tanulolista[tanulolista.Count-1]));

            // Írja ki az öszes tanuló nevét és azonosítóját a nevek2.txt fájlba.

            StreamWriter sw = new StreamWriter("nevek2.txt");

            foreach (tanulo t in tanulolista)
            {
                string sor = t.DiakNeve + "#" + createazonosito(t);
                sw.WriteLine(sor);
            }
            sw.Close();

            Console.Read();
        }

        public static string createazonosito(tanulo t)
        {
            string azonosito = "";
            azonosito += (t.KezdesEve % 10).ToString();
            azonosito += (t.OsztalyBetujele);
            azonosito += (t.DiakNeve.Substring(0, 3).ToLower());
            azonosito += t.DiakNeve.Split(' ')[1].Substring(0, 3).ToLower();

            return azonosito;
        }
    }
}
