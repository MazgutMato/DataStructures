using DataStructures.File;
using DataStructures.Iterator;
using DataStructures.Tree.BSTree;
using DataStructures.Tree.DFTree;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

var again = true;

Console.Write("Zadaj celkovy pocet opercii: ");
var pocetOperacii = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii vloz v %: ");
var pocetVloz = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii najdi v %: ");
var pocetNajdi = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii vymaz v %: ");
var pocetVymaz = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pocet nahodne generovanych vkladanych cisel: ");
var generovaneCisla = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj block factor: ");
var blockFactor = Convert.ToInt32(Console.ReadLine());

Console.Write("Priebezne vypisy(a/n): ");
var priebeznyVipis = false;
if(Console.ReadLine() == "a")
{
    priebeznyVipis = true;
}

var example = new Example();
var file = new DynamicFile<Example>(blockFactor, "Data.dat");
var ControlArray = new List<int>();

while (again)
{
    file.File.Close();
    file = new DynamicFile<Example>(blockFactor, "Data.dat");
    ControlArray = new List<int>();

    if ((pocetVloz + pocetNajdi + pocetVymaz) != 100)
    {
        Console.WriteLine("Sucet pomerov poctu operacii musi byt 100%!");
        return;
    }

    Console.WriteLine("Prebiehaju operacie, prosim cakajte!!!");

    var random = new Random();

    var celkovoVloz = 0;
    var celkovoVymaz = 0;
    var celkovoNajdi = 0;

    for (int i = 0; i < pocetOperacii; i++)
    {
        var rand = random.Next(100);
        if (rand < pocetVloz)
        {
            celkovoVloz++;
            var vkladaneCislo = random.Next(1, generovaneCisla + 1);
            example.ID = vkladaneCislo;
            if (file.Find(example) == null)
            {
                if (priebeznyVipis)
                {
                    Console.WriteLine("Vklada {0}", vkladaneCislo);
                }                
                file.Add(example);
                ControlArray.Add(vkladaneCislo);
                var found = file.Find(example);
                if (found == null || found.ID != vkladaneCislo)
                {
                    throw new InvalidOperationException("Nenasiel sa vlozeny prvok!");
                }
            }
        }
        else if (rand < pocetVloz + pocetNajdi)
        {
            celkovoNajdi++;
            if (ControlArray.Count > 0)
            {
                var hladaneCislo = Convert.ToInt32(ControlArray[random.Next(ControlArray.Count)]);
                example.ID = hladaneCislo;
                if (priebeznyVipis){
                    Console.WriteLine("Hlada sa {0}", hladaneCislo);
                }                
                var found = file.Find(example);
                if (found == null || found.ID != hladaneCislo)
                {
                    throw new InvalidOperationException("Nenasiel sa vlozeny prvok!");
                }
            }
        }
        else
        {
            celkovoVymaz++;
            if (ControlArray.Count > 0)
            {
                var mazaneCislo = ControlArray[random.Next(ControlArray.Count)];
                example.ID = mazaneCislo;
                if (priebeznyVipis)
                {
                    Console.WriteLine("Maze {0}", mazaneCislo);
                }                
                file.Delete(example);
                ControlArray.Remove(mazaneCislo);
            }
            else
            {
                file.Delete(example);
            }
        }
        if (priebeznyVipis)
        {
            Console.WriteLine(file.GetBlocks());
        }
    }

    Console.WriteLine("\nPocet operacii vloz: {0}", celkovoVloz);
    Console.WriteLine("Pocet operacii najdi: {0}", celkovoNajdi);
    Console.WriteLine("Pocet operacii vymaz: {0}", celkovoVymaz);

    Console.WriteLine("Vsetky operacie prebehli uspesne!");

    Console.WriteLine(file.GetBlocks());

    foreach (var data in ControlArray)
    {
        example.ID = data;
        var found = file.Find(example);
        if (found == null || found.ID != data)
        {
            Console.WriteLine("\t{0} sa v strukture nenasiel!", data);
            throw new InvalidOperationException("Nenasiel sa vlozeny prvok!");

        }
        file.Delete(example);
    }

    Console.WriteLine("Vsetky prvky sa v strukture nasli!");

    Console.Write("Zopakovat test (a/n) : ");
    var opakovat = Console.ReadLine();

    if (opakovat != "a")
    {
        again = false;
    }
}