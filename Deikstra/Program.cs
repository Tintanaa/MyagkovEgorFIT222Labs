using ClosedXML.Excel;
using System.Data;
DataTable _dt = new DataTable();
_dt = ImportSheet("");
Dijkstra(_dt,0,9);
static DataTable ImportSheet(string fileName)
{
    var datatable = new DataTable();
    var workbook = new XLWorkbook(fileName);
    var xlWorksheet = workbook.Worksheet(1);
    var range = xlWorksheet.Range(xlWorksheet.FirstCellUsed(), xlWorksheet.LastCellUsed());

    var col = range.ColumnCount();
    var row = range.RowCount();

    //if a datatable already exists, clear the existing table 
    datatable.Clear();
    for (var i = 1; i <= col; i++)
    {
        var column = xlWorksheet.Cell(1, i);
        datatable.Columns.Add(column.Value.ToString());
    }

    var firstHeadRow = 0;
    foreach (var item in range.Rows())
    {
        if (firstHeadRow != 0)
        {
            var array = new object[col];
            for (var y = 1; y <= col; y++)
            {
                array[y - 1] = item.Cell(y).Value;
            }

            datatable.Rows.Add(array);
        }
        firstHeadRow++;
    }
    return datatable;
}

int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
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

void Print(int[] distance, int verticesCount)
{
    Console.WriteLine("Vertex    Distance from source");

    for (int i = 0; i < verticesCount; ++i)
        Console.WriteLine("{0}\t  {1}", i, distance[i]);
}

void Dijkstra(int[,] graph, int source, int verticesCount)
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