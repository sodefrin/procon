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

    int D;
    long G;
    long[] p;
    long[] c;

    public void Do()
    {
        cin = new Scanner();
        D = cin.nextInt();
        G = cin.nextLong();
        p = new long[D];
        c = new long[D];
        for (int i = 0; i < D; i++)
        {
            p[i] = cin.nextLong();
            c[i] = cin.nextLong();
        }
        Console.WriteLine(dfs(0, 0));
    }

    long solveToG(int isComplete)
    {
        long score = 0;
        long num = 0;
        for (int i = 1; i <= D; i++)
        {
            if ((isComplete >> i & 1) == 1)
            {
                score += c[i - 1] + i * 100 * p[i - 1];
                num += p[i - 1];
            }
        }

        if (score >= G)
        {
            return num;
        }

        long remaining = G - score;
        for (int i = D; i >= 1; i--)
        {
            if ((isComplete >> i & 1) == 1)
            {
                continue;
            }
            if (remaining <= i * 100 * p[i - 1])
            {
                num += remaining / (i * 100);
                if (remaining % (i * 100) != 0)
                {
                    num++;
                }
                return num;
            }
            else
            {
                num += p[i - 1];
                remaining -= i * 100 * p[i - 1];
            }
        }
        return 100000000;
    }

    long dfs(int n, int isComplete)
    {
        if (n == D)
        {
            return solveToG(isComplete);
        }

        return Math.Min(dfs(n + 1, isComplete), dfs(n + 1, isComplete + (1 << n + 1)));
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