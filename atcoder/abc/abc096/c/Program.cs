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
        int H = cin.nextInt();
        int W = cin.nextInt();
        int[,] s = new int[H, W];

        for (int i = 0; i < H; i++)
        {
            string tmp = cin.nextString();
            for (int j = 0; j < W; j++)
            {
                if (tmp[j] == '.')
                {
                    s[i, j] = 0;
                }
                else
                {
                    s[i, j] = 1;
                }
            }
        }

        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                if (s[i, j] == 1)
                {
                    bool ok = false;
                    if (i - 1 >= 0 && s[i - 1, j] == 1)
                    {
                        ok = true;
                    }
                    if (j - 1 >= 0 && s[i, j - 1] == 1)
                    {
                        ok = true;
                    }
                    if (i + 1 < H && s[i + 1, j] == 1)
                    {
                        ok = true;
                    }
                    if (j + 1 < W && s[i, j + 1] == 1)
                    {
                        ok = true;
                    }
                    if (!ok)
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
            }
        }

        Console.WriteLine("Yes");
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