﻿using System;
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
        int M = cin.nextInt();

        List<Tuple<long, long>> C = new List<Tuple<long, long>>();

        for (int i = 0; i < N; i++)
        {
            long a = cin.nextLong();
            C.Add(Tuple.Create(a, (long)1));
        }

        for (int i = 0; i < M; i++)
        {
            long b = cin.nextInt();
            long c = cin.nextLong();
            C.Add(Tuple.Create(c, b));
        }

        C.Sort((a, b) => (int)b.Item1 - (int)a.Item1);

        long ret = 0;
        long count = 0;
        for (int i = 0; i < C.Count(); i++)
        {
            count += C[i].Item2;
            ret += C[i].Item1 * C[i].Item2;
            if (count >= N)
            {
                ret -= C[i].Item1 * (count - N);
                break;
            }
        }

        Console.WriteLine(ret);
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