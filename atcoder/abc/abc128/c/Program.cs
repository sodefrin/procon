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

    int N;
    int M;
    int[,] sw;
    int[] x;

    public void Do()
    {
        cin = new Scanner();

        N = cin.nextInt();
        M = cin.nextInt();

        sw = new int[M, N];
        for (int i = 0; i < M; i++)
        {
            int k = cin.nextInt();
            for (int j = 0; j < k; j++)
            {
                int s = cin.nextInt();
                sw[i, s - 1] = 1;
            }
        }

        x = new int[M];
        for (int i = 0; i < M; i++)
        {
            int p = cin.nextInt();
            x[i] = p;
        }

        int max = 1;
        for (int i = 0; i < N; i++)
        {
            max *= 2;
        }

        int ans = 0;
        for (int i = 0; i < max; i++)
        {
            int[] a = intToBinaryArray(i);
            int[] ret = calc(a);
            if (!isEqual(ret, x))
            {
                continue;
            }
            ans++;
        }

        Console.WriteLine(ans);
    }

    bool isEqual(int[] a, int[] b)
    {
        for (int j = 0; j < M; j++)
        {
            if (a[j] % 2 != b[j])
            {
                return false;
            }
        }
        return true;
    }

    int[] intToBinaryArray(int a)
    {
        var ret = new int[N];
        for (int i = 0; i < N; i++)
        {
            ret[i] = a % 2;
            a = a / 2;
        }

        return ret;
    }

    int[] calc(int[] a)
    {
        var ret = new int[M];
        for (int i = 0; i < M; i++)
        {
            ret[i] = 0;
            for (int j = 0; j < N; j++)
            {
                ret[i] += sw[i, j] * a[j];
            }
        }
        return ret;
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
