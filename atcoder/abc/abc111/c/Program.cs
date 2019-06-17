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
        int n = cin.nextInt();
        var t1 = new Dictionary<int, int>();
        var t2 = new Dictionary<int, int>();

        for (int i = 0; i < n / 2; i++)
        {
            int v1n = cin.nextInt();
            int v2n = cin.nextInt();
            if (t1.ContainsKey(v1n))
            {
                t1[v1n]++;
            }
            else
            {
                t1.Add(v1n, 1);
            }
            if (t2.ContainsKey(v2n))
            {
                t2[v2n]++;
            }
            else
            {
                t2.Add(v2n, 1);
            }
        }

        var t1rank = new List<Tuple<int, int>>();
        var t2rank = new List<Tuple<int, int>>();
        foreach (int key in t1.Keys)
        {
            t1rank.Add(Tuple.Create(key, t1[key]));
        }
        foreach (int key in t2.Keys)
        {
            t2rank.Add(Tuple.Create(key, t2[key]));
        }

        t1rank.Sort((a, b) => b.Item2 - a.Item2);
        t2rank.Sort((a, b) => b.Item2 - a.Item2);

        if (t1rank[0].Item1 != t2rank[0].Item1)
        {
            Console.WriteLine(n - t1rank[0].Item2 - t2rank[0].Item2);
            return;
        }

        int ret1 = n - t1rank[0].Item2;
        if (t2rank.Count() > 2)
        {
            ret1 -= t2rank[1].Item2;
        }
        int ret2 = n - t2rank[0].Item2;
        if (t1rank.Count() > 2)
        {
            ret2 -= t1rank[1].Item2;
        }
        Console.WriteLine(Math.Min(ret1, ret2));
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
