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
        List<int> amount = new List<int>();

        amount.Add(1);
        int tmp = 1;
        while (true)
        {
            tmp *= 6;
            if (tmp > N)
            {
                break;
            }
            amount.Add(tmp);
        }

        tmp = 1;
        while (true)
        {
            tmp *= 9;
            if (tmp > N)
            {
                break;
            }
            amount.Add(tmp);
        }

        int[] DP = new int[N + 1];
        for (int i = 0; i <= N; i++)
        {
            DP[i] = 1000000;
        }


        DP[0] = 0;
        for (int i = 0; i <= N; i++)
        {
            for (int j = 0; j < amount.Count; j++)
            {
                if (i + amount[j] <= N)
                {
                    DP[i + amount[j]] = Math.Min(DP[i] + 1, DP[i + amount[j]]);
                }
            }
        }

        Console.WriteLine(DP[N]);
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