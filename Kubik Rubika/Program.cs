using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
var str = File.ReadAllLines(@"D:\Programming\Univer\file.txt");
var kubikbase = str[0].Split().Select(x => int.Parse(x)).ToList();
Console.WriteLine(kubikbase[0]);
var koord = str[1].Split().Select(x => int.Parse(x)).ToList();
List<(string, int, int)> listvrash = new List<(string, int, int)>();
for (int i = 2; i < str.Length; i++)
{
    var temp = str[i].Split().ToArray();
    string os = temp[0];
    int blockos = int.Parse(temp[1]);
    int vrashchas = int.Parse(temp[2]);
    listvrash.Add((os, blockos, vrashchas));
}
List<int> res = new List<int>();
res = vrasheniye(koord, listvrash);
for (int i = 0; i < res.Count; i++)
{
    Console.Write($"{res[i]} ");
}
List<int> vrasheniye(List<int> coords, List<(string, int, int)> vrash)
{
    int tempx = coords[0];
    int tempy = coords[1];
    int tempz = coords[2];
    for (int i = 0; i < vrash.Count; i++)
    {
        switch (vrash[i].Item1)
        {
            case "X":
                if (vrash[i].Item3 == -1)//right
                {
                    if (vrash[i].Item2 == tempx)
                    {
                        var temp = tempy;
                        tempy = kubikbase[0] + 1 - tempz;
                        tempz = temp;
                    }
                }
                else if (vrash[i].Item3 == 1)//right
                {
                    if (vrash[i].Item2 == tempx)
                    {
                        var temp = tempy;
                        tempy = tempz;
                        tempz = kubikbase[0] + 1 - temp;
                    }
                }
                break;
            case "Y":
                if (vrash[i].Item3 == -1)//right
                {
                    if (vrash[i].Item2 == tempy)
                    {
                        var temp = tempx;
                        tempx = kubikbase[0] + 1 - tempz;
                        tempz = temp;
                    }
                }
                else if (vrash[i].Item3 == 1)//right
                {
                    if (vrash[i].Item2 == tempy)
                    {
                        var temp = tempx;
                        tempx = tempz;
                        tempz = kubikbase[0] + 1 - temp;
                    }
                }
                break;
            case "Z":
                if (vrash[i].Item3 == -1)//right
                {
                    if (vrash[i].Item2 == tempz)
                    {
                        var temp = tempx;
                        tempx = kubikbase[0] + 1 - tempy;
                        tempy = temp;
                    }
                }
                else if (vrash[i].Item3 == 1)//right
                {
                    if (vrash[i].Item2 == tempz)
                    {
                        var temp = tempx;
                        tempx = kubikbase[0] + 1 - tempy;
                        tempy = tempx;
                    }
                }
                break;
        }
        //Console.WriteLine($"tempx: {tempx}, tempy: {tempy}, tempz: {tempz}");
    }
    List<int> newcoords = new List<int>();
    newcoords.Add(tempx);
    newcoords.Add(tempy);
    newcoords.Add(tempz);
    return newcoords;
}
