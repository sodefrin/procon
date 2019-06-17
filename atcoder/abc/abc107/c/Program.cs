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

        var a = new List<int>();
        var b = new List<int>();
        a.Add(0);
        b.Add(0);
        for (int i = 0; i < N; i++)
        {
            int x = cin.nextInt();
            if (x > 0)
            {
                a.Add(x);
            }
            else
            {
                b.Add(-x);
            }
        }

        a.Sort();
        b.Sort();
        int min = 1000000001;

        for (int i = 0; i <= K; i++)
        {
            if (a.Count() > i && b.Count() > K - i)
            {
                min = Math.Min(2 * a[i] + b[K - i], min);
            }
        }

        for (int i = 0; i <= K; i++)
        {
            if (b.Count() > i && a.Count() > K - i)
            {
                min = Math.Min(2 * b[i] + a[K - i], min);
            }
        }

        Console.WriteLine(min);
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
