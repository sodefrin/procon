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
    int A, B, C;

    int INF = 1000000000;

    int[] l;

    public void Do()
    {
        cin = new Scanner();
        N = cin.nextInt();
        A = cin.nextInt();
        B = cin.nextInt();
        C = cin.nextInt();

        l = new int[N];
        for (int i = 0; i < N; i++)
        {
            l[i] = cin.nextInt();
        }

        Console.WriteLine(dfs(0, 0, 0, 0));
    }

    int dfs(int cur, int a, int b, int c)
    {
        if (cur == N)
        {
            if (a != 0 && b != 0 && c != 0)
            {
                return Math.Abs(A - a) + Math.Abs(B - b) + Math.Abs(C - c) - 30;
            }
            return INF;
        }

        int ret0 = dfs(cur + 1, a, b, c);
        int ret1 = dfs(cur + 1, a + l[cur], b, c) + 10;
        int ret2 = dfs(cur + 1, a, b + l[cur], c) + 10;
        int ret3 = dfs(cur + 1, a, b, c + l[cur]) + 10;

        return Math.Min(Math.Min(ret0, ret1), Math.Min(ret2, ret3));
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

