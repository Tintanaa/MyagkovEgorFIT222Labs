using System;
var text = File.ReadAllLines(@"D:/Programming/Univer/file.txt");
List<string> words = new List<string>();
List<string> beginningsbukva = new List<string>();
List<int> beginningscount = new List<int>();
List<string> endings = new List<string>();
List<int> endingscount = new List<int>();
int countwords = Convert.ToInt32(text[0])+1;
for(int i = 1; i<countwords; i++)
{
    words.Add(text[i]);
    //Console.WriteLine(text[i]);
}
//Console.WriteLine(words.Count);
int beginningcount = Convert.ToInt32(text[countwords])+1;
//Console.WriteLine(beginningcount);
for(int j = countwords+1; j<beginningcount+countwords; j++)
{
    var temp = text[j].Split().ToList();
    //Console.WriteLine($"{temp[0]}, {temp[1]}");
    beginningsbukva.Add(temp[0]);
    beginningscount.Add(Convert.ToInt32(temp[1]));
}
int endingcount = Convert.ToInt32(text[beginningcount + countwords]) + 1;
//Console.WriteLine(endingcount);
for (int k = endingcount+countwords+1; k < text.Length; k++)
{
    var temp = text[k].Split().ToList();
    endings.Add(temp[0]);
    //Console.WriteLine($"{temp[0]},{temp[1]}");
    endingscount.Add(Convert.ToInt32(temp[1]));
}
int count = 0;
int flag = 0;
int index = 0;
//Console.WriteLine("------------------------------------");
for (int i=1; i<words.Count; i++)
{
    string word = words[i];
    Console.WriteLine(word);
    for(int j = 0; j<beginningscount.Count; j++)
    {
        if (Convert.ToString(word[0]) == beginningsbukva[j])
        {
            beginningscount[j] = beginningscount[j] - 1;
            flag++;
            index = j;
            Console.WriteLine($"flag: {flag}");
            Console.WriteLine($"Beginning: {word[0]}, {beginningscount[j]}");
            if (beginningscount[j] == 0)
            {
                beginningsbukva.Remove(beginningsbukva[j]);
                beginningscount.Remove(beginningscount[j]);
            }
            break;
        }
    }
    for(int k = 0; k<endingscount.Count; k++)
    {
        if ((Convert.ToString(word[^1]) == endings[k])&&(flag==1))
        {
            endingscount[k] = endingscount[k] - 1;
            flag++;
            Console.WriteLine($"flag: {flag}");
            Console.WriteLine($"Ending: {word[^1]}, {endingscount[k]}");
            if (endingscount[k] == 0)
            {
                endings.Remove(endings[k]);
                endingscount.Remove(endingscount[k]);
            }
            break;
        }
    }
    if(flag==2)
    {
        count++;
        Console.WriteLine("DA");
        index = 0;
    }
    else
    {
        beginningscount[index]++;
        Console.WriteLine("NET");
        index = 0;
    }
    flag = 0;
    Console.WriteLine("-----------------------------------");
}
Console.WriteLine(count);
/*
 * Проверяем начало на буквы, находим букву, вычитаем единицу, ищем конец, находим, вычитаем единицу, прибавляем найденные
 * слова. Проверяем на кончившиеся начальные и конечные буквы. Убираем в случае если их больше нет. Всё=)
 */