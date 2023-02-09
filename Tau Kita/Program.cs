using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
var str = File.ReadAllLines(@"D:\Programming\Univer\file.txt");
var stri = str[0].Split().Select(x => x).ToList();
stri = Phrasebuilder(stri);
for (int i = 0; i < stri.Count; i++)
{
    var temp = stri[i];
    stri[i] = Wordbuilder(temp);
}
foreach (var i in stri)
{
    Console.Write($"{i} ");
}
static string Wordbuilder(string str)
{
    char[] c = str.ToCharArray();
    char[] newword = new char[c.Length];
    int flag = 1;
    for (int i = 0; i < c.Length; i++)
    {
        if (i == 0)
        {
            newword[i] = c[c.Length / 2];
        }
        else if (i % 2 == 1)
        {
            newword[i] = c[c.Length / 2 - flag];
        }
        else if (i % 2 == 0)
        {
            newword[i] = c[c.Length / 2 + flag];
            flag++;
        }
    }
    string newstr = new string(newword);
    return newstr;
}
static List<string> Phrasebuilder(List<string> list)
{
    List<string> newlist = new List<string>(new string[list.Count]);
    int flag = 1;
    for (int i = 0; i < list.Count; i++)
    {
        if (i == 0)
        {
            newlist[i] = list[list.Count / 2];
        }
        else if (i % 2 == 1)
        {
            newlist[i] = list[list.Count / 2 - flag];
        }
        else if (i % 2 == 0)
        {
            newlist[i] = list[list.Count / 2 + flag];
            flag++;
        }
    }
    return newlist;
}