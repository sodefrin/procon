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
        int[] A = new int[N + 2];
        A[0] = 0;
        for (int i = 1; i <= N; i++)
        {
            A[i] = cin.nextInt();
        }
        A[N + 1] = 0;

        int[] l = new int[N + 2];
        int[] r = new int[N + 2];

        for (int i = 1; i < N + 2; i++)
        {
            l[i] = l[i - 1] + Math.Abs(A[i] - A[i - 1]);
            r[N + 1 - i] = r[N + 2 - i] + Math.Abs(A[N + 1 - i] - A[N + 2 - i]);
        }

        for (int i = 1; i <= N; i++)
        {
            Console.WriteLine(l[i - 1] + r[i + 1] + Math.Abs(A[i + 1] - A[i - 1]));
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