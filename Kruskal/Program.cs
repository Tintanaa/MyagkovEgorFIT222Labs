using System.Security.Cryptography;

Console.WriteLine("Введите количество вершин");
int verticesCount = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество рёбер");
int edgesCount = Convert.ToInt32(Console.ReadLine());
Graph graph = CreateGraph(verticesCount, edgesCount);
bool breakinput = false;
while(breakinput != true)
{
    int num = 0;
    Console.WriteLine("Вершина начальная");
    graph.edge[num].Source = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Вершина конечная");
    graph.edge[num].Destination = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Вес ребра");
    graph.edge[num].Weight = Convert.ToInt32(Console.ReadLine());
    Console.Clear();
    if (num == edgesCount)
    {
        breakinput = true;
        Console.Clear();
    }
    else
    {
        num++;
    }
}
Graph CreateGraph(int verticesCount, int edgesCoun)
{
    Graph graph = new Graph();
    graph.VerticesCount = verticesCount;
    graph.EdgesCount = edgesCoun;
    graph.edge = new Edge[graph.EdgesCount];

    return graph;
} 
static int Find(Subset[] subsets, int i)
{
    if (subsets[i].Parent != i)
        subsets[i].Parent = Find(subsets, subsets[i].Parent);

    return subsets[i].Parent;
}

static void Union(Subset[] subsets, int x, int y)
{
    int xroot = Find(subsets, x);
    int yroot = Find(subsets, y);

    if (subsets[xroot].Rank < subsets[yroot].Rank)
        subsets[xroot].Parent = yroot;
    else if (subsets[xroot].Rank > subsets[yroot].Rank)
        subsets[yroot].Parent = xroot;
    else
    {
        subsets[yroot].Parent = xroot;
        ++subsets[xroot].Rank;
    }
}

static void Print(Edge[] result, int e)
{
    for (int i = 0; i < e; ++i)
        Console.WriteLine("{0} -- {1} == {2}", result[i].Source, result[i].Destination, result[i].Weight);
}

static void Kruskal(Graph graph)
{
    int verticesCount = graph.VerticesCount;
    Edge[] result = new Edge[verticesCount];
    int i = 0;
    int e = 0;

    Array.Sort(graph.edge, delegate (Edge a, Edge b)
    {
        return a.Weight.CompareTo(b.Weight);
    });

    Subset[] subsets = new Subset[verticesCount];

    for (int v = 0; v < verticesCount; ++v)
    {
        subsets[v].Parent = v;
        subsets[v].Rank = 0;
    }

    while (e < verticesCount - 1)
    {
        Edge nextEdge = graph.edge[i++];
        int x = Find(subsets, nextEdge.Source);
        int y = Find(subsets, nextEdge.Destination);

        if (x != y)
        {
            result[e++] = nextEdge;
            Union(subsets, x, y);
        }
    }

    Print(result, e);
}
public struct Edge
{
    public int Source;
    public int Destination;
    public int Weight;
}

public struct Graph
{
    public int VerticesCount;
    public int EdgesCount;
    public Edge[] edge;
}

public struct Subset
{
    public int Parent;
    public int Rank;
}

