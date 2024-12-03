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

int similarityScore = 0;
Dictionary<int, int> occurrences = new Dictionary<int, int>();
for (int i = 0; i < Col1.Count; i++) 
{
    result += Math.Abs(Col1[i] - Col2[i]);    
}

foreach (int num in Col2) // Ajout pour la partie 2, on créer un dictionnaire d'occurence pour les répétitions dans la seconde liste
{
    if (occurrences.ContainsKey(num))
    {
        occurrences[num]++;
    }
    else
    {
        occurrences[num] = 1;
    }
}

foreach (int num in Col1) // ajout pour la partie 2 : on compare les éléments de Col1 au dictionnaire, et si il y a similarité, on effectue le calcul du resutalt final
{
    if (occurrences.ContainsKey(num))
    {
        similarityScore += num * occurrences[num];
    }
}

// afficher la valeur de la variable finale.
Console.WriteLine(result);
Console.WriteLine(similarityScore);
