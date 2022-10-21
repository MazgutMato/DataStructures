using DataStructures.Iterator;
using DataStructures.Tree.BSTree;
using System.Collections;
using System.Runtime.InteropServices;

var BStree = new BSTree<int>();
var ControlArray = new List<int>();

Console.Write("Zadaj celkovy pocet opercii: ");
var pocetOperacii = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii vloz v %: ");
var pocetVloz = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii najdi v %: ");
var pocetNajdi = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii vymaz v %: ");
var pocetVymaz = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pomer opercii balancuj v %: ");
var pocetBalancuj = Convert.ToInt32(Console.ReadLine());

Console.Write("Zadaj pocet nahodne generovanych vkladanych cisel: ");
var generovaneCisla = Convert.ToInt32(Console.ReadLine());

if ((pocetVloz + pocetNajdi + pocetVymaz + pocetBalancuj) != 100) {
    Console.WriteLine("Sucet pomerov poctu operacii musi byt 100%!");
    return;
}

Console.WriteLine("Prebiehaju operacie, prosim cakajte!!!");

var random = new Random();

var celkovoVloz = 0;
var celkovoVymaz = 0;
var celkovoNajdi = 0;
var celkovoBalancuj = 0;

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
        if(BStree.Find(vkladaneCislo) != vkladaneCislo)
        {
            throw new InvalidOperationException("Cannot find inserted data!");
        }
    }
    else if (rand < pocetVloz + pocetNajdi) 
    {
        celkovoNajdi++;        
        if (ControlArray.Count > 0)
        {
            var hladaneCislo = Convert.ToInt32(ControlArray[random.Next(ControlArray.Count)]);
            Console.WriteLine("Hlada sa {0}", hladaneCislo);
            if (BStree.Find(hladaneCislo) != hladaneCislo)
            {
                throw new InvalidOperationException("Cannot find data!");
            }
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
                throw new InvalidOperationException("Cannot delete data!");
            }
            ControlArray.Remove(mazaneCislo);           
        }
        else
        {
            BStree.Delete(0);
        }
    }else
    {
        celkovoBalancuj++;
        BStree.BalanceTree();
        Console.WriteLine("Balancuje");
        Console.Write("\tBST:");
        var iterator = new BSTIterator<int>(BStree);
        while (iterator.HasNext())
        {
            var cislo = iterator.MoveNext();
            var height = BStree.GetNodeHeight(cislo);            
            Console.Write(" {0}({1})", cislo, height);
            if (Math.Abs(height) > 1)
            {
                throw new InvalidOperationException("Tree is not balance!");
            }
        }
        Console.WriteLine();
    }
}
Console.WriteLine("\nPocet operacii vloz: {0}", celkovoVloz);
Console.WriteLine("Pocet operacii najdi: {0}", celkovoNajdi);
Console.WriteLine("Pocet operacii vymaz: {0}", celkovoVymaz);
Console.WriteLine("Pocet operacii balancuj: {0}", celkovoBalancuj);

Console.WriteLine("Vsetky operacie prebehli uspesne!");

Console.WriteLine("Prebieha konrola prvkov struktury, prosim cakajte!");

if (ControlArray.Count == BStree.Count)
{
    Console.WriteLine("\nPocet prvkov struktury je spravny!" +
        "\n\tBST:{0}\n\tPole:{1}",BStree.Count,ControlArray.Count);
}
else
{
    Console.WriteLine("\nPocet prvkov struktury nie je spravny!" +
        "\n\tBST:{0}\n\tPole:{1}", BStree.Count, ControlArray.Count);
}

foreach(var data in ControlArray)
{
    if (BStree.Find((int)data) == 0)
    {
        Console.WriteLine("\t{0} sa v strukture nenasiel!",data);
    }
}

Console.Write("\nPrvky v strukture:\n BST: \t");
var BSTIterator = new BSTIterator<int>(BStree);
while (BSTIterator.HasNext())
{
    Console.Write("{0} ", BSTIterator.MoveNext());
}

Console.Write("\nPole: \t");
ControlArray.Sort();
foreach (var data in ControlArray)
{
    Console.Write("{0} ", data);
}