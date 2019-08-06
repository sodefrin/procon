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
        int[,] abc = new int[N, 3];
        int[,] DP = new int[N + 1, 3];

        for (int i = 0; i < N; i++)
        {
            abc[i, 0] = cin.nextInt();
            abc[i, 1] = cin.nextInt();
            abc[i, 2] = cin.nextInt();
        }

        for (int i = 1; i < N + 1; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                DP[i, (j + 1) % 3] = Math.Max(DP[i, (j + 1) % 3], DP[i - 1, j] + abc[i - 1, (j + 1) % 3]);
                DP[i, (j + 2) % 3] = Math.Max(DP[i, (j + 2) % 3], DP[i - 1, j] + abc[i - 1, (j + 2) % 3]);
            }
        }

        Console.WriteLine(Math.Max(Math.Max(DP[N, 0], DP[N, 1]), DP[N, 2]));
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

