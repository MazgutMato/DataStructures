using DataStructures;
using System.Collections;
using System.Collections.Specialized;

var BStree = new BSTree<int>();
var ControlArray = new ArrayList();

Console.Write("Zadaj celkovy pocet opercii: ");
var pocetOperacii = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii vloz v %: ");
var pocetVloz = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii najdi v %: ");
var pocetNajdi = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii vymaz v %: ");
var pocetVymaz = Convert.ToInt32(Console.ReadLine());

if ((pocetVloz + pocetNajdi + pocetVymaz) != 100) {
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
        BStree.Add(i);
        ControlArray.Add(i);
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
    } else
    {
        celkovoVymaz++;
        if (ControlArray.Count > 0)
        {
            BStree.Delete((int)ControlArray[ControlArray.Count - 1]);
            ControlArray.RemoveAt(ControlArray.Count - 1);
        }
        else
        {
            BStree.Delete(0);
        }
    }
    //Console.Clear();
    Console.WriteLine("Prebiehaju operacie, prosim cakajte!!!");
    Console.WriteLine("Pocet operacii vloz: {0}", celkovoVloz);
    Console.WriteLine("Pocet operacii najdi: {0}", celkovoNajdi);
    Console.WriteLine("Pocet operacii vymaz: {0}", celkovoVymaz);
}

Console.WriteLine("Vsetko prebehlo uspesne!");
