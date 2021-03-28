using System;
using System.Collections.Generic;
using System.Linq;

namespace WatersVolume
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите последовательность положительных чисел через запятую:");

            do
            {
                try
                {
                    var arr = Console.ReadLine().Split(',').Select(o => int.Parse(o)).ToArray();
                    var prev = 0;
                    var maxes = new List<KeyValuePair<int, int>>();

                    for (var i = 0; i < arr.Count(); i++)
                    {
                        if (prev < arr[i])
                        {
                            if (maxes.Count() > 2 && maxes.Last().Value < maxes[maxes.Count() - 2].Value && maxes.Last().Value < arr[i])
                                maxes.Remove(maxes.Last());

                            maxes.Add(new KeyValuePair<int, int>(i, arr[i]));
                        }

                        prev = arr[i];
                    }

                    var res = 0;

                    for (var i = 0; i < maxes.Count() - 1; i++)
                    {
                        for (var j = maxes[i].Key + 1; j < maxes[i + 1].Key; j++)
                            res += maxes[i].Value < maxes[i + 1].Value ? maxes[i].Value - arr[j] : maxes[i + 1].Value - arr[j];
                    }

                    Console.WriteLine(res);

                    break;
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод, повторите:");
                }
            }
            while (true);
        }
    }
}
