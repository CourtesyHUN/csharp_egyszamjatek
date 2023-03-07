using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace helsinki1952
{
    class Program
    {
        static List<int> helyezes = new List<int>();
        static List<int> sportolodb = new List<int>();
        static List<string> sportag = new List<string>();
        static List<string> versenyszam = new List<string>();
        static int db = 0;
        static void Main(string[] args)
        {
            sr();
            elso();
            ermek();
            rangsor();
            ermeszam();
            filebairas();
            Console.ReadKey();
        }

        #region Beolvas
        static void sr()
        {
            StreamReader sr = new StreamReader("helsinki.txt");
            string sor = sr.ReadLine();
            string[] s;
            while (sor != null)
            {
                s = sor.Split(' ');
                helyezes.Add(Convert.ToInt32(s[0]));
                sportolodb.Add(Convert.ToInt32(s[1]));
                sportag.Add(s[2]);
                versenyszam.Add(s[3]);
                db++;
                sor = sr.ReadLine();
            }
            sr.Close();
        }
        #endregion

        #region 3. feladat
        static void elso()
        {
            Console.WriteLine("3.feladat: {0} db pontszerző helyezés volt",db);
        }
        #endregion

        #region 4.feladat
        static void ermek()
        {
            int arany = 0;
            int ezust = 0;
            int bronz = 0;
            Console.WriteLine("\n4.feladat: ");
            for (int i = 0; i < db; i++)
            {
                if (helyezes[i] == 1)
                {
                    arany++;
                }
                else if (helyezes[i] == 2)
                {
                    ezust++;
                }
                else if (helyezes[i] == 3)
                {
                    bronz++;
                }
            }
            Console.WriteLine(arany+"db arany érem volt");
            Console.WriteLine(ezust+ "db ezüst érem volt");
            Console.WriteLine(bronz+ "db bronz érem volt");
        }
        #endregion

        #region 5.feladat
        static void rangsor()
        {
            #region Változók
            int elso = 0;
            int masodik = 0;
            int harmadik = 0;
            int negyedik = 0;
            int otodik = 0;
            int hatodik = 0;
            int hetedik = 0;
            #endregion
            for (int i = 0; i < db; i++)
            {
                if (helyezes[i] == 1)
                {
                    elso+=7;
                }
                else if (helyezes[i] == 2)
                {
                    masodik += 5;
                }
                else if (helyezes[i] == 3)
                {
                    harmadik += 4;
                }
                else if (helyezes[i] == 4)
                {
                    negyedik += 3;
                }
                else if (helyezes[i] == 5)
                {
                    otodik += 2;
                }
                else if (helyezes[i] == 6)
                {
                    hatodik += 1;
                }
            }
            Console.WriteLine("\n5. feladat: ");
            Console.WriteLine("Olimpiai pontok: "+(elso+masodik+harmadik+negyedik+otodik+hatodik));

        }

        #endregion

        #region 6.feladat
        static void ermeszam()
        {
            int upont = 0; 
            int tpont = 0;
            Console.WriteLine("\n6.feladat");
            for (int i = 0; i < db; i++)
            {
                if (sportag[i] == "uszas" && helyezes[i] <= 3)
                {
                    upont++;
                }
                else if (sportag[i] == "torna" && helyezes[i] >= 3)
                {
                    tpont++;
                }
            }
            if (upont<tpont)
            {
                Console.WriteLine("Torna sportágban szereztek több pontot");
            }
            else if (upont > tpont)
            {
                Console.WriteLine("Úszás sportágban szereztek több pontot");
            }
            else
            {
                Console.WriteLine("Egyenlő volt az érmek száma");
            }
        }

        #endregion

        #region 7.feladat
        static void filebairas()
        {
            StreamWriter sw= new StreamWriter("helsinki2.txt");
            for (int i = 0; i < db; i++)
            {
                if (sportag[i] == "kajakkenu" || sportag[i] == "kajak?kenu")
                {
                    sportag[i] = "kajak-kenu";
                }
                
            }
            sw.WriteLine("");

            sw.Close();
        }
        #endregion
    }
}

