using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Nyelvvizsga;

//adattárolás - osztály => Eredmeny

//1. feladat
List<Eredmeny> sikertelen = File.ReadAllLines("sikertelen.csv", encoding: System.Text.Encoding.UTF8).Skip(1).Select(sor => new Eredmeny(sor)).ToList();
List<Eredmeny> sikeres = File.ReadAllLines("sikeres.csv", encoding: System.Text.Encoding.UTF8).Skip(1).Select(sor => new Eredmeny(sor)).ToList();

//2. feladat
Dictionary<string, int> osszErtek = new Dictionary<string, int>();
foreach (Eredmeny eredmeny in sikeres)
{
    osszErtek[eredmeny.Nyelv] = eredmeny.Eredmenyek.Sum();
}

foreach (Eredmeny eredmeny in sikertelen)
{
    osszErtek[eredmeny.Nyelv] += eredmeny.Eredmenyek.Sum();
}

foreach (var eredmeny in osszErtek.OrderByDescending(x => x.Value).Take(3))
{
    Console.WriteLine($"{eredmeny.Key}: {eredmeny.Value}");
}

//3. feladat

int bekert = 0;
do
{ 
	Console.Write("Kérek egy egész számot 2009-2017 között: ");
    bekert = Convert.ToInt32(Console.ReadLine());
} while ( bekert < 2009 || bekert > 2017 );

//4. feladat
Dictionary<string, List<int>> nyelvEvSzerint = new Dictionary<string, List<int>>();

List<int> evek = new List<int>();
string[] sor = File.ReadAllLines("sikeres.csv").First().Split(';');
for (int i = 1; i < sor.Length; i++)
{
    evek.Add(Convert.ToInt32(sor[i]));
}

foreach (Eredmeny eredmeny in sikeres)
{
    for (int i = 0; i < evek.Count; i++)
    {
        if (evek[i] == bekert)
        {
            nyelvEvSzerint[eredmeny.Nyelv][0] = eredmeny.Eredmenyek[i];
            break;
        }
    }
}

foreach (Eredmeny eredmeny in sikertelen)
{
    for (int i = 0; i < evek.Count; i++)
    {
        if (evek[i] == bekert)
        {
            nyelvEvSzerint[eredmeny.Nyelv][1] = eredmeny.Eredmenyek[i];
            break;
        }
    }
}

StreamWriter sw = new StreamWriter("osszesito.csv", false);


foreach (var item in nyelvEvSzerint)
{
    double eredmeny = Math.Round(((item.Value[1] * 1.0) / ((item.Value[0] + item.Value[1]) * 1.0)) * 100.0, 2);
    Console.WriteLine($"{item.Key}: {eredmeny}%");
    //6. feladat
    string a = "";
    
    sw.WriteLine($"{item.Key};{a}{eredmeny}");
}

sw.Close();
