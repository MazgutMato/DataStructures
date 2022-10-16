﻿using DataStructures.Iterator;
using DataStructures.Tree.BSTree;
using System.Collections;
using System.Runtime.InteropServices;

var BStree = new BSTree<int>();
var ControlArray = new ArrayList();

BStree.Add(4);
BStree.Add(1);
BStree.Add(3);
BStree.Add(2);
BStree.BalanceTree();
Console.WriteLine();

/*
Console.Write("Zadaj celkovy pocet opercii: ");
var pocetOperacii = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii vloz v %: ");
var pocetVloz = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii najdi v %: ");
var pocetNajdi = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii vymaz v %: ");
var pocetVymaz = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii rotuj v %: ");
var pocetRotuj = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pocet nahodne generovanych vkladanych cisel: ");
var generovaneCisla = Convert.ToInt32(Console.ReadLine());

if ((pocetVloz + pocetNajdi + pocetVymaz + pocetRotuj) != 100) {
    Console.WriteLine("Sucet pomerov poctu operacii musi byt 100%!");
    return;
}

Console.WriteLine("Prebiehaju operacie, prosim cakajte!!!");

var random = new Random();

var celkovoVloz = 0;
var celkovoVymaz = 0;
var celkovoNajdi = 0;
var celkovoRotuj = 0;

for (int i = 0; i < pocetOperacii; i++)
{    
    var rand = random.Next(100);
    if (rand < pocetVloz)
    {
        celkovoVloz++;
        var vkladaneCislo = random.Next(1, generovaneCisla + 1);
        if (BStree.Add(vkladaneCislo))
        {
            ControlArray.Add(vkladaneCislo);
            Console.WriteLine("Vklada {0}",vkladaneCislo);
        }        
    }
    else if (rand < pocetVloz + pocetNajdi) 
    {
        celkovoNajdi++;
        if(ControlArray.Count > 0)
        {
            BStree.Find((int)ControlArray[ControlArray.Count - 1]);
        }
        else
        {
            BStree.Find(0);
        }
    } else if (rand < pocetVloz + pocetNajdi + pocetVymaz)
    {
        celkovoVymaz++;
        if (ControlArray.Count > 0)
        {
            var mazaneCislo = ControlArray[random.Next(ControlArray.Count)];
            BStree.Delete(Convert.ToInt32(mazaneCislo));
            Console.WriteLine("Maze {0}", mazaneCislo);
            if (BStree.Find(Convert.ToInt32(mazaneCislo)) != 0)
            {
                throw new Exception();
            }
            ControlArray.Remove(mazaneCislo);           
        }
        else
        {
            BStree.Delete(0);
        }
    } else
    {
        celkovoRotuj++;
        var typRotacie = random.Next(2);
        if (BStree.Count > 0)
        {
            var rotovanyPrvokIndex = random.Next(0,BStree.Count);
            if (typRotacie == 0)
            {
                BStree.RotateRight((int)ControlArray[rotovanyPrvokIndex]);
                Console.WriteLine("Rotuje doprava {0}", (int)ControlArray[rotovanyPrvokIndex]);
            } else            
            {
                BStree.RotateLeft((int)ControlArray[rotovanyPrvokIndex]);
                Console.WriteLine("Rotuje dolava {0}", (int)ControlArray[rotovanyPrvokIndex]);
            }
        }
    }
}
Console.WriteLine("Pocet operacii vloz: {0}", celkovoVloz);
Console.WriteLine("Pocet operacii najdi: {0}", celkovoNajdi);
Console.WriteLine("Pocet operacii vymaz: {0}", celkovoVymaz);
Console.WriteLine("Pocet operacii vymaz: {0}", celkovoRotuj);

Console.WriteLine("Vsetky operacie prebehli uspesne!");

Console.WriteLine("Prebieha konrola prvkov struktury, prosim cakajte!");

if (ControlArray.Count == BStree.Count)
{
    Console.WriteLine("Pocet prvkov struktury je spravny!");
}
else
{
    Console.WriteLine("Pocet prvkov struktury nie je spravny!");
}

foreach(var data in ControlArray)
{
    if (BStree.Find((int)data) == 0)
    {
        Console.WriteLine("{0} sa v strukture nenasiel!",data);
        return;
    }
}

Console.WriteLine("Vsetky prvky sa v strukture nasli!");

Console.Write("Prvky v strukture:\n BST: \t");
var BSTIterator = new BSTIterator<int>(BStree);
while (BSTIterator.HasNext())
{
    Console.Write("{0} ", BSTIterator.MoveNext());
}

Console.Write("\nPole: \t");
foreach (var data in ControlArray)
{
    Console.Write("{0} ", data);
}

*/