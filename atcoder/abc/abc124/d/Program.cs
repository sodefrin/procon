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

        var index = new List<int>();
        int tmp = Console.Read();
        index.Add(0);
        if (tmp == '0')
        {
            index.Add(0);
        }

        for (int i = 1; i < N; i++)
        {
            int c = Console.Read();
            if (c != tmp)
            {
                index.Add(i);
                tmp = c;
            }
        }

        int max = 0;
        for (int i = 0; i < index.Count(); i++)
        {
            if (i % 2 == 0)
            {
                if (i + 2 * K + 1 < index.Count())
                {
                    max = Math.Max(index[i + 2 * K + 1] - index[i], max);
                }
                else
                {
                    max = Math.Max(N - index[i], max);
                }
            }
            else
            {
                if (i + 2 * K < index.Count())
                {
                    max = Math.Max(index[i + 2 * K] - index[i], max);
                }
                else
                {
                    max = Math.Max(N - index[i], max);
                }
            }
        }

        Console.WriteLine(max);
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