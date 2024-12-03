List<int> Col1 = new List<int>();
List<int> Col2 = new List<int>();

// Récupérer la liste d'input
string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "input.txt");
using (StreamReader sr = new StreamReader(path))
{
    string line = sr.ReadLine();
    // Placer les deux colonnes dans deux listes différentes
    while (line != null)
    {
        string[] numbers = line.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).ToArray(); ;
        Col1.Add(Int32.Parse(numbers[0]));
        Col2.Add(Int32.Parse(numbers[1]));
        line = sr.ReadLine();
    }
}

// Trier les deux listes par ordre de grandeur
Col1.Sort();
Col2.Sort();

// Comparer les deux listes : obtenir la plus petites valeur de la premiere liste, et faire la différence avec la plus petite valeur de la seconde liste
int result = 0; // stocker le resultat dans une variable
for (int i = 0; i < Col1.Count; i++) 
{
    result += Math.Abs(Col1[i] - Col2[i]);
}

// afficher la valeur de la variable finale.
Console.WriteLine(result);
