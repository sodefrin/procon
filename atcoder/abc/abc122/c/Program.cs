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

    int N, Q;

    string S;

    public void Do()
    {
        cin = new Scanner();
        N = cin.nextInt();
        Q = cin.nextInt();
        S = cin.nextString();

        int[] start = new int[N];
        int[] end = new int[N];
        for (int i = 0; i < N; i++)
        {
            if (i + 1 >= N)
            {
                break;
            }
            else if (i - 1 < 0)
            {
                start[i] = 0;
                end[i + 1] = 0;
            }
            else
            {
                start[i] = start[i - 1];
                end[i + 1] = end[i];
            }

            if (S[i] == 'A' && S[i + 1] == 'C')
            {
                start[i]++;
                end[i + 1]++;
            }
        }

        start[N - 1] = start[N - 2];

        for (int i = 0; i < Q; i++)
        {
            int l = cin.nextInt() - 1;
            int r = cin.nextInt() - 1;
            if (l - 1 < 0)
            {
                Console.WriteLine(end[r]);
            }
            else
            {
                Console.WriteLine(end[r] - start[l - 1]);
            }
        }
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