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
        int W = cin.nextInt();

        long[] w = new long[N];
        long[] v = new long[N];

        for (int i = 0; i < N; i++)
        {
            w[i] = cin.nextLong();
            v[i] = cin.nextLong();
        }

        long[] DP = new long[100001];

        for (int i = 0; i <= 100000; i++)
        {
            DP[i] = 10000000000;
        }

        DP[0] = 0;

        for (int i = 0; i < N; i++)
        {
            for (int j = 100000; j >= 0; j--)
            {
                if (j + v[i] <= 100000 && DP[j] + w[i] <= W)
                {
                    DP[j + v[i]] = Math.Min(DP[j + v[i]], DP[j] + w[i]);
                }
            }
        }

        long ans = 0;
        for (int i = 0; i <= 100000; i++)
        {
            if (DP[i] != 10000000000)
            {
                ans = Math.Max(ans, i);
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

