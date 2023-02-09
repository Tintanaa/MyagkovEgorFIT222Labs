var input = File.ReadAllLines(@"D:\Programming\Univer\file.txt");
int[,] num = new int[input.Length, input[0].Split(' ').Length];
int i = 0;
int j = 0;
for (i = 0; i < input.Length; i++)
{
    string[] temp = input[i].Split(' ');

    for (j = 0; j < temp.Length; j++)
    {
        num[i, j] = Convert.ToInt32(temp[j]);
    }
}
Prim(num, i);
static int MinKey(int[] key, bool[] set, int verticesCount)
{
    int min = int.MaxValue, minIndex = 0;

    for (int v = 0; v < verticesCount; ++v)
    {
        if (set[v] == false && key[v] < min)
        {
            min = key[v];
            minIndex = v;
        }
    }

    return minIndex;
}

static void Print(int[] parent, int[,] graph, int verticesCount)
{
    Console.WriteLine("Edge     Weight");
    for (int i = 1; i < verticesCount; ++i)
        Console.WriteLine("{0} - {1}    {2}", parent[i], i, graph[i, parent[i]]);
}

static void Prim(int[,] graph, int verticesCount)
{
    int[] parent = new int[verticesCount];
    int[] key = new int[verticesCount];
    bool[] mstSet = new bool[verticesCount];

    for (int i = 0; i < verticesCount; ++i)
    {
        key[i] = int.MaxValue;
        mstSet[i] = false;
    }

    key[0] = 0;
    parent[0] = -1;

    for (int count = 0; count < verticesCount - 1; ++count)
    {
        int u = MinKey(key, mstSet, verticesCount);
        mstSet[u] = true;

        for (int v = 0; v < verticesCount; ++v)
        {
            if (Convert.ToBoolean(graph[u, v]) && mstSet[v] == false && graph[u, v] < key[v])
            {
                parent[v] = u;
                key[v] = graph[u, v];
            }
        }
    }
    Print(parent, graph, verticesCount);
}