using DataStructures;

BSTree<int> tree = new BSTree<int>();

tree.Add(4);
tree.Add(6);
tree.Add(2);
tree.Add(3);
tree.Add(5);

Console.WriteLine(tree.Find(6));
Console.WriteLine(tree.Find(4));

Console.WriteLine("Hello, World!");
