string[] lines = File.ReadAllLines(@"path/to/text");
int[,] num = new int[lines.Length, lines[0].Split(' ').Length];
for (int i = 0; i < lines.Length; i++)
{
    string[] temp = lines[i].Split(' ');
    for (int j = 0; j < temp.Length; j++)
        num[i, j] = Convert.ToInt32(temp[j]);
}
for (int i = 0; i < num.GetLength(0); i++)

    for (int j = 0; j < num.GetLength(1); j++)
        Console.WriteLine(num[i, j]);
Dijkstra(num, 0, 9);
/*
 * Матрица в виде
 * 0 1 2 3 4
 * 5 6 7 8 9
 * 10 11 12 13 14
 * 15 16 17 18 19
 * ..............
 */

static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
{
    int min = int.MaxValue;
    int minIndex = 0;

    for (int v = 0; v < verticesCount; ++v)
    {
        if (shortestPathTreeSet[v] == false && distance[v] <= min)
        {
            min = distance[v];
            minIndex = v;
        }
    }

    return minIndex;
}

static void Print(int[] distance, int verticesCount)
{
    Console.WriteLine("Vertex    Distance from source");

    for (int i = 0; i < verticesCount; ++i)
        Console.WriteLine("{0}\t  {1}", i, distance[i]);
}
static void Dijkstra(int[,] graph, int source, int verticesCount)
{
    int[] distance = new int[verticesCount];
    bool[] shortestPathTreeSet = new bool[verticesCount];

    for (int i = 0; i < verticesCount; ++i)
    {
        distance[i] = int.MaxValue;
        shortestPathTreeSet[i] = false;
    }

    distance[source] = 0;

    for (int count = 0; count < verticesCount - 1; ++count)
    {
        int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
        shortestPathTreeSet[u] = true;

        for (int v = 0; v < verticesCount; ++v)
            if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                distance[v] = distance[u] + graph[u, v];
    }

    Print(distance, verticesCount);
}
