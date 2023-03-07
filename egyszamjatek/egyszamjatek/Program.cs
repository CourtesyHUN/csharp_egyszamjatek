using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace egyszamjatek
{
    class Program
    {
        static List<string[]> sor = new List<string[]>(); 
        static void Main(string[] args)
        {
            
            foreach (string line in File.ReadLines("egyszamjatek.txt"))
            {
                sor.Add(line.Split(' '));
            }
        }
    }
}
