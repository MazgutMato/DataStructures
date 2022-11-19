using DataStructures.File;
using DataStructures.Iterator;
using DataStructures.Tree.BSTree;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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

var example = new Example();
var staticFile = new StaticFile<Example>(blockFactor, "Data.dat");
var ControlArray = new List<int>();

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
        if (staticFile.Add(example))
        {
            ControlArray.Add(vkladaneCislo);
            Console.WriteLine("Vklada {0}", vkladaneCislo);
            var found = staticFile.Find(example);
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
            Console.WriteLine("Hlada sa {0}", hladaneCislo);
            var found = staticFile.Find(example);
            if (found == null || found.ID != hladaneCislo)
            {
                throw new InvalidOperationException("Nenasiel sa vlozeny prvok!");
            }
        }
        else
        {
            staticFile.Find(example);
        }
    }
    else
    {
        celkovoVymaz++;
        if (ControlArray.Count > 0)
        {
            var mazaneCislo = ControlArray[random.Next(ControlArray.Count)];
            example.ID = mazaneCislo;
            staticFile.Delete(example);
            Console.WriteLine("Maze {0}", mazaneCislo);
            ControlArray.Remove(mazaneCislo);
        }
        else
        {
            staticFile.Delete(example);
        }
    }
}

Console.WriteLine("\nPocet operacii vloz: {0}", celkovoVloz);
Console.WriteLine("Pocet operacii najdi: {0}", celkovoNajdi);
Console.WriteLine("Pocet operacii vymaz: {0}", celkovoVymaz);

Console.WriteLine("Vsetky operacie prebehli uspesne!");

foreach (var data in ControlArray)
{
    example.ID = data;
    var found = staticFile.Find(example);
    if (found == null || found.ID != data)
    {
        Console.WriteLine("\t{0} sa v strukture nenasiel!", data);
        throw new InvalidOperationException("Nenasiel sa vlozeny prvok!");

    }
    staticFile.Delete(example);
}

Console.WriteLine("Vsetky prvky sa v strukture nasli!");