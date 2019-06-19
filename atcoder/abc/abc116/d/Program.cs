using System;
using System.Collections.Generic;
using System.Linq;

class Procon
{
    public Procon() { }
    static void Main(string[] agrs)
    {
        new Procon().Do();
    }

    Scanner cin;

    public void Do()
    {
        cin = new Scanner();
        int N = cin.nextInt();
        int K = cin.nextInt();
        var sushi = new List<Tuple<long, long>>();
        for (int i = 0; i < N; i++)
        {
            long t = cin.nextLong();
            long d = cin.nextLong();
            sushi.Add(Tuple.Create(t, d));
        }

        sushi.Sort((a, b) => (int)b.Item2 - (int)a.Item2);

        var dict = new Dictionary<long, long>();
        long sum = 0;
        long count = 0;
        for (int i = 0; i < K; i++)
        {
            sum += sushi[i].Item2;
            if (dict.ContainsKey(sushi[i].Item1))
            {
                dict[sushi[i].Item1]++;
            }
            else
            {
                dict[sushi[i].Item1] = 1;
                count++;
            }
        }

        long ans = sum + count * count;
        int remove = K;
        for (int i = K; i < N; i++)
        {
            if (!dict.ContainsKey(sushi[i].Item1))
            {
                sum += sushi[i].Item2;
                dict[sushi[i].Item1] = 1;
                count++;
                while (true)
                {
                    remove--;
                    if (dict.ContainsKey(sushi[remove].Item1) && dict[sushi[remove].Item1] > 1)
                    {
                        dict[sushi[remove].Item1]--;
                        sum -= sushi[remove].Item2;
                        ans = Math.Max(sum + count * count, ans);
                        break;
                    }
                    if (remove == 0)
                    {
                        Console.WriteLine(ans);
                        return;
                    }
                }
            }
        }

        Console.WriteLine(ans);
    }
}

class Scanner
{
    string[] s;
    int i;
    int max_i;

    public Scanner()
    {
        s = new string[0];
        max_i = 0;
        i = 0;
    }

    public string nextString()
    {
        if (i >= s.Length)
        {
            s = Console.ReadLine().Split(' ');
            max_i = s.Length;
            i = 0;
            if (max_i == 0)
            {
                return "";
            }
            return s[i++];
        }
        else
        {
            return s[i++];
        }
    }

    public int nextInt()
    {
        return int.Parse(nextString());
    }


    public long nextLong()
    {
        return long.Parse(nextString());
    }

    public double nextDouble()
    {
        return double.Parse(nextString());
    }

    public string[] arrayString()
    {
        return Console.ReadLine().Split(' ');
    }

    public int[] arrayInt()
    {
        string[] str = Console.ReadLine().Split(' ');
        int[] array = new int[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            array[i] = int.Parse(str[i]);
        }
        return array;
    }

    public long[] arrayLong()
    {
        string[] str = Console.ReadLine().Split(' ');
        long[] array = new long[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            array[i] = long.Parse(str[i]);
        }
        return array;
    }

    public double[] arrayDouble()
    {
        string[] str = Console.ReadLine().Split(' ');
        double[] array = new double[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            array[i] = double.Parse(str[i]);
        }
        return array;
    }
}
