using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace jarmu
{
    class Jaror
    {
        static List<int> ora = new List<int>();
        static List<int> perc = new List<int>();
        static List<int> mp = new List<int>();
        static List<string> rendszam = new List<string>();

        static void Main(string[] args)
        {
            #region Feladat 1
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("1. feladat");
            Console.ResetColor();
            Console.WriteLine("Adatok feltöltve!\n");
            Feltolt();
            #endregion
            #region Feladat 2
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("2. feladat:");
            Console.ResetColor();
            Console.WriteLine("A járőr munkaideje: {0}\n", ora[(ora.Count - 1)] - ora[0] + 1);
            #endregion
            #region Feladat 3
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("3. feladat:");
            Console.ResetColor();
            Ellenor();
            Console.WriteLine();
            #endregion
            #region Feladat 4
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("4. feladat:");
            Console.ResetColor();
            Jarmutipus();
            Console.WriteLine();
            #endregion
            #region Feladat 5
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("5. feladat:");
            Console.ResetColor();
            Jarmutipus();
            Console.WriteLine();
            #endregion
            #region Feladat 6
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("6. feladat:");
            Console.ResetColor();
            Console.Write("A leghosszabb forgalommentes időszak: ");
            Console.WriteLine(Forgalommentes()+"\n");
            Resize();
            #endregion
            #region Feladat 7
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("7. feladat:");
            Console.ResetColor();
            Console.Write("Kérem a rendszám mintázatát (A*-2*3* ezzel teszt): ");
            string rminta = Console.ReadLine();
            Console.WriteLine("Illeszkedő rendszámok: ");
            Rendszamkiir(rminta);
            #endregion
            //Valahol elcsűszott a számozás
            #region Feladat 7
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("7. feladat:");
            Console.ResetColor();
            Ellenor();
            Ellenorzes();
            Console.WriteLine("Fájlbaírás kész!");
            #endregion
            Console.ReadKey();
        }

        #region Saját
        static void Resize()
        {
            for (int i = 1; i < 41; i++)
            {
                Console.WindowHeight = i;
                Console.WindowWidth = i*3;
                System.Threading.Thread.Sleep(20);
            }
            
        }
        #endregion 

        #region Lista feltöltése
        static void Feltolt()
        {
            StreamReader sr = new StreamReader("jarmu.txt");
            string sor = sr.ReadLine();
            string[] s;
            while (sor != null)
            {
                s = sor.Split(' ');
                ora.Add(Convert.ToInt32(s[0]));
                perc.Add(Convert.ToInt32(s[1]));
                mp.Add(Convert.ToInt32(s[2]));
                rendszam.Add(s[3]);
                sor = sr.ReadLine();
            }
            sr.Close();
        }
        #endregion

        #region Ellenőr
        static void Ellenor()
        {
            int aktualis = ora[0];
            int elozo = aktualis;
            Console.WriteLine("{0} óra: {1}", aktualis, rendszam[0]);
            for (int i = 0; i < ora.Count; i++)
            {
                aktualis = ora[i];
                if (aktualis != elozo)
                {
                    Console.WriteLine("{0} óra: {1}", aktualis, rendszam[i]);
                    aktualis = ora[i];
                    elozo = aktualis;
                }
            }
        }
        #endregion

        #region Jármű típus

        static void Jarmutipus()
        {
            int b = 0, m = 0, k = 0, a = 0;
            for (int i = 0; i < rendszam.Count; i++)
            {
                switch (rendszam[i][0])
                {
                    case 'B':
                        b++;
                        break;
                    case 'M':
                        m++;
                        break;
                    case 'K':
                        k++;
                        break;
                    case 'A':
                        break;

                    default:
                        a++;
                        break;
                }
            }
            Console.WriteLine("Elhaladt járműtípusk darabszáma: ");
            Console.WriteLine("Autóbusz: {0} db", b);
            Console.WriteLine("Kamion: {0} db", k);
            Console.WriteLine("Motorok: {0} db", m);
            Console.WriteLine("Autó: {0} db", a, "\n");


        }

        #endregion

        #region Külömbség
        static TimeSpan Kulonbseg(int o1, int p1, int mp1, int o2, int p2, int mp2)
        {
            DateTime aktido = new DateTime(1, 1, 1, o1, p1, mp1);
            DateTime kovido = new DateTime(1, 1, 1, o2, p2, mp2);
            return kovido - aktido;

        }
        #endregion

        #region Forgalommentes időszak
        static string Forgalommentes()
        {
            int poz = 0;
            TimeSpan kulombseg = Kulonbseg(ora[0], perc[0], mp[0], ora[1], perc[1], mp[1]);
            for (int i = 1; i < ora.Count-1; i++)
            {
                if (Kulonbseg(ora[i], perc[i], mp[i+1], ora[i+1], perc[i+1], mp[i+1]) > kulombseg)
                {
                    kulombseg = Kulonbseg(ora[i], perc[i], mp[i + 1], ora[i + 1], perc[i + 1], mp[i + 1]);
                    poz = i;
                }
            }
            return ora[poz]+":"+perc[poz]+":"+ mp[poz]+" - "+ ora[poz + 1] + ":" + perc[poz + 1] + ":" + mp[poz + 1];
        }

        #endregion

        #region Rendszámki ír
        static void Rendszamkiir(string rminta)
        {
            bool egyezik;
            foreach (string item in rendszam)
            {
                egyezik = true;
                for (int i = 0; i < 7; i++)
                {
                    if (rminta[i] != '*' && item[i] != rminta[i])
                    {
                        egyezik = false;
                    }                
                }
                if (egyezik) Console.WriteLine(item);
            } 
        }
        #endregion

        #region Ellenorzés
        static void Ellenorzes()
        {
            StreamWriter sw = new StreamWriter("vizsgalt.txt");
            sw.WriteLine(ora[0]+":"+ perc[0]+":" + mp[0]+":"+rendszam[0]);
            int ido = ora[0]*3600+perc[0]*60+mp[0]; //Az órát percet mp-et átrakja csak másodpercre
            for (int i = 0; i < ora.Count; i++)
            {
                if (ido-(ora[i] * 3600 + perc[i] * 60 + mp[i]) >= 300)
                {
                    sw.WriteLine(ora[i] + ":" + perc[i] + ":" + mp[i] + ":" + rendszam[i]);
                    ido = ora[i] * 3600 + perc[i] * 60 + mp[i];
                }//nem jó
            }
            //Választás hogy megnyitom e a file-t otthon
            sw.Close();
        }
        #endregion

    }
}